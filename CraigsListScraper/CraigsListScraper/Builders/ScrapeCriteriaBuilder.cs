using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CraigsListScraper.Data;

namespace CraigsListScraper.Builders
{
    class ScrapeCriteriaBuilder
    {
        //Fileds
        private string _data;
        private string _regex;
        private RegexOptions _regexOptions;
        private List<ScrapeCriteriaPart> _parts;

        //Constractor 
        public ScrapeCriteriaBuilder()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            _data=string.Empty;
            _regex=string.Empty;
            _regexOptions=RegexOptions.None;
            _parts=new List<ScrapeCriteriaPart>();

        }
        //Methods to mock the above properties 
        public ScrapeCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }

        public ScrapeCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCriteriaBuilder WithRegexOptions(RegexOptions regexOptions)
        {
            _regexOptions = regexOptions;
            return this;
        }

        public ScrapeCriteriaBuilder WithPart(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            //Adding to the list of parts 
            _parts.Add(scrapeCriteriaPart);
            return this;
        }
        //How to build it
        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOptions = _regexOptions;
            scrapeCriteria.Parts = _parts;
            return scrapeCriteria;
        }
    }
}
