using Fortah.FileDirectoriser.Generic;
using System;
using System.Linq;
using System.Windows.Markup;

namespace Fortah.FileDirectoriser.WPF {
    public class EnumMarkupExtension : MarkupExtension {
        private Type EnumType { get; }

        public EnumMarkupExtension(Type pEnumType) {
            this.EnumType = pEnumType;
        }

        public override object ProvideValue(IServiceProvider pServiceProvider) {
            //return Enum.GetValues(this.EnumType).Cast<Enum>().Select((EnumValue) => new { Value = EnumValue, Description = EnumValue.Description() }).ToList();
            return Enum.GetValues(this.EnumType);
        }
    }
}
