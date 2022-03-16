using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using VD.Library.Extensions;

namespace GS.PflanzenCMS.Rest.SDK.Models
{
    public class Job : Entity
    {
        public class Summary : GS.PflanzenCMS.Rest.SDK.Models.Summary
        {
            public long JobID { get; set; }
            public string Name { get; set; }
            public double? Percent { get; set; }
            public string Status { get; set; }
        }

        public long JobID { get; set; }
        public string Name { get; set; }
        public double? Percent { get; set; }
        public string Status { get; set; }
        public string Parameter { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Finished { get; set; }
        public DateTime? Alive { get; set; }
        public DateTime? Aborted { get; set; }
        public bool? Succeeded { get; set; }
        public int? ErrorCount { get; set; }
        public int? InfoCount { get; set; }
        public int? WarningCount { get; set; }
        public int? DownloadCount { get; set; }
        public int? ResultCount { get; set; }

        public bool IsAlive()
        {
            if (this.Started == null)
                return true; // Warte auf den Start

            if (this.Alive == null)
                return false;

            return (DateTime.Now - this.Alive.Value.ToTimeZone()).TotalMinutes < 5;
        }

        public string GetStatusInfo(bool status = true)
        {
            var result = "";
            if (this.Started == null)
            {
                result = VD.Locale.Texts._("Warte auf Ausführung..");
            }
            else if (this.Alive != null)
            {
#if !DEBUG
                if (!this.IsAlive())
                {
                    result = VD.Locale.Texts._("Zeit abgelaufen.");
                }
                else
#endif
                {
                    if (this.Percent != null)
                        result = Math.Round(this.Percent.Value, 1) + "%";
                }
            }
            else if (this.Aborted != null)
            {
                result = VD.Locale.Texts.Format("Am {0} abgebrochen", this.Aborted);
            }
            else if (this.Succeeded != null)
            {
                //percentDoneHtml = "<b>";
                if (!this.Succeeded.Value || this.ErrorCount > 0)
                    result += VD.Locale.Texts.Format("{0} Fehler", this.ErrorCount);
                else if (this.Succeeded.Value && this.WarningCount > 0)
                    result += VD.Locale.Texts.Format("Fertig mit {0} Warnungen", this.WarningCount);
                else
                    result += VD.Locale.Texts._("Fertig");

                if (!string.IsNullOrEmpty(this.Status) && status && this.Status != "---")
                {
                    result += ", ";
                    result += this.Status;
                }
            }

            return result.Trim();
        }

        public bool IsFor(Order order)
        {
            if (this.ParameterDictionary.ContainsKey("OrderID"))
                return this.ParameterDictionary.GetValue<long>("OrderID") == order.OrderID;
            return false;
        }

        public bool IsWorker(string workerType)
        {
            if (this.ParameterDictionary.ContainsKey("jobType"))
                return VD.Library.Strings.Base64Decode(this.ParameterDictionary.GetValue<string>("jobType")).Contains("GS.PflanzenCMS.Worker."+ workerType);

            return false;
        }

        public Dictionary<string, string> ParameterDictionary
        {
            get
            {
                Dictionary<string, string> state = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(Parameter))
                {
                    string[] parameters = Parameter.Split(',');
                    foreach (var par in parameters)
                    {
                        string[] ss = par.Split('=');
                        state[ss[0]] = ss.Length > 1
                            ? ss.Length > 2
                                ? VD.Library.Strings.strListCombine(ss.Skip(1).ToArray(), "=")
                                : ss[1]
                            : ss[0];
                    }
                }
                return state;
            }
            set
            {
                var s = "";
                foreach (var key in value.Keys)
                {
                    if (s.Length > 0)
                        s += ",";
                    s += key + "=" + value[key];
                }
                this.Parameter = s;
            }
        }
    }
}
