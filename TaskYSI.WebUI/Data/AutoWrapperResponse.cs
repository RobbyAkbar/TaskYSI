namespace TaskYSI.WebUI.Data;

public class AutoWrapperResponse<T>
{
    public string Message { get; set; } = default!;
    public required T Result { get; set; }
}