using System;
using System.Collections.Generic;
using System.Text;

namespace ApiValidation
{
    public class RequiredValidator : BaseValidator
    {
        public override object Value { get; set; }
        public override string ValidationError { get; set; }

        public RequiredValidator(object value,string validationError)
        {
            ValidationError = validationError;
            Value = value;
        }
       
        public void SetSuccessor(BaseValidator validator)
        {
            Successor = validator;
        }

        public override bool Validate()
        {
            if(Value != null)
            {
                if (Successor != null)
                {
                    return Successor.Validate();
                }
                return true;
            }
            return false;
        }
    }
}
