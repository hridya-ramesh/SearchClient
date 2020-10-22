using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchWithHttpClient.Controllers;
using SearchWithHttpClient.Services;
using SearchWithHttpClient.Services.Interface;


namespace SearchWithHttpClient.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        private SearchController _searchController;
        private ISearchService iSearchService;
        public UnitTest1()
        {
            _searchController = new SearchController(iSearchService);
            iSearchService = new SearchService();
        }
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            string searchKey = "Online Title Search";
            string searchUrl = "www.infotrack.com";
            //act
            var actionResult = iSearchService.SearchKeyWord(searchKey, searchUrl) ;
            //assert
           //Assert.Equals("1", actionResult.Result);
        }
    }
}
