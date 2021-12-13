namespace CoreLibrary.DataTransfer;

public class ModelResponse<T> where T : BaseViewModel
{
    public bool Success { get; set; } = false;
    public T Model => Models[0];
    public List<T> Models { get; set; } = new();

}