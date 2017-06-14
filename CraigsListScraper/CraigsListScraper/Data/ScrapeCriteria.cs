using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CraigsListScraper.Data
{
    class ScrapeCriteria
    {
        //Constractor 
        public ScrapeCriteria()
        {
            //Initialize the list here 
            //ScrapeCriteria has a list of parts 
            Parts = new List<ScrapeCriteriaPart>();
        }
        //properties
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOptions { get; set; }
        public  List<ScrapeCriteriaPart> Parts { get; set; }
    }
}
