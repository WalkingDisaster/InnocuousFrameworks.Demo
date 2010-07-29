using System.Web.Mvc;

namespace Sage
{
    public interface IModifiesModelState
    {
        void UpdateModelState(ModelStateDictionary modelState);
    }
}