using Sulakore.Protocol;
using System.Collections.Generic;

namespace HAlerts
{
    public class HAlert
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string AlertType { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
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

        public HMessage ToPacket(ushort header)
        {
            HMessage packet = new HMessage(header, "HAlerts_custom");
            Dictionary<string, string> alertParams = new Dictionary<string, string>(6);

            if (Title != null) alertParams.Add("title", Title);
            if (Message != null) alertParams.Add("message", Message);
            if (AlertType != null) alertParams.Add("display", AlertType);
            if (Url != null) alertParams.Add("linkUrl", Url);
            if (Image != null) alertParams.Add("image", Image);
            if (UrlTitle != null) alertParams.Add("linkTitle", UrlTitle);

            packet.WriteInteger(alertParams.Count);

            foreach (string key in alertParams.Keys)
            {
                packet.WriteString(key);
                packet.WriteString(alertParams[key]);
            }

            return packet;
        }
    }
}
