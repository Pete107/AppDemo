using System.ComponentModel.DataAnnotations;
using CoreLibrary;
using CoreLibrary.Data;

namespace GameCollection;

public class GameViewModel : BaseViewModel
{
    [Required] public string Title { get; set; } = string.Empty;
    [Required] public GameGenre Genre { get; set; } = GameGenre.None;
    [Required] public DateTime ReleaseDate { get; set; } = DateTime.Today;
    [Required] public string Publisher { get; set; } = string.Empty;
    [Required] public string Developers { get; set; } = string.Empty;
    [Required] public GamePlatform Platform { get; set; } = GamePlatform.Desktop;
    [Required] public double Price { get; set; } = 0;
    public GameViewModel()
    {
    }

    public GameViewModel(BaseModel model) : base(model)
    {
        if (model is not GameModel gameModel) return;
        Title = gameModel.Title;
        Genre = gameModel.Genre;
        ReleaseDate = gameModel.ReleaseDate;
        Publisher = gameModel.Publisher;
        Developers = gameModel.Developers;
        Platform = gameModel.Platform;
        Price = gameModel.Price;
    }
}