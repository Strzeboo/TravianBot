using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace WpfApp1.Klasy
{
    public class HttpConnectionHelper
    {


        static public string setLoginPostData(string login, string password, string secretCode)
        {
            return "login=" + secretCode + "&lowRes=0&name=" + login + "&password=" + password + "&s1=Zaloguj się&w=1920:1080";
        }

        static public string GetLoginSecretCode(string content)
        {
            string pierwszaNazwaSzukana = "input type=\"hidden\" name=\"login\" value=";
            string drugFrazaSzukana = "\" />";

            int lewy = content.Trim().IndexOf(pierwszaNazwaSzukana) + pierwszaNazwaSzukana.Length + 1;

            int prawy = content.Trim().IndexOf(drugFrazaSzukana, lewy);

            return content.Trim().Substring(lewy, prawy - lewy).ToString();
        }

        static public bool IsLoginOkey(string content)
        {
            if (content.Contains("Travian.Game.eventJamHtml"))
                return true;
            else
                return false;
        }

        static public async Task<string> GetPackage(string URL)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
            var response = await client.GetAsync(URL);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        static public string SendPackage(string URL, string SendingPacage)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
            request.Method = "POST";
            string postData = SendingPacage;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.CookieContainer = new CookieContainer();
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.31 (KHTML, like Gecko) Chrome/26.0.1410.64 Safari/537.31";

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (dataStream = dataStream = response.GetResponseStream())
            {

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                return responseFromServer.Trim();
            }
        }
    }
}
