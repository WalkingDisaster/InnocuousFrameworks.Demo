using System.Web.Security;
using Sage.Models;
using Sage.Models.Account;

namespace Sage.Controllers.Account
{
    public class DoRegister
    {
        public DoRegisterInputModel Input { get; set; }
        public DoRegisterResultModel Result { get; private set; }
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        public DoRegister()
        {
            FormsService = new FormsAuthenticationService();
            MembershipService = new AccountMembershipService();
            Result = new DoRegisterResultModel
                         {
                             PasswordLength = MembershipService.MinPasswordLength
                         };
        }

        public void Execute()
        {
            Result.CreateStatus = MembershipService.CreateUser(Input.UserName, Input.Password, Input.Email);
            if (Result.CreateStatus == MembershipCreateStatus.Success)
            {
                FormsService.SignIn(Input.UserName, false);
                Result.UserIsSignedIn();
                return;
            }
        }
    }
}