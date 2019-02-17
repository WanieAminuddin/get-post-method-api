# Standalone LinkedIn App

Features LinkedIn profile and status update using POST method. Windows Communication Foundation (WCF) is integrated to create a service and able to send the signin profile remotely to client.

# How to run the codes

1. Get the consumer key and consumer secret by registering your app to https://www.linkedin.com/developers/
2. Once you obtain all the information, add it to the line of codes at 'oAuthLinkedIn.cs' under the 'oAuth folder'

                          private string _consumerKey = "YOUR CONSUMER KEY";
                          private string _consumerSecret = "YOUR CONSUMER SECRET";
                          public const string CALLBACK = "YOUR URL CALLBACK";

# Windows Communication Foundation (WCF)

Run the Client side code to get the user profile remotely when service is hosted.




