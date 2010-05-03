using System;
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using Facebook.Entity;

namespace Facebook.WebControls
{
    /// <summary>
    /// FriendList web control to show a list of friends for a given user
    /// </summary>
    [ToolboxData("<{0}:FriendList runat=server></{0}:FriendList>")]
    public class FriendList : WebControl, IPostBackEventHandler
    {
        private Collection<User> _friends;
        private const string OUTER_DIV = "friendList";
        private const string INNER_DIV = "friendListItem";
        private const string FRIENDNAME_LABEL_DIV = "friendNameLabel";
        private const string HEADER_DIV = "friendListHeader";

        private const string VIEWSTATE_FRIENDLIST = "friendList";
        private bool _useViewState = true;

        //event to throw when the user is clicked.
        public event FriendListItemClickedEventHandler FriendClick;
        public delegate void FriendListItemClickedEventHandler(object sender, FriendListItemClickEventArgs e);

        protected virtual void OnClick(FriendListItemClickEventArgs e)
        {

            if (FriendClick != null)
            {
                FriendClick(this, e);
            }
        }
        
        /// <summary>
        /// A flag indicating whether the control should store its state in ViewState.  By default this is
        /// set to True.  If this is set to False, the host page needs to take care of keeping track of state
        /// and setting the UserProfile control's User Property with each Postback. 
        /// </summary>
        public bool UseViewState
        {
            get { return _useViewState; }
            set { _useViewState = value; }
        }
        
        /// <summary>
        /// The collection of friends that we'll show
        /// </summary>
        public Collection<User> Friends
        {
            get { return _friends; }
            set
            {
                _friends = value;
                if (UseViewState)
                {
                    ViewState[VIEWSTATE_FRIENDLIST] = _friends;
                }
            }
        }

        /// <summary>
        /// Called each time the control is loaded.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadFromViewState();
        }

        /// <summary>
        /// Loads the Facebook FriendList from ViewState.  This is used to pull back data during a Postback operation.
        /// </summary>
        private void LoadFromViewState()
        {
            object friends = ViewState[VIEWSTATE_FRIENDLIST];
            if (!object.Equals(friends, null))
            {
                _friends = (Collection<User>) friends;
            }
        }

        /// <summary>
        /// RenderContents is called by the ASP.Net framework when our control needs to render itself.  Here we
        /// will simply output our resulting HTML.
        /// </summary>
        /// <param name="output">The writer to which we will write our HTML</param>
        protected override void RenderContents(HtmlTextWriter output)
        {

            if (!Equals(_friends, null))
            {
                //Write the outer DIV tag so the page author that uses this control can 
                //specify styles based on this DIV.
                output.AddAttribute(HtmlTextWriterAttribute.Id, OUTER_DIV);
                output.RenderBeginTag(HtmlTextWriterTag.Div);

                output.AddAttribute(HtmlTextWriterAttribute.Id, HEADER_DIV);
                output.RenderBeginTag(HtmlTextWriterTag.Div);
                output.Write("Friends List");
                output.RenderEndTag();  //Header div


                if (_friends.Count == 0)
                {
                    output.Write("You have no friends.");
                }
                else if (_friends.Count == 1)
                {
                    output.Write("You have a friend!");
                }
                else
                {
                    output.Write("You have " + _friends.Count + " friends.");
                }
                
                //Loop through the list of friends, write them out
                foreach (User friend in _friends)
                {
                    //Write the inner DIV tag.  This enables finer control of any styles.
                    output.AddAttribute(HtmlTextWriterAttribute.Id, INNER_DIV);
                    output.RenderBeginTag(HtmlTextWriterTag.Div);

                    //Write out the image.
                    if (!Equals(friend.PictureUrl, null))
                    {
                        output.AddAttribute(HtmlTextWriterAttribute.Src, friend.PictureUrl.ToString());
                        output.RenderBeginTag(HtmlTextWriterTag.Img);
                        output.RenderEndTag();
                    }
                    
                    //Write out the friend name
                    output.AddAttribute(HtmlTextWriterAttribute.Id, FRIENDNAME_LABEL_DIV);
                    output.RenderBeginTag(HtmlTextWriterTag.Div);
                    
                    //Add the javascript for a postback event which will pass the User's userID as a parameter.  This
                    //is used to raise the OnClick event, which let's the page author know that the user clicked on a
                    //friend in the list.
                    output.AddAttribute(HtmlTextWriterAttribute.Href, Page.ClientScript.GetPostBackClientHyperlink(this,friend.UserId));
                    output.RenderBeginTag(HtmlTextWriterTag.A);
                    
                    output.Write(friend.Name);
                    output.Write(" (");
                    output.Write(friend.HometownLocation.City + ", " + friend.HometownLocation.StateAbbreviation);
                    output.Write(")");
                    output.RenderEndTag();      //A
                    output.RenderEndTag();      //DIV
                    output.RenderEndTag();      //DIV
                }
                output.RenderEndTag();
            }
        }

        /// <summary>
        /// Called when a Postback occurs.
        /// </summary>
        /// <param name="eventArgument">The userID of the friend that was clicked.</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnClick(new FriendListItemClickEventArgs(eventArgument));
        }
    }

    /// <summary>
    /// Custom event args class used when we throw our OnClick event.
    /// </summary>
    public class FriendListItemClickEventArgs : EventArgs
    {
        private string _friendId;

        public FriendListItemClickEventArgs(string id)
        {
            _friendId = id;
        }
        public string FriendId
        {
            get
            {
                return _friendId;
            }
        }
    }

}
