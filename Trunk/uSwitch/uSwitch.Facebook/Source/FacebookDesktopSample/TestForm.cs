using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using Facebook.Controls;
using Facebook.Entity;
using FacebookDesktopSample.Properties;

namespace FacebookDesktopSample
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
            this.facebookService1.ApplicationKey = Settings.Default.api_key;
            this.facebookService1.Secret = Settings.Default.secret;

        }

        private void OnLoad()
        {
            ListenToEvents(true);
            try
            {
                Collection<User> friends = facebookService1.GetFriends();
                Collection<FacebookEvent> events = facebookService1.GetEvents();
                Notifications n = facebookService1.GetNotifications();
                User me = facebookService1.GetUserInfo();
                facebookService1.CreateAlbum("test", "test", "test");
                //Load friend map
                friendMap1.Friends = friends;

                friendList1.Friends = friends;
                photoAlbum1.FacebookService = facebookService1;

                //load friend profile
                if (friends.Count > 0)
                {
                    LoadUserBasedControls(friends[0]);
                }

                eventList1.FacebookEvents = events;
                if (events.Count > 0)
                {
                    LoadEventBasedControls(events[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }

        }

        private void ListenToEvents(bool listen)
        {
            if (listen)
            {
                friendList1.FriendSelected += new EventHandler<FriendSelectedEventArgs>(friendList1_FriendSelected);
                eventList1.EventSelected += new EventHandler<EventSelectedEventArgs>(eventList1_EventSelected);
            }
        }

        private void LoadUserBasedControls(User user)
        {
            profile1.User = user;
            photoAlbum1.Albums = facebookService1.GetPhotoAlbums(user.UserId);
        }
        private void LoadEventBasedControls(FacebookEvent facebookEvent)
        {
            inviteeList1.FacebookEvent = facebookEvent;
            inviteeList1.Invitees = facebookService1.GetEventMembers(facebookEvent.EventId);
        }

        void friendList1_FriendSelected(object sender, FriendSelectedEventArgs e)
        {
            LoadUserBasedControls(e.User);
        }
        void eventList1_EventSelected(object sender, EventSelectedEventArgs e)
        {
            LoadEventBasedControls(e.FacebookEvent);
        }


        private void TestForm_Load(object sender, EventArgs e)
        {
            OnLoad();
        }
    }
}
