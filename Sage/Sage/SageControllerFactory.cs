using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sage
{
    public class SageControllerFactory : DefaultControllerFactory
    {
        private readonly string _rootNamespace;

        public SageControllerFactory(string rootNamespace)
        {
            _rootNamespace = rootNamespace;
        }

        protected override Type GetControllerType(RequestContext requestContext, string controllerName)
        {
            var conventionalControllerName =
                string.Format("{0}.Controllers.{1}Controller", _rootNamespace, controllerName);
            var type = Type.GetType(conventionalControllerName);
            if (type != null)
                return base.GetControllerType(requestContext, controllerName);
            
            var somethingElse = base.GetControllerType(requestContext, controllerName);
            return null;
        }
   }
}