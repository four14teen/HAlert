using Sulakore.Network.Protocol;
using System.Collections.Generic;

namespace HAlerts
{
    public class HAlert
    {
        /// <summary>
        /// The alert title. This only appears on PopUp alerts.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The alert message. This appears in both types of alerts, however only PopUp alerts support basic HTML.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The type of alert. Habbo accepts 2 options: "BUBBLE" and "POP_UP"
        /// </summary>
        public string AlertType { get; set; }
        /// <summary>
        /// The URL you will go to when interacting with the alert. This can be a Habbo Event, or an external URL. The latter only works in PopUp alerts.
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// The URL to an image that will be added to your alert. Not all image URLs work, it's currently unknown what the conditions are to make them work.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// The text that will be on the PopUp alert button if you added a URL.
        /// </summary>
        public string UrlTitle { get; set; }

        public HAlert(string title, string message, string type, string url, string image, string urlTitle)
        {
            Title = title;
            Message = message;
            AlertType = type;
            Url = url;
            Image = image;
            UrlTitle = urlTitle;
        }

        /// <summary>
        /// Converts the alert to a packet.
        /// </summary>
        /// <param name="header">The clientside alert header.</param>
        /// <returns></returns>
        public HPacket ToPacket(ushort header)
        {
            EvaWirePacket packet = new EvaWirePacket(header, "HAlerts_custom");

            Dictionary<string, string> alertParams = new Dictionary<string, string>(6);

            if (Title != null) alertParams.Add("title", Title);
            if (Message != null) alertParams.Add("message", Message);
            if (AlertType != null) alertParams.Add("display", AlertType);
            if (Url != null) alertParams.Add("linkUrl", Url);
            if (Image != null) alertParams.Add("image", Image);
            if (UrlTitle != null) alertParams.Add("linkTitle", UrlTitle);

            packet.Write(alertParams.Count);

            foreach (string key in alertParams.Keys)
            {
                packet.Write(key);
                packet.Write(alertParams[key]);
            }

            return packet;
        }
    }
}
