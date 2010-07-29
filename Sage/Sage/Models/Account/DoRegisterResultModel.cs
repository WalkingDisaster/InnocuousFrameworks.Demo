using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;

namespace Sage.Models.Account
{
    public class DoRegisterResultModel : ModelStateModelBase
    {
        private MembershipCreateStatus _createStatus;
        public int PasswordLength { get; set; }

        public MembershipCreateStatus CreateStatus
        {
            get
            {
                return _createStatus;
            }
            set
            {
                _createStatus = value;
                if (_createStatus != MembershipCreateStatus.Success)
                    AddModelStateError("", AccountValidation.ErrorCodeToString(_createStatus));
            }
        }

        public void UserIsSignedIn()
        {
            Success = true;
        }
    }
}