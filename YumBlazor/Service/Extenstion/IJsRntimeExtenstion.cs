using Microsoft.JSInterop;

namespace YumBlazor.Service.Extenstion
{
    public static class IJsRntimeExtenstion
    {
        public static async Task ToastrSuccess(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToast","success", message);
        }
        public static async Task ToastrError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToast", "error", message);
        }
        public static async Task ToastrInfo(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToast", "info", message);
        }
        public static async Task ToastrWarning(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("showToast", "warning", message);
        }
    }
}
