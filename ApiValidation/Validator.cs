using System;
using System.Collections.Generic;
using System.Text;

namespace ApiValidation
{
    public class Validator
    {
        public bool HasErrors = false;
        public List<string> ValidationErrors;
        public List<string> Validate(List<BaseValidator> validators)
        {
            var errorList = new List<string>();
            foreach(var item in validators)
            {
                if (!item.Validate())
                {
                    HasErrors = true;
                    errorList.Add(item.ValidationError);
                }
            }
            ValidationErrors = errorList;
            return errorList;
        }
        public string GetErrorMessage()
        {
            if (ValidationErrors != null)
            {
                string message = "";
                foreach (var item in ValidationErrors)
                {
                    message += item + " ";
                }
                message.Trim();
                return message;
            }
            else
            {
                return null;
            }
        }
    }
}
