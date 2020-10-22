using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SearchWithHttpClient.Models
{
    public class SearchModel
    {
        [Required(ErrorMessage = "Search Key is required.")]
        [Display(Name = "Search Key")]
        public string SearchKey { get; set; }
        [Required(ErrorMessage = "Search Url is required.")]
        [Display(Name = "Search Url")]
        public string SearchUrl { get; set; }
        public  string Occurence { get; set; }
    }
}