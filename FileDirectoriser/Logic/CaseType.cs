using Fortah.FileDirectoriser.WPF;
using System.ComponentModel;

namespace Fortah.FileDirectoriser.Logic {
    [TypeConverter(typeof(EnumDescriptionConverter))]
    public enum CaseType : int {
        [Description("")]
        Empty = 0,
        [Description("UPPER CASE")]
        Upper = 1,
        [Description("lower case")]
        Lower = 2,
        [Description("Proper Case")]
        Proper = 3
    }
}
