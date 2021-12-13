using System.Text.Json.Serialization;

namespace CoreLibrary.DataTransfer;

public class ModelResponse<T> where T : class
{
    public bool Success { get; set; } = false;
    [Newtonsoft.Json.JsonIgnore]
    [JsonIgnore]
    public T? Model => Models[0];
    public List<T> Models { get; set; } = new();

}