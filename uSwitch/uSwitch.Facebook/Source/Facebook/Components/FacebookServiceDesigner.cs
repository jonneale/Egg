using System.ComponentModel;
using System.ComponentModel.Design;

namespace Facebook.Components
{
    class FacebookServiceDesigner : ComponentDesigner
    {
        DesignerActionListCollection _dalc;
        public FacebookServiceDesigner()
        { }

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (this._dalc == null)
                {
                    this._dalc = new DesignerActionListCollection();
                    this._dalc.Add(new FacebookServiceDesignerActionList(this.Component));
                }

                return _dalc;
            }
        }

    }

    public class FacebookServiceDesignerActionList : DesignerActionList
    {

        public FacebookServiceDesignerActionList(IComponent component) : base(component)
        { }
        [Category("Setup")]
        [Description("The API key received from facebook for this application that is using the FacebookService component")]
        [DisplayName("API Key")]
        public string ApplicationKey
        {
            get { return this.FacebookService.ApplicationKey; }
            set { this.SetProperty("ApplicationKey", value); }
        }
        [Category("Setup")]
        [Description("The secret received from facebook for this application that is using the FacebookService component")]
        public string Secret
        {
            get { return this.FacebookService.Secret; }
            set { this.SetProperty("Secret", value); }
        }
        private FacebookService FacebookService
        {
            get { return (FacebookService)this.Component;  }
        }
        private void SetProperty(string propertyName, object value)
        {
            PropertyDescriptor property = TypeDescriptor.GetProperties(this.FacebookService)[propertyName];
            property.SetValue(this.FacebookService, value);
        }
    }
}
