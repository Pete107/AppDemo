using CoreLibrary.Data;

namespace CoreLibrary.Tests.TestingModels;

public class TestViewModel : BaseViewModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Viewed { get; set; } = false;

    public TestViewModel()
    {
        
    }

    public TestViewModel(BaseModel model) : base(model)
    {
        if (model is not TestModel testModel) return;
        Title = testModel.Title;
        Description = testModel.Description;
        Viewed = testModel.Viewed;
    }
}