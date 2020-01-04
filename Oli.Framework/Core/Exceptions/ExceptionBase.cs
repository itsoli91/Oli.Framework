using System;
using System.Collections.Generic;
using System.Text;

namespace Oli.Framework.Core.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        protected ExceptionBase(string message, int exceptionTypeCode, int exceptionFamilyCode) : base(message)
        {
            HResult = exceptionTypeCode + exceptionFamilyCode;
        }
    }
}