namespace Fortah.FileDirectoriser.Generic {
    public class Message {
        public MessageType Type { get; private set; }
        public string Text { get; private set; }
        public Indentation Indentation { get; set; }

        public Message(MessageType pType, string pText, Indentation? pIndentation = null) {
            this.Type = pType;
            this.Text = pText;
            this.Indentation = Indentation.Parse(pIndentation);
        }

        public override string ToString() {
            return this.Text;
        }
    }
}
