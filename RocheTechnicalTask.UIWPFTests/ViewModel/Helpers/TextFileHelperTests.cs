using Microsoft.VisualStudio.TestTools.UnitTesting;
using RocheTechnicalTask.UIWPF.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocheTechnicalTask.UIWPF.ViewModel.Helpers.Tests
{
    [TestClass()]
    public class TextFileHelperTests
    {
        [TestMethod()]
        public async Task GetTextFilesTestString()
        {
            ConfigurationManager.AppSettings["urlBase"] = "http://localhost:80";
            var result = await RocheTechnicalTask.UIWPF.ViewModel.Helpers.TextFileHelper.GetTextFiles("a");
            Assert.IsNotNull(result.Count > 0);
        }

        
        [TestMethod()]
        public async Task GetTextFilesTestEmptyString()
        {
            ConfigurationManager.AppSettings["urlBase"] = "http://localhost:80";
            var result = await RocheTechnicalTask.UIWPF.ViewModel.Helpers.TextFileHelper.GetTextFiles("");
            Assert.IsTrue(result.Count==0);
        }

        [TestMethod()]
        public async Task GetTextFilesTestBlankSpace()
        {
            ConfigurationManager.AppSettings["urlBase"] = "http://localhost:80";
            var result = await RocheTechnicalTask.UIWPF.ViewModel.Helpers.TextFileHelper.GetTextFiles(" ");
            Assert.IsTrue(result.Count == 0);
        }
    }
}