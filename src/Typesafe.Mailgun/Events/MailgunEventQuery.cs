using System;
using System.Collections.Generic;
using System.Linq;

namespace Typesafe.Mailgun.Events
{
    internal class MailgunEventQuery : MailgunQuery<MailgunEventEntry>
    {
        private static readonly DateTime Epoch = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );
        private readonly MailgunEventType _EventTypes;

        public MailgunEventQuery( IMailgunAccountInfo accountInfo,
                MailgunEventType eventTypes,
                DateTime beginTime,
                DateTime endTime,
                bool ascending,
                int limit )
                : base( accountInfo, "events" )
        {
            if ( limit > 300 )
            {
                throw new ArgumentOutOfRangeException( "limit", "Must be less than or equal to 300" );
            }

            BeginTime = beginTime;
            EndTime = endTime;
            Ascending = ascending;
            Limit = limit;
            _EventTypes = eventTypes;
        }

        protected override IEnumerable<KeyValuePair<string, string>> AdditionalParameters
        {
            get
            {
                var events = Enum.GetValues( typeof (MailgunEventType) ).OfType<MailgunEventType>()
                        .Where( value => _EventTypes.HasFlag( value ) )
                        .Select( value => value.ToString().ToLower() );

                var additionalParameters = new List<KeyValuePair<string, string>>();
                additionalParameters.Add( new KeyValuePair<string, string>( "event", string.Join( " OR ", events ) ) );

                
                /*foreach ( var eventType in events )
                {
                    string.Join(" OR ", events)
                    additionalParameters.Add( new KeyValuePair<string, string>( "event", eventType ) );
                }*/

                additionalParameters.Add( new KeyValuePair<string, string>( "begin", ToUnixTime( BeginTime ) ) );
                additionalParameters.Add( new KeyValuePair<string, string>( "end", ToUnixTime( EndTime ) ) );
                additionalParameters.Add( new KeyValuePair<string, string>( "ascending", Ascending ? "yes" : "no" ) );
                additionalParameters.Add( new KeyValuePair<string, string>( "limit", Limit.ToString() ) );
                return additionalParameters;
            }
        }

        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Ascending { get; set; }
        public int Limit { get; set; }

        private static string ToUnixTime( DateTime dateTime )
        {
            var unixTimestamp = dateTime.Ticks - Epoch.Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp.ToString();
        }

        public override MailgunEventEntry MapJsonItem( dynamic item )
        {
            throw new NotImplementedException();
        }
    }
}