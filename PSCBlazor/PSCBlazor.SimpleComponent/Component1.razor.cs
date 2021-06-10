using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace PSCBlazor.SimpleComponent
{
	public partial class Component1
	{
		[Parameter] public string ParentName { get; set; }
		[Parameter] public string Text { get; set; }
		[Parameter] public EventCallback<string> TextChanged { get; set; }

        [Inject] private IJSRuntime JsRuntime { get; set; }

        private async Task GetTextAsync()
        {
            // Call JS interop.
            var text = await new ExampleJsInterop(JsRuntime).Prompt("Enter some text:");

            // Trigger the changed event.
            await TextChanged.InvokeAsync(text);

            // Set the property value.
            Text = text;
        }
    }
}
