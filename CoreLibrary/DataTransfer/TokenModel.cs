namespace CoreLibrary.DataTransfer;

public class TokenModel
{
    public string UserId { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpireTime { get; set; } = DateTime.Today;
}