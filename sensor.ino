
#include "DHT.h"
#include <MQUnifiedsensor.h>
#include <SoftwareSerial.h>

#define period 5

#define DHT11Pin 5
#define DHT22Pin 4
#define DM460Pin A0
#define DM2007Pin A1
#define MQ135pin A2 
#define HC06RX 7  //HC06의 TX와 연결
#define HC06TX 8  //HC06의 RX와 연결

#define placa "Arduino UNO"
#define Voltage_Resolution 5
#define type "MQ-135" 
#define ADC_Bit_Resolution 10 // For arduino UNO/MEGA/NANO
#define RatioMQ135CleanAir 3.6//RS / R0 = 3.6 ppm  

unsigned long preTime;
unsigned long curTime;
bool isFirst;
char data;

DHT dht11(DHT11Pin, DHT11);
DHT dht22(DHT22Pin, DHT22);
MQUnifiedsensor MQ135(placa, Voltage_Resolution, ADC_Bit_Resolution, MQ135pin, type);
SoftwareSerial HC06(HC06RX,HC06TX);
 

void CalibrateMQ135(MQUnifiedsensor* MQ135);
void PrintTempAndHumidData(float temp, float humid);
void PrintMQ153(MQUnifiedsensor MQ135);
void GetTempAndHumidData(DHT dht);
void GetLightIntencity(int PinNum);
void WriteString(String stringData);
void MyPrint(String str);

void setup()
{
    Serial.begin(9600);

    dht11.begin();
    dht22.begin();

    CalibrateMQ135(&MQ135);

    HC06.begin(9600);
   
    preTime = millis();
    isFirst = true;
    
}
void loop()
{
    curTime = millis();

    if(HC06.available())
    {
        data = HC06.read();
        Serial.print(data);
    }

    if(data=='1')  //블루투스 전달값이 1인경우에는 측정 시작, 그 외는 측정 중지
    {
        if( curTime - preTime >= 1000 * period || isFirst)
        {     
            //DHT11
            Serial.print("DHT11:");
            HC06.print("DHT11:");
            GetTempAndHumidData(dht11);

            //DHT22
            Serial.print("DHT22:");
            HC06.print("DHT22:");
            GetTempAndHumidData(dht22);
            
            //DM460
            Serial.print("DM460: ");
            HC06.print("DM460: ");
            GetLightIntencity(DM460Pin);

            //DM2007
            Serial.print("DM2007: ");
            HC06.print("DM2007: ");
            GetLightIntencity(DM2007Pin);

            //MQ135
            MQ135.update();
            PrintMQ153(MQ135); 
            
            preTime = millis();
            isFirst = false;
        }
    }
}

void CalibrateMQ135(MQUnifiedsensor* pMQ135)
{
    (*pMQ135).setRegressionMethod(1);
    (*pMQ135).init();
    Serial.print("Calibrating please wait.");
    (*pMQ135).setRL(47);
    float calcR0 = 0;
    for(int i = 1; i<=10; i ++)
    {
        (*pMQ135).update(); // Update data, the arduino will be read the voltage on the analog pin
        calcR0 += (*pMQ135).calibrate(RatioMQ135CleanAir);
        Serial.print(".");
    }
    (*pMQ135).setR0(calcR0/10);
    Serial.println("  done!.");
}

void GetTempAndHumidData(DHT dht)
{
    float humid = dht.readHumidity();
    float temp = dht.readTemperature();
    PrintTempAndHumidData(temp, humid);
}

void PrintTempAndHumidData(float temp, float humid)
{

    Serial.print("(");
    Serial.print(temp);
    Serial.print(",");
    Serial.print(humid);
    Serial.println(")");
    HC06.print("(");
    HC06.print(temp);
    HC06.print(",");
    HC06.print(humid);
    HC06.println(")");
}

void GetLightIntencity(int PinNum)
{
    int lightIntensity = analogRead(PinNum);
    Serial.print(lightIntensity);
    Serial.print("\n");
    HC06.print(lightIntensity);
    HC06.print("\n");

}

void PrintMQ153(MQUnifiedsensor MQ135)
{
    MQ135.setA(605.18); MQ135.setB(-3.937); // Configurate the ecuation values to get CO concentration
    float CO = MQ135.readSensor(); // Sensor will read PPM concentration using the model and a and b values setted before or in the setup

    MQ135.setA(77.255); MQ135.setB(-3.18); // Configurate the ecuation values to get Alcohol concentration
    float Alcohol = MQ135.readSensor(); // Sensor will read PPM concentration using the model and a and b values setted before or in the setup

    MQ135.setA(110.47); MQ135.setB(-2.862); // Configurate the ecuation values to get CO2 concentration
    float CO2 = MQ135.readSensor(); // Sensor will read PPM concentration using the model and a and b values setted before or in the setup

    MQ135.setA(44.947); MQ135.setB(-3.445); // Configurate the ecuation values to get Tolueno concentration
    float Tolueno = MQ135.readSensor(); // Sensor will read PPM concentration using the model and a and b values setted before or in the setup

    MQ135.setA(102.2 ); MQ135.setB(-2.473); // Configurate the ecuation values to get NH4 concentration
    float NH4 = MQ135.readSensor(); // Sensor will read PPM concentration using the model and a and b values setted before or in the setup

    MQ135.setA(34.668); MQ135.setB(-3.369); // Configurate the ecuation values to get Acetona concentration
    float Acetona = MQ135.readSensor(); // Sensor will read PPM concentration using the model and a and b values setted before or in the setup

    Serial.println("|    CO   |  Alcohol |   CO2  |  Tolueno  |  NH4  |  Acteona  |");  
    Serial.print("|   "); Serial.print(CO); 
    Serial.print("   |   "); Serial.print(Alcohol); 
    Serial.print("   |   "); Serial.print(CO2+400); 
    Serial.print("   |   "); Serial.print(Tolueno); 
    Serial.print("   |   "); Serial.print(NH4); 
    Serial.print("   |   "); Serial.print(Acetona);
    Serial.println("   |");     

    HC06.print("CO:"); HC06.println(CO); 
    HC06.print("Alcohol:"); HC06.println(Alcohol); 
    HC06.print("CO2:"); HC06.println(CO2+400); 
    HC06.print("Tolueno:"); HC06.println(Tolueno); 
    HC06.print("NH4:"); HC06.println(NH4); 
    HC06.print("Acetona:"); HC06.println(Acetona);
}
