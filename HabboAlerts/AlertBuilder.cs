namespace HabboAlerts
{
    public sealed class AlertBuilder
    {
        private string _title;
        private string _message;
        private string _alertType;
        private string _url;
        private string _image;
        private string _urlTitle;

        public static AlertBuilder CreateAlert(HabboAlertType type, string message)
        {
            return new AlertBuilder()
            {
                _message = message,
                _alertType = (type == HabboAlertType.Bubble ? "BUBBLE" : "POP_UP")
            };
        }

        /// <summary>
        /// Adds a title to the alert.
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns></returns>
        public AlertBuilder Title(string title)
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
        public AlertBuilder EventUrl(string url, bool isExternalUrl = false)
        {
            _url = (isExternalUrl ? string.Empty : "event:") + url;
            return this;
        }

        /// <summary>
        /// Adds a title to the event button in a <see cref="HAlertType.PopUp"/> alert, if an event was added.
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns></returns>
        public AlertBuilder EventTitle(string title)
        {
            _urlTitle = title;
            return this;
        }

        /// <summary>
        /// Adds an image to a <see cref="HAlertType.PopUp"/> alert. Not all image URLs are supported. It is unsure what the conditions are to make them work.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public AlertBuilder ImageUrl(string url)
        {
            _image = url;
            return this;
        }

        public static implicit operator HabboAlert(AlertBuilder builder)
        {
            return new HabboAlert(builder._title, builder._message, builder._alertType, builder._url, builder._image, builder._urlTitle);
        }
    }
}
