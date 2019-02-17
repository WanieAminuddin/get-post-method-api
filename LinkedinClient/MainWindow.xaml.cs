using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using LinkedinClient.LService;
using LinkedInOauth.Models;


namespace LinkedinClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        linkedinServicedataClient client = new linkedinServicedataClient();
        string xmlprofile;
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void btnGetProfile_Click(object sender, RoutedEventArgs e)
        {
            summary.Text += client.linkedinProfile();
            xmlprofile = summary.Text;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            person profile = new person();
            XmlSerializer serializer = new XmlSerializer(typeof(person));
            XmlReader reader = XmlReader.Create(new StringReader(xmlprofile));
            profile = (person)serializer.Deserialize(reader);

            profileBox.Text += System.Environment.NewLine + "Name   :   " + profile.FName + " " + profile.LName;
            profileBox.Text += System.Environment.NewLine + "Location   :   " +  profile.location.name;
            profileBox.Text += System.Environment.NewLine + "Position   :   " + profile.headline;
            profileBox.Text += System.Environment.NewLine + "No. of Connections :   " + profile.connections.ToString();
            profileBox.Text += System.Environment.NewLine + "Summary    :   " + profile.summary;
            
            
        }
    }
}
