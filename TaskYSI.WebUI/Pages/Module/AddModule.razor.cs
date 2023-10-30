using TaskYSI.WebUI.Data;

namespace TaskYSI.WebUI.Pages.Module;

public partial class AddModule
{
    private readonly List<string> _moduleOptions = new() { "Option 1", "Option 2", "Option 3" };
    private ModuleData _module = new();
    
    private bool _isEdit;
    
    private async void OnSubmit()
    {
       
    }
}