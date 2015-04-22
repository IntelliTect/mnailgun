using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;

namespace Typesafe.Mailgun.Statistics
{
	internal class MailgunStatsQuery : MailgunQuery<MailgunStatEntry>
	{
        private readonly MailgunEventTypes eventTypes;

        public MailgunStatsQuery(IMailgunAccountInfo accountInfo, MailgunEventTypes eventTypes)
            : base(accountInfo, "stats")
		{
			this.eventTypes = eventTypes;
		}

		protected override IEnumerable<KeyValuePair<string, string>> AdditionalParameters
		{
			get
			{
                var events = Enum.GetValues(typeof(MailgunEventTypes)).OfType<MailgunEventTypes>()
					.Where(value => eventTypes.HasFlag(value))
					.Select(value => value.ToString().ToLower());

			    List<KeyValuePair<string, string>> additionalParameters = new List<KeyValuePair<string, string>>();
			    foreach (var eventType in events)
			    {
			        additionalParameters.Add(new KeyValuePair<string, string>("event", eventType));
			    }
			    return additionalParameters;
			}
		}

		public override MailgunStatEntry MapJsonItem(dynamic item)
		{
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
		    MailgunEventTypes eventType = Enum.Parse(typeof (MailgunEventTypes),
		        textInfo.ToTitleCase(item.@event.Value));
			return new MailgunStatEntry
			{
			    Count = (int) item.total_count.Value,
                Id = item.id.Value,
                EventType = eventType,
                Date = DateTime.Parse(item.created_at.Value)
			};
		}
	}
}