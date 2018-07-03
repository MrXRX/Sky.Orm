using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Sky.Data.Authority
{
    public class FormsAuthenticationPrincipal<T> : IPrincipal where T : class, new()
    {
        public IIdentity Identity { get; private set; }
        public UserData UserData { get; set; }

        public FormsAuthenticationPrincipal(FormsAuthenticationTicket ticket, UserData userData)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            if (userData == null)
                throw new ArgumentNullException("userData");

            Identity = new FormsIdentity(ticket);
            UserData = userData;
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public bool IsInUser(string user)
        {
            return false;
        }
    }
}
