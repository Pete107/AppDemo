using CoreLibrary;
using CoreLibrary.Data;

namespace GameCollection
{
    public class GameModel : BaseModel
    {
       public string Title { get; set; } = string.Empty;
       public GameGenre Genre { get; set; } = GameGenre.None;
       public DateTime ReleaseDate { get; set; } = DateTime.Today;
       public string Publisher { get; set; } = string.Empty;
       public string Developers { get; set; } = string.Empty;
       public GamePlatform Platform { get; set; } = GamePlatform.Desktop;
       public double Price { get; set; } = 0;


        public GameModel()
        {
        }

        public GameModel(BaseViewModel viewModel) : base(viewModel)
        {
            if (viewModel is not GameViewModel gameView) return;
            Title = gameView.Title;
            Genre = gameView.Genre;
            Platform = gameView.Platform;
            ReleaseDate = gameView.ReleaseDate;
            Publisher = gameView.Publisher;
            Developers = gameView.Developers;
            Price = gameView.Price;
        }

        public override void Update(BaseModel model)
        {
            if (model is not GameModel gameModel) return;
            base.Update(model);
            Title = gameModel.Title;
            Genre = gameModel.Genre;
            ReleaseDate = gameModel.ReleaseDate;
            Publisher = gameModel.Publisher;
            Developers = gameModel.Developers;
            Platform = gameModel.Platform;
            Price = gameModel.Price;
        }

        public static implicit operator GameModel(GameViewModel viewModel) => new(viewModel);
        public static implicit operator GameViewModel(GameModel model) => new(model);
    }
}