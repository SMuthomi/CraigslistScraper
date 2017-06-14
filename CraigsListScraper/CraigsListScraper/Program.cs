using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CraigsListScraper.Builders;
using CraigsListScraper.Data;
using CraigsListScraper.Workers;

namespace CraigsListScraper
{
    class Program
    {
        private const string Method = "search";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(Constants.EnterCityYouLikeToScrape);
                var craigslistCity = Console.ReadLine() ?? string.Empty;


                Console.WriteLine(Constants.EnterCraigsListCategory);
                var craigslistCategoryName = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    //use to download the content of the page 
                    string content =
                        client.DownloadString(
                            $"https://{craigslistCity.Replace(" ", string.Empty)}.craigslist.org/{Method}/{craigslistCategoryName}"); 

                    //Stracture of scrape Criteria
                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                        .WithData(content)
                        .WithRegex(@"<a href=\""(.*?)\""data-id=\""(.*?)\""class=\""result-title hdrlnk\"">(.*?)</a>")
                        .WithRegexOptions(RegexOptions.ExplicitCapture)
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@">(.*?)</a>")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .WithPart(new ScrapeCriteriaPartBuilder()
                            .WithRegex(@"href=\""(.*?)\""")
                            .WithRegexOption(RegexOptions.Singleline)
                            .Build())
                        .Build();

                    //Scrape whole thing 
                    Scraper scraper = new Scraper();

                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                        {
                            string path =
                                @"C:\Users\steve\Desktop\Githhub\CraigsListScraper\CraigsListScraper\bin\Debug\scraped.txt";
                            if (!File.Exists(path))
                            {
                                File.Create(path);
                                TextWriter tw = new StreamWriter(path);
                                tw.WriteLine(scrapedElement);
                                tw.Close();
                            }
                            else
                            {
                                TextWriter tw = new StreamWriter(path, true);
                                tw.WriteLine(scrapedElement);
                                tw.Close();
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine(Constants.NoMatchesForScrapedCriteria);
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}