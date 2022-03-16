using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Classes
{
    public class DataUri
    {
        public byte[] Data
        {
            get
            {
                // Convert the Base64 string to binary data
                return System.Convert.FromBase64String(Base64Content);
            }
        }

        public string Content { get; set; }
        public string MimeType { get; set; }
        public string Base64Content { get; set; }

        public DataUri(Stream stream, string mimeType = "image/png")
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            this.Content = @"data:" + mimeType + ";base64," + System.Convert.ToBase64String(data);
            this.Base64Content = System.Convert.ToBase64String(data);
            this.MimeType = mimeType;
        }

        public DataUri(byte[] data, string mimeType = "image/png")
        {
            this.Content = @"data:" + mimeType + ";base64," + System.Convert.ToBase64String(data);
            this.Base64Content = System.Convert.ToBase64String(data);
            this.MimeType = mimeType;
        }

        public DataUri(string content)
        {
            this.Content = content;

            if (!content.StartsWith("data:"))
                return;
            content = content.Remove(0, 5);

            string mimeType = "";
            while (!content.StartsWith(";"))
            {
                mimeType += content.Substring(0, 1);
                content = content.Remove(0, 1);
            }
            content = content.Remove(0, 1);
            this.MimeType = mimeType;

            if (!content.StartsWith("base64,"))
                return;
            content = content.Remove(0, 7);

            this.Base64Content = content;




        }

        public override string ToString()
        {
            return this.Content;
        }
    }
}
