class Crawler
  attr_accessor :base_url
  @@href_regex = /<a.*href="([\/a-zA-Z\.?#&-]+)"\s*.*?\s*>/i

  def initialize(base_url, scrapper, filter)
    @base_url = base_url
    @scrapper = scrapper
    @filter = filter
  end

  def begin
    content = @scrapper.scrap(@base_url)

    href_links_found = content.scan @@href_regex
    valid_links = @filter.filter_list(href_links_found)

    puts "The total links found are #{href_links_found.length}"

    valid_links.to_a.each do | match_href |
      puts match_href
    end
  end
end