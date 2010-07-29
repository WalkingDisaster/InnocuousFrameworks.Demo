using Sage.Models;

namespace Sage.Controllers.Account
{
    public class LogOff
    {
        public IFormsAuthenticationService FormsService { get; set; }

        public LogOff()
        {
            FormsService = new FormsAuthenticationService();
        }

        public void Execute()
        {
            FormsService.SignOut();
        }
    }
}