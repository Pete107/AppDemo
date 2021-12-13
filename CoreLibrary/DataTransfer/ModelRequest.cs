namespace CoreLibrary.DataTransfer;

public class ModelRequest<T> where T : class
{
    public T Model { get; set; }
}