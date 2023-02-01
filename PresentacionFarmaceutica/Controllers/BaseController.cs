using MedicamentContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using PresentacionFarmaceutica.Models;

namespace PresentacionFarmaceutica.Controllers
{
    public abstract class BaseController : Controller
    {
        public void SetSessionInfo(string user, string id)
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserName.ToString(), user);
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserId.ToString(), id);

            }
        }

        public IEnumerable<string> GetSessionInfo()
        {
            List<string> sessionInfo = new List<string>();

            var username = HttpContext.Session.GetString(SessionVariables.SessionKeyUserName);
            var sessionId = HttpContext.Session.GetString(SessionVariables.SessionKeyUserId);

            sessionInfo.Add(username);
            sessionInfo.Add(sessionId);

            return sessionInfo;

        }

    }
}
