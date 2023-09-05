namespace GS.Cordoba.Rest.SDK.Models
{
    public class MemberMessageArgs
    {
        public MemberMessageArgs()
        {

        }

        public MemberMessageArgs(string email, string subject, string message)
        {
            this.EMail = email;
            this.Subject = subject;
            this.Message = message;
        }

        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
