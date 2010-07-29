using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Sage.Models
{
    public abstract class ModelStateModelBase : IModifiesModelState
    {
        private readonly List<Action<ModelStateDictionary>> _modelStateActions;
        public bool Success { get; protected set; }
  
        protected ModelStateModelBase()
        {
            _modelStateActions = new List<Action<ModelStateDictionary>>();
            Success = false;
        }

        protected void AddModelStateError(string key, string errorMessage)
        {
            _modelStateActions.Add(ms => ms.AddModelError(key, errorMessage));
            Success = false;
        }

        public void UpdateModelState(ModelStateDictionary modelState)
        {
            _modelStateActions.ForEach(a => a(modelState));
        }
    }
}