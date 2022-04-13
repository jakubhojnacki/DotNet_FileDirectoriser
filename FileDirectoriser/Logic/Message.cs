namespace FileDirectoriser {
    public class Message {
        public MessageType Type { get; }
        public string Text { get; }

        public Message(string pText) : this(MessageType.Information, pText) {
        }

        public Message(MessageType pType, string pText) {
            this.Type = pType;
            this.Text = pText;
        }

        public override string ToString() {
            return this.Text;
        }
    }
}
