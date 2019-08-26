using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Klasy
{
    public class StringOperationHelper
    {
        static public string GetStringBeetweenTwoStrings(string content, string firstString, string secondString)
        {

            int left = content.IndexOf(firstString) + firstString.Length;

            int right = content.IndexOf(secondString, left);

            return content.Trim().Substring(left, right - left).ToString();
        }

        static public string GetStringBeetweenTwoStrings(string content, string firstString, int howManyAddToFirstString, string secondString)
        {

            int left = content.IndexOf(firstString) + firstString.Length + howManyAddToFirstString;

            int right = content.IndexOf(secondString, left);

            return content.Trim().Substring(left, right - left).ToString();
        }
    }
}
