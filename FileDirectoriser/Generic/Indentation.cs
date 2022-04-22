namespace Fortah.FileDirectoriser.Generic {
    public class Indentation {
        public int Value { get; protected set; }

        public Indentation() {
            this.Value = 0;
        }

        public Indentation(int pValue) {
            this.Value = pValue;
        }

        public static Indentation Parse(Indentation? pIndentation) {
            return pIndentation != null ? pIndentation : new Indentation();
        }

        public static Indentation Plus(Indentation? pIndentation) {
            return new Indentation(Indentation.Parse(pIndentation).Value + 1);
        }

        public static Indentation Minus(Indentation? pIndentation) {
            return new Indentation(Indentation.Parse(pIndentation).Value - 1);
        }
    }
}
