using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace testing_API_job
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 5; i++)
            {
                Thread _Individualprocessthread = new Thread(new ThreadStart(SendRequest));
                Thread _Individualprocessthread2 = new Thread(new ThreadStart(SendRequest));
                Thread _Individualprocessthread3 = new Thread(new ThreadStart(SendRequest));
                Thread _Individualprocessthread4 = new Thread(new ThreadStart(SendRequest));
                Thread _Individualprocessthread5 = new Thread(new ThreadStart(SendRequest));
                Thread _Individualprocessthread6 = new Thread(new ThreadStart(SendRequest));

                _Individualprocessthread.Start();
                _Individualprocessthread2.Start();
                _Individualprocessthread3.Start();
                _Individualprocessthread4.Start();
                _Individualprocessthread5.Start();
                _Individualprocessthread6.Start();
            }

            Console.WriteLine("Hello World!");
        }

        public static void SendRequest()
        {
            string apiResponse = string.Empty;

            Example Example = new Example()
            {
                ProgramCode = "bataclub",
                Mobile = "918793632057",
                Message = new List<string>()
                {
                    "reply Suraj new from backjob customer " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                },
                botreply = false,
                StoreCode= "SMB3024",
                EndChat= false,
            };

            Example Example2 = new Example()
            {
                ProgramCode = "bataclub",
                Mobile = "918793632057",
                Message = new List<string>()
                {
                    "reply Suraj new from backjob botreply " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                },
                botreply = true,
                StoreCode = "SMB3024",
                EndChat = false,
            };

            Example Example3 = new Example()
            {
                ProgramCode = "bataclub",
                Mobile = "919136808450",
                Message = new List<string>()
                {
                    "reply Kanhu new from backjob botreply " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                },
                botreply = false,
                StoreCode = "SMB3024",
                EndChat = false,
            };

            Example Example4 = new Example()
            {
                ProgramCode = "bataclub",
                Mobile = "919136808450",
                Message = new List<string>()
                {
                    "reply Kanhu new from backjob botreply " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                },
                botreply = true,
                StoreCode = "SMB3024",
                EndChat = false,
            };

            Example Example5 = new Example()
            {
                ProgramCode = "bataclub",
                Mobile = "918976476073",
                Message = new List<string>()
                {
                    "reply Devesh new from backjob botreply " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                },
                botreply = false,
                StoreCode = "SMB3024",
                EndChat = false,
            };

            Example Example6 = new Example()
            {
                ProgramCode = "bataclub",
                Mobile = "918976476073",
                Message = new List<string>()
                {
                    "reply Devesh new from backjob botreply " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                },
                botreply = true,
                StoreCode = "SMB3024",
                EndChat = false,
            };

            string apiReq = JsonConvert.SerializeObject(Example);
            string apiReq2 = JsonConvert.SerializeObject(Example2);
            string apiReq3 = JsonConvert.SerializeObject(Example3);
            string apiReq4 = JsonConvert.SerializeObject(Example4);
            string apiReq5 = JsonConvert.SerializeObject(Example5);
            string apiReq6 = JsonConvert.SerializeObject(Example6);
            
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq2);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq2);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq3);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq3);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq4);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq4);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq5);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq5);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq6);
            apiResponse = SendApiRequest("https://bvsocketservermts.dcdev.brainvire.net/api/sendreply", apiReq6);
        }

        public static string SendApiRequest(string url, string Request)
        {
            string strresponse = "";
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";

                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    if (!string.IsNullOrEmpty(Request))
                        streamWriter.Write(Request);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    strresponse = streamReader.ReadToEnd();
                }
            }
            catch (WebException e)            {                using (WebResponse response = e.Response)                {                    HttpWebResponse httpResponse = (HttpWebResponse)response;                    using (Stream data = response.GetResponseStream())                    using (var reader = new StreamReader(data))                    {                        strresponse = reader.ReadToEnd();

                    }                }            }
            catch (Exception)
            {
                throw;
            }

            return strresponse;

        }
    }

    public class Example
    {
        public string ProgramCode { get; set; }
        public string Mobile { get; set; }
        public List<string> Message { get; set; }
        public bool botreply { get; set; }
        public string StoreCode { get; set; }
        public bool EndChat { get; set; }
    }

}
