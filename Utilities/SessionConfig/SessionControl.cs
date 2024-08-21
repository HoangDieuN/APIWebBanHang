using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utilities
{
    public class SessionControl
    {
        /// <summary>
        /// Lấy thông tin User từ Session
        /// </summary>
        /// <returns></returns>
        public static T GetSessionUserInfo<T>()
            where T : new()
        {
            try
            {
                var user = GetNormalSession<T>(CommonConstants.User);
                return user;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        #region Sessions
        public static void AddNormalSession(string strSessionName, object objValue, int timeout = 60)
        {
            HttpContext.Current.Session.Remove(strSessionName);
            HttpContext.Current.Session[strSessionName] = objValue;
            HttpContext.Current.Session.Timeout = timeout;
        }
        public static object GetNormalSession(string strSessionName)
        {
            return HttpContext.Current.Session[strSessionName];
        }
        public static T GetNormalSession<T>(string strSessionName)
        {
            try
            {
                return (T)HttpContext.Current.Session[strSessionName];
            }
            catch (Exception ex)
            {
                return default(T);
                throw;
            }
        }
        public static void DeleteNormalSession(string strSessionName)
        {
            HttpContext.Current.Session.Remove(strSessionName);
        }
        #endregion
    }
}
