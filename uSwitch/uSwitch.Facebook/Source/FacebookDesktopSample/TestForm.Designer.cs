using System.Windows.Forms;
namespace FacebookDesktopSample
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.inviteeList1 = new Facebook.Controls.InviteeList();
            this.eventList1 = new Facebook.Controls.EventList();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.friendMap1 = new Facebook.Controls.FriendMap();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.photoAlbum1 = new Facebook.Controls.PhotoAlbum();
            this.friendList1 = new Facebook.Controls.FriendList();
            this.profile1 = new Facebook.Controls.Profile();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.facebookService1 = new Facebook.Components.FacebookService(this.components);
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.inviteeList1);
            this.tabPage4.Controls.Add(this.eventList1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1020, 641);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Events";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // inviteeList1
            // 
            this.inviteeList1.AutoScroll = true;
            this.inviteeList1.BackColor = System.Drawing.Color.White;
            this.inviteeList1.FacebookEvent = null;
            this.inviteeList1.Invitees = null;
            this.inviteeList1.Location = new System.Drawing.Point(375, 15);
            this.inviteeList1.Name = "inviteeList1";
            this.inviteeList1.Size = new System.Drawing.Size(425, 581);
            this.inviteeList1.TabIndex = 1;
            // 
            // eventList1
            // 
            this.eventList1.AutoScroll = true;
            this.eventList1.BackColor = System.Drawing.Color.White;
            this.eventList1.FacebookEvents = null;
            this.eventList1.Location = new System.Drawing.Point(16, 15);
            this.eventList1.Name = "eventList1";
            this.eventList1.Size = new System.Drawing.Size(353, 581);
            this.eventList1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.friendMap1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1020, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Friend Map";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // friendMap1
            // 
            this.friendMap1.BackColor = System.Drawing.Color.White;
            this.friendMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendMap1.Friends = null;
            this.friendMap1.Location = new System.Drawing.Point(3, 3);
            this.friendMap1.Name = "friendMap1";
            this.friendMap1.Size = new System.Drawing.Size(1014, 635);
            this.friendMap1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.photoAlbum1);
            this.tabPage1.Controls.Add(this.friendList1);
            this.tabPage1.Controls.Add(this.profile1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1020, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Friends";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // photoAlbum1
            // 
            this.photoAlbum1.Albums = null;
            this.photoAlbum1.BackColor = System.Drawing.Color.White;
            this.photoAlbum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.photoAlbum1.FacebookService = null;
            this.photoAlbum1.Location = new System.Drawing.Point(702, 326);
            this.photoAlbum1.Name = "photoAlbum1";
            this.photoAlbum1.Size = new System.Drawing.Size(310, 260);
            this.photoAlbum1.TabIndex = 2;
            // 
            // friendList1
            // 
            this.friendList1.AutoScroll = true;
            this.friendList1.BackColor = System.Drawing.Color.White;
            this.friendList1.Friends = null;
            this.friendList1.Location = new System.Drawing.Point(6, 6);
            this.friendList1.Name = "friendList1";
            this.friendList1.Size = new System.Drawing.Size(445, 580);
            this.friendList1.TabIndex = 1;
            // 
            // profile1
            // 
            this.profile1.BackColor = System.Drawing.Color.White;
            this.profile1.Location = new System.Drawing.Point(699, 6);
            this.profile1.Name = "profile1";
            this.profile1.Size = new System.Drawing.Size(347, 314);
            this.profile1.TabIndex = 0;
            this.profile1.User = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1028, 667);
            this.tabControl1.TabIndex = 0;
            // 
            // facebookService1
            // 
            this.facebookService1.ApplicationKey = "";
            this.facebookService1.IsDesktopApplication = true;
            this.facebookService1.Secret = "";
            this.facebookService1.SessionKey = null;
            this.facebookService1.UserId = null;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 667);
            this.Controls.Add(this.tabControl1);
            this.Name = "TestForm";
            this.Text = "Facebook Test Application";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage tabPage4;
        private Facebook.Controls.InviteeList inviteeList1;
        private Facebook.Controls.EventList eventList1;
        private TabPage tabPage2;
        private Facebook.Controls.FriendMap friendMap1;
        private TabPage tabPage1;
        private Facebook.Controls.PhotoAlbum photoAlbum1;
        private Facebook.Controls.FriendList friendList1;
        private Facebook.Controls.Profile profile1;
        private System.Windows.Forms.TabControl tabControl1;
        private Facebook.Components.FacebookService facebookService1;
    }
}
