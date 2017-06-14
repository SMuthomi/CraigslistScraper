using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CraigsListScraper.Data
{
    //Part on ScrapeCriteria Created 
    class ScrapeCriteriaPart
    {
        //Properties 
        public string Regex { get; set; }
        public RegexOptions RegexOptions { get; set; }
    }
}
