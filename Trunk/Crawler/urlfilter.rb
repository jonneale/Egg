class UrlFilter
  def filter_list(url_array)
    valid_urls = Array.new

    url_array.each do | url |
      if (!(url.include? "http://" or url == "#"))
        valid_urls << url
    end

    return valid_urls;
  end
end