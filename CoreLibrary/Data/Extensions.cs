using CoreLibrary.DataTransfer;
using Newtonsoft.Json;

namespace CoreLibrary.Data;

public static class Extensions
{
    public static ModelResponse<T> ToModelResponse<T>(this T model) where T : class
    {
        var res = new ModelResponse<T>
        {
            Success = true,
            Models = new List<T> { model }
        };
        return res;
    }

    public static ModelResponse<T> ToModelResponse<T>(this IEnumerable<T> models) where T : class
    {
        var res = new ModelResponse<T>
        {
            Success = true,
            Models = models.ToList()
        };
        return res;
    }

    public static ModelRequest<T> ToModelRequest<T>(this T model) where T: class
    {
        return new ModelRequest<T>
        {
            Model = model
        };
    }

    public static string Serialize<T>(this ModelRequest<T> model) where T : class
    {
        return JsonConvert.SerializeObject(model);
    }

    public static string Serialize<T>(this ModelResponse<T> model) where T : class
    {
        return JsonConvert.SerializeObject(model);
    }

    public static ModelRequest<T>? DeserializeRequest<T>(this string content) where T : class
    {
        return JsonConvert.DeserializeObject<ModelRequest<T>>(content);
    }

    public static ModelResponse<T>? DeserializeResponse<T>(this string content) where T : class
    {
        return JsonConvert.DeserializeObject<ModelResponse<T>>(content);
    }
}