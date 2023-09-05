using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GS.Cordoba.Rest.SDK.Exceptions
{
    public class RequestException : Exception
    {
        public class ErrorObject
        {
            public ErrorObject()
            {

            }

            public ErrorObject(string message)
            {
                this.Message = message;
            }

            public string Message { get; set; }
            public string ExceptionMessage { get; set; }
            public string ExceptionType { get; set; }
            public string StackTrace { get; set; }
            public long? External_CMS_ID { get; set; }
        }

        public class CURLWriter
        {
            public string Execute(RestRequest request, RestResponse response, IEnumerable<Parameter> parameters)
            {
                List<string> sb = new List<string>();
                try
                {
                    sb.Add("curl");
                    if (request.RequestFormat == DataFormat.Json)
                    {
                        sb.Add("-H"); sb.Add("\"Content-Type: application/json\"");
                    }
                        
                    sb.Add("-request"); sb.Add(request.Method.ToString());
                    foreach (var param in parameters)
                    {
                        switch (param.Type)
                        {
                            case ParameterType.HttpHeader:
                                sb.Add("-H"); sb.Add("\""+param.Name + ": " + (param.Value != null ? param.Name=="token" ? param.Value.ToString().Replace("\"", "\\\"")+"=-" : param.Value.ToString().Replace("\"", "\\\"") : null) + "\"");
                                break;
                            case ParameterType.RequestBody:
                                sb.Add("-d"); sb.Add("\"" + Newtonsoft.Json.JsonConvert.SerializeObject(param.Value).Replace("\"", "\\\"") + "\"");
                                break;
                        }
                    }
                    sb.Add("\""+response.ResponseUri.ToString()+"\"");
                }
                catch
                {
                    // Do nothing
                }

                return GS.Cordoba.Rest.SDK.Classes.Strings.ListStringCombine(sb, m => m, " ");
            }
        }

        public string Content { get; internal set; }
        public System.Net.HttpStatusCode Status { get; internal set; }

        static ErrorObject getErrorObject(string content)
        {
            if (string.IsNullOrEmpty(content) || !content.Contains("{"))
                return new ErrorObject();
            try
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ErrorObject>(content);
            }
            catch
            {
                return new ErrorObject();
            }
        }

        static string getParameters(IEnumerable<Parameter> parameters)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var param in parameters)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append(string.Format("{0}({1})=\"{2}\"", param.Name, param.Type.ToString(), param.Value));
            }
            return sb.ToString();

        }

        public RequestException(RestClient client, RestRequest request, RestResponse response, System.Net.HttpStatusCode status, string message, string content)
            : base(string.Format("Error while {0} on {1} {2}: {3} [{5}]",
                    request.Resource,
                    request.Method.ToString(),
                    client.Options.BaseUrl,
                    (status + ", " + message + ", " + getErrorObject(content).Message + ", " + getErrorObject(content).ExceptionMessage).Trim(),
                    getParameters(client.DefaultParameters.Concat(request.Parameters)),
                    new CURLWriter().Execute(request, response, client.DefaultParameters.Concat(request.Parameters))
                ))
        {
            this.Content = content;
            this.Status = status;
        }

        public RequestException(string message, ErrorObject error = null)
            : base(message)
        {
            if(error!=null)
                this.Content = Newtonsoft.Json.JsonConvert.SerializeObject(error);
        }

        public ErrorObject ClientError
        {
            get
            {
                return getErrorObject(this.Content);
            }
        }
    }
}