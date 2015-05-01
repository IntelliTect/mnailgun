using System;
using System.Collections.Generic;
using System.Net.Mail;
using Typesafe.Mailgun.Events;
using Typesafe.Mailgun.Mailboxes;
using Typesafe.Mailgun.Routing;
using Typesafe.Mailgun.Statistics;

namespace Typesafe.Mailgun
{
	/// <summary>
	/// Provides access to the Mailgun REST API.
	/// </summary>
	public interface IMailgunClient
	{
		/// <summary>
		/// Sends email through the mailgun client.
		/// </summary>
		/// <param name="mailMessage"></param>
		/// <returns></returns>
		SendMailCommandResult SendMail(MailMessage mailMessage);

	    SendMailCommandResult SendMail( MailMessage mailMessage, List<string> tags );

		IEnumerable<Route> GetRoutes(int skip, int take, out int count);

		Route CreateRoute(int priority, string description, RouteFilter expression, params RouteAction[] actions);

		CommandResult DeleteRoute(string routeId);

        IEnumerable<MailgunStatEntry> GetStats(int skip, int take, MailgunEventTypes eventTypes, out int count);

        IEnumerable<MailgunEventEntry> GetEvents(MailgunEventType eventTypes, DateTimeOffset beginTime, DateTimeOffset endTime,
	        bool ascending, int limit);


		CommandResult CreateMailbox(string name, string password);

		CommandResult DeleteMailbox(string name);

		IEnumerable<Mailbox> GetMailboxes(int skip, int take, out int count);

	    CommandResult DeleteBounce(string address);

	    CommandResult DeleteUnsubscribe(string address);

	    CommandResult DeleteComplaint(string address);
	}
}