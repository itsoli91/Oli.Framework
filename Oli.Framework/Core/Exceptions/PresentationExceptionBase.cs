namespace Oli.Framework.Core.Exceptions
{
    public class PresentationExceptionBase : ExceptionBase, IApplicationException
    {
        protected PresentationExceptionBase(string message, int exceptionFamilyCode)
            : base(message, (int) ExceptionTypeCodes.PresentationException, exceptionFamilyCode)
        {
        }
    }
}