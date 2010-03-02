require 'open-uri'

class Scrapper
  def scrap
    url = "http://www.google.com/"
    connection = open(url)
    content = connection.read
    return content;
  end
end