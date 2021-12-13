using System;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Filtering;
using CoreLibrary.Tests.RepositoryTesting;
using CoreLibrary.Tests.TestingModels;
using NUnit.Framework;

namespace CoreLibrary.Tests.FilterTesting
{
    public class FilterTests
    {
        private readonly List<TestModel> _models = new();
        private readonly IFilter<TestModel> _filter = new ModelFilter<TestModel>();
        
        
        [SetUp]
        public void Setup()
        {
            _models.AddRange(TestModel.MockModels);
        }

        [Test]
        public void TestSingleFiltering()
        {
            var viewedModels = _filter.Filter(_models, new FuncSpecification<TestModel>(a => a.Viewed));
            var notViewedModels = _filter.Filter(_models, new FuncSpecification<TestModel>(a => !a.Viewed));
            Assert.IsNotEmpty(viewedModels);
            Assert.IsNotEmpty(notViewedModels);

            var nameNoneExistent = _filter.Filter(_models,
                new FuncSpecification<TestModel>(a => new TextComparison("this does not exist", true, false).IsMatch(a.Title))).FirstOrDefault();
            Assert.IsNull(nameNoneExistent);
            var nameExistent = _filter.Filter(_models,
                new FuncSpecification<TestModel>(a => new TextComparison("Model", false).IsMatch(a.Title))).FirstOrDefault();
            Assert.IsNotNull(nameExistent);
            Assert.Pass();
        }

        [Test]
        public void TestMultipleFiltering()
        {
            var viewedModelsWithTitle = _filter.Filter(_models, new FuncSpecification<TestModel>(a =>
                    a.Viewed && new TextComparison("Model", false).IsMatch(a.Title) &&
                    new TextComparison("Mock", false).IsMatch(a.Description))).ToList();
            foreach (var testModel in viewedModelsWithTitle)
            {
                Console.WriteLine($"Model found with title Models: {testModel.Title} and Viewed");
            }
            Assert.IsNotEmpty(viewedModelsWithTitle);
            Assert.Pass();
        }
    }
}