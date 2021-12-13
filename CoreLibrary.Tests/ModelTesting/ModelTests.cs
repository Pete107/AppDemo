using System;
using CoreLibrary.Data;
using CoreLibrary.DataTransfer;
using CoreLibrary.Tests.TestingModels;
using NUnit.Framework;

namespace CoreLibrary.Tests.ModelTesting;

public class ModelTests
{
    private TestModel _mainModel, _testModel;
    private TestViewModel _mainViewModel, _testViewModel;
    [SetUp]
    public void Setup()
    {
        _mainModel = new()
        {
            Title = "Test Model",
            Description = "Description",
            Viewed = false
        };
        _mainViewModel = new()
        {
            Title = "Test View Model",
            Description = "Descriptive Text",
            Viewed = true
        };
    }

    [Test]
    public void TestModelToViewModel()
    {
        Assert.DoesNotThrow(() => _testViewModel = _mainModel);
        Assert.AreEqual(_mainModel.Id, _testViewModel.Id);
        Assert.Pass();
    }

    [Test]
    public void TestViewModelToModel()
    {
        Assert.DoesNotThrow(() => _testModel = _mainViewModel);
        Assert.AreEqual(_mainViewModel.Id, _testModel.Id);
        Assert.Pass();
    }

    [Test]
    public void TestSerialization()
    {
        #region Request Serialization

        ModelRequest<TestViewModel>? reqContent = null;
        //Convert to Request Model
        Assert.DoesNotThrow(() => reqContent = _mainViewModel.ToModelRequest());
        Assert.IsNotNull(reqContent);
        if (reqContent is null)
        {
            Assert.Fail();
            return;
        }
        //Serialize Request Model
        var serializedReq = reqContent.Serialize();
        Assert.IsNotEmpty(serializedReq);
        Console.WriteLine(serializedReq);
        //Deserialize content
        var deserialziedReq = serializedReq.DeserializeRequest<TestViewModel>();
        Assert.IsNotNull(deserialziedReq);
        if (deserialziedReq is null)
        {
            Assert.Fail();
            return;
        }
        //Check the Ids match one another
        Assert.AreEqual(reqContent.Model.Id, deserialziedReq.Model.Id);

        #endregion

        #region Response Serialization

        ModelResponse<TestViewModel>? resCotntent = null;
        Assert.DoesNotThrow(() => resCotntent = _mainViewModel.ToModelResponse());
        Assert.IsNotNull(resCotntent);
        if (resCotntent is null)
        {
            Assert.Fail();
            return;
        }

        var serializedRes = resCotntent.Serialize();
        Assert.IsNotEmpty(serializedRes);
        Console.WriteLine(serializedRes);
        var deserialziedRes = serializedRes.DeserializeResponse<TestViewModel>();
        Assert.IsNotNull(deserialziedRes);
        if (deserialziedRes is null)
        {
            Assert.Fail();
            return;
        }
        Assert.AreEqual(resCotntent.Model.Id, deserialziedRes.Model.Id);

        #endregion

        Assert.Pass();
    }
}