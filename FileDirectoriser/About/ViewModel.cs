using System;

namespace Fortah.FileDirectoriser.About {
    public class ViewModel {
        public Model Model { get; private set; }

        public string Product { get { return this.Model.Product; } }
        public Version Version { get { return this.Model.Version; } }
        public string Date { get { return this.Model.Date; } }
        public string Description { get { return this.Model.Description; } }
        public string Company { get { return this.Model.Company; } }
        public string Authors { get { return this.Model.Authors; } }

        public ViewModel(Model? pModel = null) {
            this.Model = pModel != null ? pModel : new Model();
        }
    }
}
