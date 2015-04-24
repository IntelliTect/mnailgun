using System.Net;
using System.Net.Mail;
using NUnit.Framework;
using Typesafe.Mailgun.Routing;

namespace Typesafe.Mailgun.Tests.Routing
{
	[TestFixture]
	public class When_deleting_a_complaint
	{
		[Test]
		public void delete_complaint_expect_success()
		{
            var result = MailgunClientBuilder.GetClient("sandboxc47a1a89935d424ea0427462fc328275.mailgun.org").DeleteComplaint("jaspet@microsoft.com");

			Assert.IsNotNull(result);
			Assert.IsNotNullOrEmpty(result.Message);
            Assert.AreEqual(result.Message, "Spam complaint has been removed");
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
		}
	}
}
