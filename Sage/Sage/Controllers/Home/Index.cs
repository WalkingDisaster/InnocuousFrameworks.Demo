using Sage.Models.Home;

namespace Sage.Controllers.Home
{
    public class Index
    {
        public HomeIndexViewModel Result { get; private set; }

        public void Execute()
        {
            Result = new HomeIndexViewModel
                         {
                             Message = "Welcome to ASP.NET MVC!"
                         };
        }
    }
}