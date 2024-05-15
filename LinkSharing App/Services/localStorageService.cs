
using Microsoft.JSInterop;

namespace LinkSharing_App.Services
{
    public class localStorageService(IJSRuntime jSRuntime) : IlocalStorageService
    {
        public async Task<string> Read(string key)
        {
            return await jSRuntime.InvokeAsync<string>("localStorage.getItem", key);
        }

        public async Task Write(string key, string value)
        {
            await jSRuntime.InvokeVoidAsync("localStorage.setItem", key, value);
        }
    }
}
