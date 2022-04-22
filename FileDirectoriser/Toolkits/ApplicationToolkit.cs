using System;
using System.IO;
using System.Reflection;

namespace Fortah.FileDirectoriser.Toolkits {
    public class ApplicationToolkit {
        private static Assembly? CurrentAssembly {
            get {
                return Assembly.GetEntryAssembly();
            }
        }
        public static string ExecutablePath { 
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? Assembly.Location : string.Empty;
            }
        }
        public static string ExecutableDirectoryPath {
            get {
                return StringToolkit.NonNull(Path.GetDirectoryName(ApplicationToolkit.ExecutablePath));
            }
        }
        public static string ExecutableName { 
            get {
                return StringToolkit.NonNull(Path.GetFileName(ApplicationToolkit.ExecutablePath));
            }
        }
        public static string Name { 
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? StringToolkit.NonNull(Assembly.GetName().Name) : string.Empty;
            }
        }
        public static string FullName { 
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? Assembly.GetName().FullName : string.Empty;
            }
        }
        public static Version Version {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                Version? Version = Assembly != null ? Assembly.GetName().Version : new Version(0, 0, 0, 0);
                return Version != null ? Version : new Version(0, 0, 0, 0);
            }
        }
        public static string Date {
            get {
                return ApplicationInfo.Date;
            }
        }
        public static string Title {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? ApplicationToolkit.GetAttribute<AssemblyTitleAttribute>(Assembly, "Title") : string.Empty;
            }
        }
        public static string Description {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? ApplicationToolkit.GetAttribute<AssemblyDescriptionAttribute>(Assembly, "Description") : string.Empty;
            }
        }
        public static string Company {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? ApplicationToolkit.GetAttribute<AssemblyCompanyAttribute>(Assembly, "Company") : string.Empty;
            }
        }
        public static string Authors {
            get {
                return ApplicationInfo.Authors;
            }
        }
        public static string Product {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? ApplicationToolkit.GetAttribute<AssemblyProductAttribute>(Assembly, "Product") : string.Empty;
            }
        }
        public static string Copyright {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? ApplicationToolkit.GetAttribute<AssemblyCopyrightAttribute>(Assembly, "Copyright") : string.Empty;
            }
        }
        public static string Trademark {
            get {
                Assembly? Assembly = ApplicationToolkit.CurrentAssembly;
                return Assembly != null ? ApplicationToolkit.GetAttribute<AssemblyTrademarkAttribute>(Assembly, "Trademark") : string.Empty;
            }
        }

        private static string GetAttribute<TAttribute>(Assembly pAssembly, string pProperty) where TAttribute : Attribute {
            string Result = string.Empty;
            TAttribute? Attribute = pAssembly.GetCustomAttribute<TAttribute>();
            if (Attribute != null) {
                PropertyInfo? Property = Attribute.GetType().GetProperty(pProperty);
                if (Property != null) {
                    object? PropertyValue = Property.GetValue(Attribute);
                    Result = PropertyValue != null ? StringToolkit.NonNull(PropertyValue.ToString()) : string.Empty;
                }
            }
            return Result;
        }
    }
}
