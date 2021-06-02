#include <SoftwareSerial.h>
 
#define HC06RX 7 //HC-06의 TX Pin - Arduino Uno의 RX
#define HC06TX 8 //HC-06의 RX Pin - Arduino Uno의 TX
 
SoftwareSerial HC06(HC06RX,HC06TX);
 
void setup(){
 
    pinMode(13, OUTPUT);
 
    Serial.begin(9600);
    HC06.begin(9600);
 
}
 
void loop(){
    char temp;
    if(HC06.available()){
        temp = HC06.read();
        if(temp == '1'){
            digitalWrite(13, HIGH);
        }
        else if(temp == '0'){
            digitalWrite(13, LOW);
       }
    }
}
 
