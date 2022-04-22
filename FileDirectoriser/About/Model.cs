using Fortah.FileDirectoriser.Toolkits;
using System;

namespace Fortah.FileDirectoriser.About {
    public class Model {
        public string Product { get; private set; }
        public Version Version { get; private set; }
        public string Date { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }
        public string Authors { get; private set; }

        public Model() {
            this.Product = ApplicationToolkit.Product;
            this.Version = ApplicationToolkit.Version;
            this.Date = ApplicationToolkit.Date;
            this.Description = ApplicationToolkit.Description;
            this.Company = ApplicationToolkit.Company;
            this.Authors = ApplicationToolkit.Authors;
        }
    }
}
