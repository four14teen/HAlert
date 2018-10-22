using System;

namespace HAlerts
{
    public class HAlertBuilder
    {
        private string _title;
        private string _message;
        private string _alertType;
        private string _url;
        private string _image;
        private string _urlTitle;

        public static HAlertBuilder CreateAlert(HAlertType type, string message)
            => new HAlertBuilder()
            {
                _message = message,
                _alertType = (type == HAlertType.Bubble ? "BUBBLE" : "POP_UP")
            };

        public HAlertBuilder Title(string title)
        {
            _title = title;
            return this;
        }

        public HAlertBuilder EventUrl(string url, bool isExternalUrl = false)
        {
            _url = (isExternalUrl ? string.Empty : "event:") + url;
            return this;
        }

        public HAlertBuilder EventTitle(string title)
        {
            _urlTitle = title;
            return this;
        }

        public HAlertBuilder ImageUrl(string url)
        {
            _image = url;
            return this;
        }

        public static implicit operator HAlert(HAlertBuilder builder)
        {
            return new HAlert(builder._title, builder._message, builder._alertType, builder._url, builder._image, builder._urlTitle);
        }
    }
}
