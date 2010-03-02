class Crawler
  attr_accessor :base_url

  def initialize(base_url, scrapper)
    @base_url = base_url
    @scrapper = scrapper
  end

  def begin
      @scrapper.scrap()
  end
end