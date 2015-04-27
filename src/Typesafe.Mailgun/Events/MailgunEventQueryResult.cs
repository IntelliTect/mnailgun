using System;
using Newtonsoft.Json;

namespace Typesafe.Mailgun.Events
{
    public class MailgunEventQueryResult
    {
        [JsonProperty( "items" )]
        public MailgunEventEntry[] MailgunEventEntries { get; set; }

        [JsonProperty( "paging" )]
        public Paging Paging { get; set; }
    }

    public class Paging
    {
        [JsonProperty( "next" )]
        public string Next { get; set; }

        [JsonProperty( "last" )]
        public string Last { get; set; }

        [JsonProperty( "first" )]
        public string First { get; set; }

        [JsonProperty( "previous" )]
        public string Previous { get; set; }
    }

    public class MailgunEventEntry : MailgunResource
    {
        [JsonProperty( "geolocation" )]
        public Geolocation Geolocation { get; set; }

        [JsonProperty( "tags" )]
        public string[] Tags { get; set; }

        [JsonProperty( "ip" )]
        public string Ip { get; set; }

        [JsonProperty( "log-level" )]
        public string LogLevel { get; set; }

        [JsonProperty( "campaigns" )]
        public object[] Campaigns { get; set; }

        [JsonProperty( "user-variables" )]
        public UserVariables UserVariables { get; set; }

        [JsonProperty( "timestamp" )]
        public string Timestamp { get; set; }

        static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime FromUnixTime(string unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(unixTimeStamp));
            return dtDateTime;
        }

        private static string ToUnixTime( DateTime dateTime )
        {
            double unixTimestamp = dateTime.Ticks - Epoch.Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp.ToString();
        }

        public DateTime Time
        {
            get { return FromUnixTime( Timestamp ); }
        }

        [JsonProperty( "client-info" )]
        public ClientInfo ClientInfo { get; set; }

        [JsonProperty( "message" )]
        public Message Message { get; set; }

        [JsonProperty( "recipient" )]
        public string Recipient { get; set; }

        [JsonProperty( "event" )]
        public string Event { get; set; }

        [JsonProperty( "delivery-status" )]
        public DeliveryStatus DeliveryStatus { get; set; }

        [JsonProperty( "envelope" )]
        public Envelope Envelope { get; set; }

        [JsonProperty( "recipient-domain" )]
        public string RecipientDomain { get; set; }

        [JsonProperty( "flags" )]
        public Flags Flags { get; set; }

        [JsonProperty( "method" )]
        public string Method { get; set; }

        [JsonProperty( "severity" )]
        public string Severity { get; set; }

        [JsonProperty( "reason" )]
        public string Reason { get; set; }

        [JsonProperty( "url" )]
        public string Url { get; set; }
    }

    public class Geolocation
    {
        [JsonProperty( "city" )]
        public string City { get; set; }

        [JsonProperty( "region" )]
        public string Region { get; set; }

        [JsonProperty( "country" )]
        public string Country { get; set; }
    }

    public class UserVariables
    {
    }

    public class ClientInfo
    {
        [JsonProperty( "client-os" )]
        public string ClientOs { get; set; }

        [JsonProperty( "device-type" )]
        public string DeviceType { get; set; }

        [JsonProperty( "client-name" )]
        public string ClientName { get; set; }

        [JsonProperty( "client-type" )]
        public string ClientType { get; set; }

        [JsonProperty( "user-agent" )]
        public string UserAgent { get; set; }
    }

    public class Message
    {
        [JsonProperty( "headers" )]
        public Headers Headers { get; set; }

        [JsonProperty( "attachments" )]
        public Attachment[] Attachments { get; set; }

        [JsonProperty( "recipients" )]
        public string[] Recipients { get; set; }

        [JsonProperty( "size" )]
        public int Size { get; set; }
    }

    public class Headers
    {
        [JsonProperty( "message-id" )]
        public string MessageId { get; set; }

        [JsonProperty( "to" )]
        public string To { get; set; }

        [JsonProperty( "from" )]
        public string From { get; set; }

        [JsonProperty( "subject" )]
        public string Subject { get; set; }
    }

    public class Attachment
    {
        [JsonProperty( "size" )]
        public int Size { get; set; }

        [JsonProperty( "content-type" )]
        public string ContentType { get; set; }

        [JsonProperty( "filename" )]
        public string FileName { get; set; }
    }

    public class DeliveryStatus
    {
        [JsonProperty( "message" )]
        public string Message { get; set; }

        [JsonProperty( "code" )]
        public int Code { get; set; }

        [JsonProperty( "description" )]
        public string Description { get; set; }

        [JsonProperty( "session-seconds" )]
        public float SessionSeconds { get; set; }

        [JsonProperty( "retry-seconds" )]
        public int RetrySeconds { get; set; }
    }

    public class Envelope
    {
        [JsonProperty( "transport" )]
        public string Transport { get; set; }

        [JsonProperty( "sender" )]
        public string Sender { get; set; }

        [JsonProperty( "sending-ip" )]
        public string SendingIp { get; set; }

        [JsonProperty( "targets" )]
        public string Targets { get; set; }
    }

    public class Flags
    {
        [JsonProperty( "is-routed" )]
        public bool? IsRouted { get; set; }

        [JsonProperty( "is-authenticated" )]
        public bool IsAuthenticated { get; set; }

        [JsonProperty( "is-systemtest" )]
        public bool IsSystemTest { get; set; }

        [JsonProperty( "is-testmode" )]
        public bool IsTestmode { get; set; }

        [JsonProperty( "is-callback" )]
        public bool IsCallback { get; set; }
    }
}