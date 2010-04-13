require 'open-uri'

class Scrapper
  def scrap(url)
    connection = open(url)
    content = connection.read
    return content;
  end
end