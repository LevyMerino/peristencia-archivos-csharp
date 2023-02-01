using Microsoft.AspNetCore.Mvc;
using PresentacionFarmaceutica.Models;

namespace PresentacionFarmaceutica.Controllers
{
    public class SessionController : Controller
    {

        public void SetSessionInfo()
        {
            if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionVariables.SessionKeyUserName)))
            {
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserName.ToString(), "Current User");
                HttpContext.Session.SetString(SessionVariables.SessionKeyUserId.ToString(), Guid.NewGuid().ToString());

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
