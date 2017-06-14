# CraigslistScraper
simple scraper. needs few more touches 
CraigsListCity = ask user for input 
CraigsListCategory = ask user for input
if CraigsListCity and CraigsListCategory are valid then download specified CraigsList listing contents
	grab a specified HTML element based on regular expression
		for each matched HTML element in matched HTML elements
			if no specified HTML parts then  
				add matched HTML element to scraped items list
			otherwise
				for each HTML part in specified HTML parts
					grab specified HTML part from matched HTML element based on regular expression 
					if match found then add matched HTML part to scraped items list
otherwise show warning
if scraped item list is not empty then display scraped HTML elements/parts
otherwise show no matches
