require 'crawler.rb'
require 'scrapper.rb'
require 'urlfilter.rb'

puts 'beginning crawl'

crawler = Crawler.new('http://www.livenation.co.uk/', Scrapper.new, UrlFilter.new)
crawler.begin()