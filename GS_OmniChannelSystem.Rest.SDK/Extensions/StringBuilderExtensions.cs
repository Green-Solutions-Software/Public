using System.Text;

namespace GS.OmniChannelSystem.Rest.SDK.Extensions
{
    public static class StringBuilderExtensions
    {
        public static void Append(this StringBuilder sb, string s, int length)
        {
            while ((s ?? "").Length < length)
                s += " ";
            while ((s ?? "").Length > length)
                s = s.Substring(0, s.Length - 1);

            sb.Append(s);
        }
    }
}
