using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CraigsListScraper.Data;

namespace CraigsListScraper.Builders
{
    class ScrapeCriteriaPartBuilder
    {
        //Properties to create in the builder 
        private string _regex;
        private RegexOptions _regexOptions;

        //Constractor 
        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOptions=RegexOptions.None;
        }

        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCriteriaPartBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOptions = regexOption;
            return this;
        }
        //Builder
        public ScrapeCriteriaPart Build()
        {
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.RegexOptions = _regexOptions;
            return scrapeCriteriaPart;
        }
    }
}
