using System.Net;

namespace Typesafe.Mailgun
{
	public class SendMailCommandResult : CommandResult
	{
		public SendMailCommandResult(string id, string message, HttpStatusCode statusCode) : base(message, statusCode)
		{
			Id = id;
		}

		public string Id { get; set; }
	}
}