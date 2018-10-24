namespace HAlerts
{
    public sealed class HAlertBuilder
    {
        private string _title;
        private string _message;
        private string _alertType;
        private string _url;
        private string _image;
        private string _urlTitle;

        public static HAlertBuilder CreateAlert(HAlertType type, string message)
        {
            return new HAlertBuilder()
            {
                _message = message,
                _alertType = (type == HAlertType.Bubble ? "BUBBLE" : "POP_UP")
            };
        }

        /// <summary>
        /// Adds a title to the alert.
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns></returns>
        public HAlertBuilder Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// <para>Adds an event to the alert. This can be a Habbo Event (see <see cref="HabboEvents"/> for a list of pre-defined events you can use) or an external URL to navigate to.</para>
        /// <para>This event triggers when clicking the button in <see cref="HAlertType.PopUp"/> alerts, or when clicking a <see cref="HAlertType.Bubble"/> alert.</para>
        /// </summary>
        /// <param name="url">The HabboEvent or external URL</param>
        /// <param name="isExternalUrl">Is the url parameter an external URL, or a Habbo Event?</param>
        /// <returns></returns>
        public HAlertBuilder EventUrl(string url, bool isExternalUrl = false)
        {
            _url = (isExternalUrl ? string.Empty : "event:") + url;
            return this;
        }

        /// <summary>
        /// Adds a title to the event button in a <see cref="HAlertType.PopUp"/> alert, if an event was added.
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns></returns>
        public HAlertBuilder EventTitle(string title)
        {
            _urlTitle = title;
            return this;
        }

        /// <summary>
        /// Adds an image to a <see cref="HAlertType.PopUp"/> alert. Not all image URLs are supported. It is unsure what the conditions are to make them work.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
