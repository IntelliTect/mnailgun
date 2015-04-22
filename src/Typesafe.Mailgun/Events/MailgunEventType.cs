using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Typesafe.Mailgun.Events
{
    [Flags]
    public enum MailgunEventType
    {
        Accepted = 0x1,
        Rejected = 0x2,
        Delivered = 0x4,
        Failed = 0x8,
        Opened = 0x10,
        Clicked = 0x20,
        Unsubscribed = 0x40,
        Complained = 0x80,
        Stored = 0x100
    }
}
