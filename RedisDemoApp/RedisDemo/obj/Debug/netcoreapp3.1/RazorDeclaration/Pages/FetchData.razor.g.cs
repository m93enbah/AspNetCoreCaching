// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace RedisDemo.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using RedisDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using RedisDemo.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using Microsoft.Extensions.Caching.Distributed;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\_Imports.razor"
using RedisDemo.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\Pages\FetchData.razor"
using RedisDemo.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 50 "C:\Users\m.enbeh\Desktop\Asp.NetCore API With Caching\RedisDemoApp\RedisDemo\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;
    private string loadLocation = "";
    private string isCacheData = "";

    private async Task LoadForeCast()
    {
        forecasts = null;
        loadLocation = null;
        //to create redis cache item key 
        string recordKey = "WeatherForeCast_" + DateTime.Now.ToString("yyyyMMdd_hhmm");

        forecasts = await cache.GetRecordAsync<WeatherForecast[]>(recordKey);
        //if the key not exist get it from the database and set into the redis cache
        if (forecasts is null)
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
            loadLocation = $"Loaded from API at {DateTime.Now}";
            isCacheData = "";

            await cache.SetRecordAsync(recordKey, forecasts);
        }
        else 
        {
            loadLocation = $"Loaded from the cache at {DateTime.Now}";
            isCacheData = "text-danger";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDistributedCache cache { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
