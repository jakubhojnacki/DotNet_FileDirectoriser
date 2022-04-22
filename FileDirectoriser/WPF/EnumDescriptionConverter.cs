using Fortah.FileDirectoriser.Toolkits;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace Fortah.FileDirectoriser.WPF {
    public class EnumDescriptionConverter : EnumConverter {
        public EnumDescriptionConverter(Type type) : base(type) {
        }

        public override object? ConvertTo(ITypeDescriptorContext? pContext, CultureInfo? pCulture, object? pValue, Type pDestinationType) {
            object? Result = null;
            if (pDestinationType == typeof(string))
                if (pValue != null) {
                    string ValueText = StringToolkit.NonNull(pValue.ToString());
                    FieldInfo? FieldInfo = pValue.GetType().GetField(ValueText);
                    if (FieldInfo != null) {
                        DescriptionAttribute[] Attributes = (DescriptionAttribute[])FieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if (Attributes.Length > 0)
                            Result = Attributes[0].Description;
                    }
                }
            if (Result == null)
                Result = base.ConvertTo(pContext, pCulture, pValue, pDestinationType);
            return Result;
        }
    }
}
