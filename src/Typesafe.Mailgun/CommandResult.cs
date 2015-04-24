using System.Net;

namespace Typesafe.Mailgun
{
	/// <summary>
	/// 
	/// </summary>
	public class CommandResult
	{
		public CommandResult(string message, HttpStatusCode statusCode)
		{
			Message = message;
		    StatusCode = statusCode;
		}

		public string Message { get; private set; }

		public override string ToString() { return Message; }

        public HttpStatusCode StatusCode { get; private set; }
	}
}