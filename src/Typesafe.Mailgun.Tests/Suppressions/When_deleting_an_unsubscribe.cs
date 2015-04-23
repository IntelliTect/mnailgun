using System.Net.Mail;
using NUnit.Framework;
using Typesafe.Mailgun.Routing;

namespace Typesafe.Mailgun.Tests.Routing
{
	[TestFixture]
	public class When_deleting_an_unsubscribe
	{
		[Test]
		public void delete_unsubscribe_expect_success()
		{
            var result = MailgunClientBuilder.GetClient("sandboxc47a1a89935d424ea0427462fc328275.mailgun.org").DeleteUnsubscribe("jaspet@microsoft.com");

			Assert.IsNotNull(result);
			Assert.IsNotNullOrEmpty(result.Message);
            Assert.AreEqual(result.Message, "Unsubscribe event has been removed");
		}
	}
}
