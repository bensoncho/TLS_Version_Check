using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;

using System.Net.Security;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.IO.Compression;

/// <summary>
/// 參考：
/// https://stackoverflow.com/questions/28286086/default-securityprotocol-in-net-4-5
/// https://blog.darkthread.net/blog/webclient-and-tls12/
/// 
/// Check TLS Version Usage: (maybe .net framework 4.6 or after)
/// https://stackoverflow.com/questions/48589590/which-tls-version-was-negotiated
///   --install this : https://www.nuget.org/packages/System.IO.Compression/4.3.0 
/// </summary>
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            lblNetVersion.Text += System.Environment.Version.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            string url = tbxAPIUrl.Text.Trim();
            try
            {
                result = http_web_request_data_by_get_IgnoreServerCertificate(url);//回傳Content-Type : application/json
                tbxResult.Text = result;
            }
            catch (Exception ex)
            {
                //寫入log
                tbxResult.Text = ex.ToString();
            }
        }



        /// <summary>
        /// 使用HttpWebRequest 以GET方式取得資料 - By Sam
        /// </summary>
        /// <param name="url"></param>
        /// <param name="nc"></param>
        /// <param name="urlencode">是否要將參數以UrlEncode編碼</param>
        /// <returns></returns>
        public string http_web_request_data_by_get_IgnoreServerCertificate(string url, System.Collections.Specialized.NameValueCollection nc = null, bool urlencode = false)
        {
            var parameters = new System.Text.StringBuilder();
            string strCallTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string mykey = string.Empty;
            string myvalue = string.Empty;
            try
            {
                //準備將NameValueCollection轉換成NameValue字串
                if (nc != null)
                {
                    foreach (string key in nc.Keys)
                    {
                        mykey = (true == urlencode) ? HttpUtility.UrlEncode(key) : key;
                        myvalue = (true == urlencode) ? HttpUtility.UrlEncode(nc[key]) : nc[key];
                        parameters.AppendFormat("{0}={1}&", mykey, myvalue);
                    }
                    if (parameters.Length >= 1)
                        parameters.Length -= 1; //去掉最後的「&」號
                    //把完整網址兜出來
                    url += "?" + parameters.ToString();
                }


                //ASP.NET解決停用SSL 3.0、TLS 1.0的方案
                //For Net Framework 4.0  (必需安裝.net framework 4.5)
                //參考：http://slashlook.com/articles_20180604.html

                if (cbxTLSVersion.SelectedItem.ToString() == "TLS1.1")
                {
                    System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)768;
                }
                else if (cbxTLSVersion.SelectedItem.ToString() == "TLS1.2")
                {
                    System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
                }
                else if (cbxTLSVersion.SelectedItem.ToString() == "SSL3/TLS1.0/TLS1.1/TLS1.2")
                {

                    System.Net.ServicePointManager.SecurityProtocol =
                        (System.Net.SecurityProtocolType)768 |
                        (System.Net.SecurityProtocolType)3072 |
                        SecurityProtocolType.Ssl3 |
                        SecurityProtocolType.Tls;
                }
                else  //Default
                {
                    System.Net.ServicePointManager.SecurityProtocol =
                        SecurityProtocolType.Ssl3 |
                        SecurityProtocolType.Tls;
                }


                var securityProtocolVersion = System.Net.ServicePointManager.SecurityProtocol;
                lblTLSVersion.Text = "Client Support TLS Version: " + securityProtocolVersion.ToString();
                //.net Framework 4.5 才有支援 Tls 1.2
                //設定 HTTPS 連線時，不要理會憑證的有效性問題，參考自：https://eric0806.blogspot.tw/2011/05/webrequest.html
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                //建立WebRequest元件
                System.Net.HttpWebRequest myRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                //lblDesc.Text = string.Format("The HttpHeaders are Name Value {0}", myRequest.Headers);

                myRequest.Method = "GET";
                //myRequest.ContentType = "application/json";
                myRequest.Accept = "application/json";
                myRequest.KeepAlive = false; // 不要keep connection , 調整support protocol 在測試才看的出來重新連線後選擇的 protocol
                //讀取資料
                System.Net.HttpWebResponse wr = (System.Net.HttpWebResponse)myRequest.GetResponse();
                System.IO.Stream resStream = wr.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(resStream);
                System.Text.StringBuilder output = new System.Text.StringBuilder();


                //lblDesc.Text += string.Format("The Response Headers are Name Value {0}", wr.Headers);


                //What TLS Version used
                SslProtocols ssp = ExtractSslProtocol(resStream);
                lblTLSVersion.Text += "  Negotiate Protocols = " + ssp.ToString();

                output.Append(sr.ReadToEnd());
                sr.Close();
                return output.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //.net framework newer version
        /*
        //using System.Net.Security;
        //using System.Reflection;
        //using System.Security.Authentication;
        //using System.Security.Cryptography;
        //using System.Security.Cryptography.X509Certificates;
        //using System.IO;
        //using System.IO.Compression;         
         */
        private static SslProtocols ExtractSslProtocol(Stream stream)
        {
            if (stream == null) return SslProtocols.None;
            //if (stream == null) return;

            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;
            Stream metaStream = stream;
            if (stream.GetType().BaseType == typeof(GZipStream))
            {
                metaStream = (stream as GZipStream).BaseStream;
            }
            else if (stream.GetType().BaseType == typeof(DeflateStream))
            {
                metaStream = (stream as DeflateStream).BaseStream;
            }

            var connection = metaStream.GetType().GetProperty("Connection", bindingFlags).GetValue(metaStream, null);
            if (!(bool)connection.GetType().GetProperty("UsingSecureStream", bindingFlags).GetValue(connection, null))
            {
                // Not a Https connection
                return SslProtocols.None;
            }
            var tlsStream = connection.GetType().GetProperty("NetworkStream", bindingFlags).GetValue(connection, null);
            var tlsState = tlsStream.GetType().GetField("m_Worker", bindingFlags).GetValue(tlsStream);

            return (SslProtocols)tlsState.GetType().GetProperty("SslProtocol", bindingFlags).GetValue(tlsState, null);
        }
    }
}
