using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CraigsListScraper.Data;

namespace CraigsListScraper.Workers
{
    class Scraper
    {
        //Method that will return a list of Strings 
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            //List with all scrapped elements
            List<string>srapedElements=new List<string>();

            //Performs matching operations
            MatchCollection matches = Regex.Matches(scrapeCriteria.Data,scrapeCriteria.Regex,scrapeCriteria.RegexOptions);

            foreach (Match match in matches )
            {
                //if No parts add that match to scrapped elements 
                if (!scrapeCriteria.Parts.Any())
                {
                    //First group has matched element 
                    srapedElements.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scrapeCriteria.Parts)
                    {
                        //Grabbing certian parts from the element 
                        Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOptions);

                        if (matchedPart.Success) srapedElements.Add(matchedPart.Groups[1].Value);
                    }
                }
                
            }

            return srapedElements;
        }
    }
}
