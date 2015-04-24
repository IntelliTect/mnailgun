using System.Net;

namespace Typesafe.Mailgun.Routing
{
	internal class CreateRouteCommandResult : CommandResult
	{
		public CreateRouteCommandResult(string message, Route route, HttpStatusCode statusCode) : base(message, statusCode)
		{
			Route = route;
		}

		public Route Route { get; private set; }
	}
}