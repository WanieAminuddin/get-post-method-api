using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.ServiceModel;
using LinkedInOauth.Models;
using ServiceClass;


namespace LinkedInOauth
{

    public partial class LoginWindow : Window
    {
        ServiceHost host;
        person profile = new person();
        bool btnStartStop;
        bool logging;
        string BasicProfile;

        private OAuthLinkedIn _oauth = new OAuthLinkedIn();


        public LoginWindow()
        {
            InitializeComponent();
            btnStartStop = true;
            logging = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (logging)
            {
                linkedinService LS = new linkedinService();
                _oauth.getRequestToken();
                _oauth.authorizeToken();
                _oauth.getAccessToken();

                btnLogin.Content = "Success";
                btnLogin.IsEnabled = false;

                BasicProfile = _oauth.APIWebRequest("GET", "https://api.linkedin.com/v1/people/~:(id,first-name,last-name,headline,picture-url,num-connections,summary,positions,location)", null);

                
                XmlSerializer serializer = new XmlSerializer(typeof(person));
                XmlReader reader = XmlReader.Create(new StringReader(BasicProfile));
                profile = (person)serializer.Deserialize(reader);
                Name.Text += profile.FName + " " + profile.LName;
                Position.Text += profile.headline;
                Summary.Text = profile.summary;
                NConnections.Text = profile.connections.ToString();
                Location.Text = profile.location.name;

                Uri imageUri = new Uri(profile.imageurl, UriKind.Absolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                myImage.Source = imageBitmap;

                LS.getstring(BasicProfile);
            }
            logging = !logging;
        }

        public void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= TextBox_GotFocus;
        }
        //<service>
        private void btnHost_Click(object sender, RoutedEventArgs e)
        {
            if (btnStartStop)
            {
                host = new ServiceHost(typeof(linkedinService));
                host.Open();
                btnHost.Content = "STOP";
            }
            else
            {
                host.Close();
                btnHost.Content = "Host and Send XML";
            }
            btnStartStop = !btnStartStop;
        }

        private void btnPost_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><share>";
                xml += "<comment>" + Status.Text + "</comment><visibility><code>anyone</code></visibility></share>";

                string response = _oauth.APIWebRequest("POST", "http://api.linkedin.com/v1/people/~/shares", xml);
                if (response == "")
                {
                    Status.Clear();
                    Status.Text += "\nYour new status updated.  view linkedin for status.";
                }            
            }
            catch (Exception exp)
            {
                Status.Clear();
                Status.Text += "\nException: " + exp.Message;
            }
        }
        //</service>
    }
}
