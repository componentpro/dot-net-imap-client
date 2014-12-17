using ComponentPro.Net.Mail;

namespace ImapClient
{
    /// <summary>
    /// Contains information for a message such as Sequence Number, Unique Id, Date time, message length.
    /// </summary>
    public class ListItemTagInfo
    {
        private readonly string _uniqueId;
        private readonly int _sequenceNumber;
        private readonly MailDateTime _dateTime;
        private readonly long _length;

        public ListItemTagInfo(int sequenceNumber, string uniqueId, MailDateTime dateTime, long length)
        {
            _sequenceNumber = sequenceNumber;
            _uniqueId = uniqueId;
            _dateTime = dateTime;
            _length = length;
        }

        public int SequenceNumber
        {
            get { return _sequenceNumber; } 
        }

        public string UniqueId
        {
            get { return _uniqueId; }
        }

        public MailDateTime DateTime
        {
            get { return _dateTime; }
        }

        public long Length
        {
            get { return _length; }
        }
    }
}
