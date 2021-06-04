#pragma checksum "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1498e42ebb1d65bdcb6734c40538049956a7ee0"
// <auto-generated/>
#pragma warning disable 1591
namespace blazorHub.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 3 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using blazorHub.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/pi/Projects/blazorHub/Client/_Imports.razor"
using blazorHub.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
using blazorHub.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
using System.IO.Ports;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/iotdata")]
    public partial class IoTData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>IoT Data</h1>\n\n");
            __builder.OpenElement(1, "p");
            __builder.AddContent(2, "Current status : ");
            __builder.AddContent(3, 
#nullable restore
#line 13 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
                     toggle

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(4, "\n");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "class", "btn btn-primary");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
                                          Toggle

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(8, 
#nullable restore
#line 14 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
                                                   toggle

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\n\n");
            __builder.OpenElement(10, "p");
            __builder.AddMarkupContent(11, "\n    Temp: <br>\n    DHT11 - ");
            __builder.AddContent(12, 
#nullable restore
#line 18 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
             data.DHT11Temp

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(13, " <br>\n    DHT22 - ");
            __builder.AddContent(14, 
#nullable restore
#line 19 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
             data.DHT22Temp

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(15, " <br>\n    <br>\n    Humidity: <br>\n    DHT11 - ");
            __builder.AddContent(16, 
#nullable restore
#line 22 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
             data.DHT11Humid

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(17, " <br>\n    DHT22 - ");
            __builder.AddContent(18, 
#nullable restore
#line 23 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
             data.DHT22Humid

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(19, " <br>\n    <br>\n    Light Intensity:  <br>\n    DM460: ");
            __builder.AddContent(20, 
#nullable restore
#line 26 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
            data.DM460LightIntensity

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(21, " <br>\n    DM2007: ");
            __builder.AddContent(22, 
#nullable restore
#line 27 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
             data.DM2007LightIntensity

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(23, " <br>\n    <br>\n    Air<br>\n    CO: ");
            __builder.AddContent(24, 
#nullable restore
#line 30 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
         data.CO

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(25, " <br>\n    Alcohol: ");
            __builder.AddContent(26, 
#nullable restore
#line 31 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
              data.Alcohol

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(27, " <br>\n    CO2: ");
            __builder.AddContent(28, 
#nullable restore
#line 32 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
          data.CO2

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(29, " <br>\n    Tolueno: ");
            __builder.AddContent(30, 
#nullable restore
#line 33 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
              data.Tolueno

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(31, " <br>\n    NH4: ");
            __builder.AddContent(32, 
#nullable restore
#line 34 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
          data.NH4

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(33, " <br>\n    Acetona: ");
            __builder.AddContent(34, 
#nullable restore
#line 35 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
              data.Acetona

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(35, " <br>");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "/home/pi/Projects/blazorHub/Client/Pages/IoTData.razor"
       
    bool toggle = false; //꺼짐
    private HubConnectionBuilder _hubConnectionBuilder { get; set; }
    private HubConnection hubConnection;
    private Func<ArduinoData, Task> handleReceiveData;

    private Func<bool, Task> handleSwitchStatus;
    ArduinoData data = new ArduinoData();

    protected override async Task OnInitializedAsync()
    {
        handleReceiveData += ReceiveData;
        var portConnection = new HubConnectionBuilder()
                    .WithUrl(NavigationManager.ToAbsoluteUri("/datahub"))
                    .WithAutomaticReconnect()
                    .Build();
        portConnection.On("ReceiveData", this.handleReceiveData);
        await portConnection.StartAsync();
        
        handleSwitchStatus += ReceiveSwitchStatus;
        hubConnection = new HubConnectionBuilder()
                    .WithUrl(NavigationManager.ToAbsoluteUri("/ctrlhub"))
                    .WithAutomaticReconnect()
                    .Build();
        hubConnection.On("ReceiveSwitchStatus", this.handleSwitchStatus);
        await hubConnection.StartAsync();
    }

    Task ReceiveData(ArduinoData recivedData)
    {
        data = recivedData;
        StateHasChanged();
        return Task.CompletedTask;
    }

    Task ReceiveSwitchStatus(bool arg)
    {
        toggle = arg;
        StateHasChanged();
        return Task.CompletedTask;
    }

    async Task Toggle()
    {
        await hubConnection.SendAsync("ReceiveSwitchStatus", toggle);
    }

    












#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
