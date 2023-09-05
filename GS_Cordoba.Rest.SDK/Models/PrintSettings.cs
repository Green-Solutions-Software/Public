namespace GS.Cordoba.Rest.SDK.Models
{
    public class PrintSettings
    {
        public PrintSettings(bool combineFormats, bool tryDINA4)
        {
            this.CombineFormats = combineFormats;
            this.TryDINA4 = tryDINA4;
        }

        public bool CombineFormats { get; set; }
        public bool TryDINA4 { get; set; }
    }
}
