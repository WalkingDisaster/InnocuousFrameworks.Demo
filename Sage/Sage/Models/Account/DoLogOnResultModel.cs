using System;

namespace Sage.Models.Account
{
    public class DoLogOnResultModel : ModelStateModelBase
    {
        public void UserIsLoggedIn()
        {
            Success = true;
        }

        public void UserCredentialsNotValid()
        {
            AddModelStateError("", "The user name or password provided is incorrect.");
        }
    }
}