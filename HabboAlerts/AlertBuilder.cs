namespace HabboAlerts
{
    public class AlertBuilder
    {
        private HabboAlert _alert;

        public AlertBuilder(HabboAlertType type, string message)
        {
            _alert = new HabboAlert
            {
                Type = type,
                Message = message
            };
        }

        /// <summary>
        /// Adds a title to the alert.
        /// </summary>
        /// <param name="title">The title</param>
        public AlertBuilder WithTitle(string title)
        {
            _alert.Title = title;
            return this;
        }

        /// <summary>
        /// <para>Adds an event to the alert. This can be a Habbo Event (see <see cref="HabboEvents"/> for a list of pre-defined events you can use) or an external URL to navigate to.</para>
        /// <para>This event triggers when clicking the button in <see cref="HabboAlertType.PopUp"/> alerts, or when clicking a <see cref="HabboAlertType.Bubble"/> alert.</para>
        /// </summary>
        /// <param name="url">The HabboEvent or external URL</param>
        /// <param name="isExternalUrl">Is the url parameter an external URL, or a Habbo Event?</param>
        public AlertBuilder WithEventUrl(string url, bool isExternalUrl = false)
        {
            _alert.Url = (isExternalUrl ? string.Empty : "event:") + url;
            return this;
        }

        /// <summary>
        /// Adds a title to the event button in a <see cref="HabboAlertType.PopUp"/> alert, if an event was added.
        /// </summary>
        /// <param name="title">The title</param>
        public AlertBuilder WithEventTitle(string title)
        {
            _alert.UrlTitle = title;
            return this;
        }

        /// <summary>
        /// Adds an image to a <see cref="HAlertType.PopUp"/> alert. Not all image URLs are supported. It is unsure what the conditions are to make them work.
        /// </summary>
        /// <param name="url">The image url</param>
        public AlertBuilder WithImageUrl(string url)
        {
            _alert.Image = url;
            return this;
        }

        public static implicit operator HabboAlert(AlertBuilder builder) => builder._alert;
        public static AlertBuilder CreateAlert(HabboAlertType type, string message) => new AlertBuilder(type, message);
    }
}
