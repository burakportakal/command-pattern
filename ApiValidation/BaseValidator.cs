using System;
using System.Collections.Generic;
using System.Text;

namespace ApiValidation
{
    public abstract class BaseValidator
    {
        public abstract object Value { get; set; }
        public abstract string ValidationError { get; set; }
        public abstract bool Validate();
        public BaseValidator Successor { get; set; }
    }
}
