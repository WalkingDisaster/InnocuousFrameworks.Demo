using Sage.Models;
using Sage.Models.Account;

namespace Sage.Controllers.Account
{
    public class DoLogOn
    {
        public LogOnViewModel Input { get; set; }
        public DoLogOnResultModel Result { get; set; }
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        public DoLogOn()
        {
            FormsService = new FormsAuthenticationService();
            MembershipService = new AccountMembershipService();
            Result = new DoLogOnResultModel();
        }

        public void Execute()
        {
            if (MembershipService.ValidateUser(Input.UserName, Input.Password))
            {
                FormsService.SignIn(Input.UserName, Input.RememberMe);
                Result.UserIsLoggedIn();
                return;
            }
            Result.UserCredentialsNotValid();
        }
    }
}