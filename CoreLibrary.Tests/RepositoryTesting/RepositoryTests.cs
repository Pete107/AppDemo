using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Filtering;
using CoreLibrary.Tests.TestingModels;
using NUnit.Framework;

namespace CoreLibrary.Tests.RepositoryTesting;

public class RepositoryTests
{
    private readonly List<TestModel> _models = new();
    private IRepository<TestModel> _repository;
    [SetUp]
    public void Setup()
    {
        _models.AddRange(TestModel.MockModels);
        _repository = new ModelRepository<TestModel>(_models);
    }


    [Test]
    public void TestRepoCRUD()
    {
        var allModels = _repository.GetAll();
        Assert.AreEqual(allModels.Count(), _models.Count);

        var newModel = new TestModel
        {
            Title = "New Model",
            Description = "Run time created in tests.",
            Viewed = false
        };
        Assert.DoesNotThrow(() =>_repository.Add(newModel));
        var modelJustCreated =
            _repository.Find(new FuncSpecification<TestModel>(a =>
                new TextComparison("New Model", true, false).IsMatch(a.Title)));
        Assert.IsNotNull(modelJustCreated, "Unable to find Created Model");
        if (modelJustCreated is null)
        {
            Assert.Fail("Could not process testing any further.");
            return;
        }
        
        modelJustCreated.Title = "Not so new Model";
        Assert.DoesNotThrow(() => _repository.Update(modelJustCreated));

        var updatedModel = _repository.Get(modelJustCreated.Id);
        Assert.IsNotNull(updatedModel);

        if (updatedModel is null)
        {
            Assert.Fail();
            return;
        }
        Assert.DoesNotThrow(() => _repository.Delete(updatedModel));
        var deletedModel = _repository.Get(updatedModel.Id);
        Assert.IsNull(deletedModel);
        if (deletedModel is not null)
        {
            Assert.Fail();
            return;
        }
        Assert.Pass();
    }
}