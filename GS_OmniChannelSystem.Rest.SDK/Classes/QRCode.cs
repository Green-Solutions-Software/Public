using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GS.PflanzenCMS.Rest.SDK.Classes
{
    public static class QRCode
    {
        public class QRArticle
        {
            public int Quantity { get; set; }
            public string Value { get; set; }
        }

        public class QRInfo
        {
            public string MemberNumber { get; set; }
            public QRArticle[] Articles { get; set; }
            public string[] Vouchers { get; set; }
            public bool NoReceipt { get; set; }
            public string DebitCardNumber { get; set; }
            public double? Amount { get; set; }
        }

        public static string CreateQR(QRInfo info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("0QR");
            if (info.MemberNumber != null)
            {
                sb.Append("M;");
                sb.Append(info.MemberNumber + ";");
            }
            if (info.Articles != null && info.Articles.Any())
            {
                sb.Append("A;");
                foreach (var article in info.Articles)
                {
                    if (article != info.Articles.First())
                        sb.Append(",");
                    sb.Append(article.Value + "," + article.Quantity);
                }
                sb.Append(";");
            }
            if (info.Vouchers != null && info.Vouchers.Any())
            {
                sb.Append("V;");
                foreach (var voucher in info.Vouchers)
                {
                    if (voucher != info.Vouchers.First())
                        sb.Append(",");
                    sb.Append(voucher);
                }
                sb.Append(";");
            }
            if (info.DebitCardNumber != null)
            {
                sb.Append("D;");
                sb.Append(info.DebitCardNumber + ";");
            }
            if (info.Amount != null)
            {
                sb.Append("P;");
                sb.Append(Math.Round(info.Amount.Value, 2).ToString(new CultureInfo("en-US")) + ";");
            }
            if (info.NoReceipt)
                sb.Append("NR;");

            // MD5 Hash
            var md5Hasher = MD5.Create();
            // Please replace the salt with the secret salt !!!
            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes("GS74RCJ835" + sb.ToString()));
            var sbMd5 = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
                sbMd5.Append(data[i].ToString("x2"));
            var md5 = sbMd5.ToString().ToUpper();
            var result = sb.ToString() + md5.Substring(0, 2) + md5.Substring(md5.Length - 2, 2);
            return result;
        }
    }
}
