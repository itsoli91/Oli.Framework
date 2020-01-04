using System;
using System.Collections.Generic;
using System.Text;

namespace Oli.Framework.Core.Exceptions
{
    public abstract class ApplicationExceptionBase : ExceptionBase, IApplicationException
    {
        protected ApplicationExceptionBase(string message, int exceptionFamilyCode)
            : base(message, (int) ExceptionTypeCodes.ApplicationException, exceptionFamilyCode)
        {
        }
    }
}