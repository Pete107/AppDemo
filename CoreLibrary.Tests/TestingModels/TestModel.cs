using System.Collections.Generic;
using CoreLibrary.Data;

namespace CoreLibrary.Tests.TestingModels;

public class TestModel : BaseModel
{
    public static List<TestModel> MockModels = new()
    {
        new TestModel
        {
            Title = "Mock Model.",
            Description = "A models description.",
            Viewed = false
        },
        new TestModel
        {
            Title = "Mock Data Model.",
            Description = "A small description.",
            Viewed = false
        },
        new TestModel
        {
            Title = "Data Model.",
            Description = "Data models description.",
            Viewed = true
        },
        new TestModel
        {
            Title = "Model.",
            Description = "Description.",
            Viewed = true
        },
        new TestModel
        {
            Title = "Mock Data.",
            Description = "Data description.",
            Viewed = false
        },
        new TestModel
        {
            Title = "Test Model.",
            Description = "Test Models Description.",
            Viewed = false
        },
        new TestModel
        {
            Title = "B Model.",
            Description = "B Models description.",
            Viewed = true
        },
        new TestModel
        {
            Title = "Mock Model.",
            Description = "C models description.",
            Viewed = false
        },
        new TestModel
        {
            Title = "Mock Model.",
            Description = "A models description.",
            Viewed = false
        },
        new TestModel
        {
            Title = "Mocking Model.",
            Description = "Mocking Models description.",
            Viewed = true
        },
        new TestModel
        {
            Title = "Mocking.",
            Description = "Mocking description.",
            Viewed = true
        },
    };
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Viewed { get; set; } = false;

    public TestModel()
    {
    }

    public TestModel(BaseViewModel viewModel) : base(viewModel)
    {
        if (viewModel is not TestViewModel testView) return;
        Title = testView.Title;
        Description = testView.Description;
        Viewed = testView.Viewed;
    }

    public static implicit operator TestViewModel(TestModel model) => new(model);
    public static implicit operator TestModel(TestViewModel viewModel) => new(viewModel);
}