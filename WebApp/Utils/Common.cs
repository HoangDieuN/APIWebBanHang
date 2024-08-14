using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApp
{
    public class Common
    {
        /// <summary>
        /// Tỷ lệ trùng khớp giữa 2 chuỗi
        /// </summary>
        /// <param name="compareStr"></param>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static float DiffPercentString(string compareStr, string sourceStr)
        {
            float result = 0;

            string pattern = @"\s+";

            var arrChar1 = Regex.Split(compareStr, pattern);
            var arrChar2 = Regex.Split(sourceStr, pattern);

            arrChar1 = arrChar1.Select(x => x.ToLower()).Distinct().ToArray();
            arrChar2 = arrChar2.Select(x => x.ToLower()).Distinct().ToArray();

            float count = 0;
            foreach (var item in arrChar1)
            {
                if (arrChar2.Contains(item))
                    count++;
            }

            if (count >= arrChar2.Length)
            {
                result += 100;
            }
            else
            {
                result += (count / arrChar2.Length) * 100;
            }

            return result;
        }

        /// <summary>
        /// Check trùng mã DOI
        /// </summary>
        /// <param name="compareStr"></param>
        /// <param name="sourceStr"></param>
        /// <returns></returns>
        public static bool CheckDOI(string compareStr, string sourceStr)
        {
            bool result = false;

            string pattern = @"^(?:http[s]?:\/\/)?(?:[^@\n]+@)?(?:www\.)?([^:\/\n?]+)";

            var doi1 = Regex.Replace(compareStr, pattern, "");
            var doi2 = Regex.Replace(sourceStr, pattern, "");

            if (doi1.Contains(doi2) || doi2.Contains(doi1))
                result = true;

            return result;
        }

        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatString = "dd/MM/yyyy"
        };
    }
}