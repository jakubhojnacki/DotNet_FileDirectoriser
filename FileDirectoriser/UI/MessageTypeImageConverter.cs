using System;
using System.Globalization;
using System.Windows.Data;

namespace FileDirectoriser {
    public class MessageTypeImageConverter : IValueConverter {
        public object Convert(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture) {
            string ImageSource = string.Empty;
            MessageType MessageType = (MessageType)pValue;
            switch (MessageType) {
                case MessageType.Information:
                    ImageSource = "/Resources/Images/MessageTypeInformation.png";
                    break;
                case MessageType.Warning:
                    ImageSource = "/Resources/Images/MessageTypeWarning.png";
                    break;
                case MessageType.Error:
                    ImageSource = "/Resources/Images/MessageTypeError.png";
                    break;
                default:
                    ImageSource = "/Resources/Images/MessageTypeUnknown.png";
                    break;
            }
            return ImageSource;
        }

        public object ConvertBack(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture) {
            throw new NotImplementedException("This converter only works for one way binding");
        }
    }
}
