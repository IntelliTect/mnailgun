namespace Typesafe.Mailgun.Tests
{
	public static class MailgunClientBuilder
	{
        public static MailgunClient GetClient(string domain = "sandboxc47a1a89935d424ea0427462fc328275.mailgun.org")
		{
            return new MailgunClient(domain, "key-587808545ca6bbed27d9f8ed584bcba5");
		}
	}
}