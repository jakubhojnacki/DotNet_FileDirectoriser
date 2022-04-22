using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Fortah.FileDirectoriser.Generic {
    public static class EnumExtension {
        public static string Description(this Enum pValue) {
            string Description = string.Empty;
            FieldInfo? Field = pValue.GetType().GetField(pValue.ToString());
            if (Field != null) {
                IEnumerable<Attribute> Attributes = Field.GetCustomAttributes();
                Attribute DescriptionAttribute = Attributes.First<Attribute>((Attribute) => Attribute is DescriptionAttribute);
                if (DescriptionAttribute != null)
                    Description = ((DescriptionAttribute)DescriptionAttribute).Description.Trim();
            }
            if (Description.Length == 0) {
                TextInfo TextInfo = CultureInfo.CurrentCulture.TextInfo;
                Description = TextInfo.ToTitleCase(TextInfo.ToLower(pValue.ToString().Replace("_", " ")));
            }
            return Description;
        }
    }
}
