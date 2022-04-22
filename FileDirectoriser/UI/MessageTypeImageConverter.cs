using Fortah.FileDirectoriser.Generic;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Fortah.FileDirectoriser.UI {
    public class MessageTypeImageConverter : IValueConverter {
        public object Convert(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture) {
            string ImageSource = string.Empty;
            MessageType MessageType = (MessageType)pValue;
            switch (MessageType) {
                case MessageType.Information:
                    ImageSource = "/Resources/Images/MessageTypeInformation32x32.png";
                    break;
                case MessageType.Warning:
                    ImageSource = "/Resources/Images/MessageTypeWarning32x32.png";
                    break;
                case MessageType.Error:
                    ImageSource = "/Resources/Images/MessageTypeError32x32.png";
                    break;
                default:
                    ImageSource = "/Resources/Images/MessageTypeUnknown32x32.png";
                    break;
            }
            return ImageSource;
        }

        public object ConvertBack(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture) {
            throw new NotImplementedException("This converter only works for one way binding");
        }
    }
}
