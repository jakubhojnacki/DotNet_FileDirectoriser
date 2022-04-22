using Fortah.FileDirectoriser.Generic;

namespace Fortah.FileDirectoriser.Toolkits {
    public static class StringToolkit {
        public static string Indent(string pText, int? pIndentation = null, int? pTabSize = 2) {
            int TabSize = pTabSize != null ? pTabSize.Value : 2;
            string PrefixText = ((pIndentation != null) && (pIndentation > 0)) ? new string(' ', pIndentation.Value * TabSize) : string.Empty;
            return PrefixText + pText;
        }
        
        public static string Indent(string pText, Indentation? pIndentation = null) {
            return StringToolkit.Indent(pText, Indentation.Parse(pIndentation).Value);
        }

        public static string NonNull(string? pText1, string? pText2 = null) {
            return pText1 != null ? pText1 : (pText2 != null ? pText2 : string.Empty);
        }

        public static string Concatenate(string? pText1, string? pText2, string? pSeparator = " ") {
            string Text1Fixed = !string.IsNullOrEmpty(pText1) ? pText1 : "";
            string Text2Fixed = !string.IsNullOrEmpty(pText2) ? pText2 : "";
            string SeparatorFixed = !string.IsNullOrEmpty(pSeparator) ? pSeparator : string.Empty;
            if (SeparatorFixed.Length > 0) {
                if (Text1Fixed.EndsWith(SeparatorFixed))
                    if (Text1Fixed.Length > SeparatorFixed.Length)
                        Text1Fixed = Text1Fixed.Substring(0, Text1Fixed.Length - SeparatorFixed.Length);
                    else
                        Text1Fixed = string.Empty;
                if (Text2Fixed.StartsWith(SeparatorFixed))
                    if (Text2Fixed.Length > SeparatorFixed.Length)
                        Text2Fixed = Text2Fixed.Substring(SeparatorFixed.Length, Text2Fixed.Length - SeparatorFixed.Length);
                    else
                        Text2Fixed = string.Empty;
            }
            string ConcatenatedText = Text1Fixed;
            if (Text2Fixed.Length > 0) {
                if (ConcatenatedText.Length > 0)
                    ConcatenatedText += SeparatorFixed;
                ConcatenatedText += Text2Fixed;
            }
            return ConcatenatedText;
        }

        public static string NameValue(string pName, object? pValue) {
            string ValueText = pValue != null ? StringToolkit.NonNull(pValue.ToString()) : "null";
            return $"{pName}: {ValueText}";
        }
    }
}
