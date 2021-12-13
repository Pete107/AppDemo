using Newtonsoft.Json;

namespace CoreLibrary.DataTransfer;

public class ModelResponse<T> where T : class
{
    public bool Success { get; set; } = false;
    [JsonIgnore]
    public T Model => Models[0];
    public List<T> Models { get; set; } = new();

}