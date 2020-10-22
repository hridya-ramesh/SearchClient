using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SearchWithHttpClient.Models;
using SearchWithHttpClient.Services.Interface;

namespace SearchWithHttpClient.Controllers
{
    public class SearchController : Controller
    {
        private ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Search event Method
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Search( SearchModel searchModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    searchModel.Occurence = this._searchService.SearchKeyWord(searchModel.SearchKey, searchModel.SearchUrl).Result;
                    return View("Index",searchModel);
                }
                return View();
            }
            catch
            {
                return View();
            }
         
        }
    }
}