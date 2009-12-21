using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.Selenium.Domain.Model
{
    public class BrowserSetup
    {
        private string _profile;
        private Uri _baseUrl;

        public Uri BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }

        public string Profile
        {
            get
            {
                return _profile;
            }
        }

        public BrowserSetup(string profile, Uri baseUrl)
        {
            _profile = profile;
            _baseUrl = baseUrl;
        }
    }
}
