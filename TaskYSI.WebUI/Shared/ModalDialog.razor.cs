using Microsoft.AspNetCore.Components;

namespace TaskYSI.WebUI.Shared;

public partial class ModalDialog
{
    [Parameter] public string Title { get; set; } = default!;

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private string _modalDisplay = "none;";
    private string _modalClass = string.Empty;
    private bool _showBackdrop;

    public void Open()
    {
        _modalDisplay = "block";
        _modalClass = "show";
        _showBackdrop = true;
    }

    public void Close()
    {
        _modalDisplay = "none";
        _modalClass = string.Empty;
        _showBackdrop = false;
    }
}