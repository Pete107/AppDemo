namespace CoreLibrary.DataTransfer;

public class ModelRequest<T> where T : BaseViewModel
{
    public T Model { get; set; }
}