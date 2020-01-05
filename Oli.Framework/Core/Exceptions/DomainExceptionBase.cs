namespace Oli.Framework.Core.Exceptions
{
    public class DomainExceptionBase : ExceptionBase, IDomainException
    {
        protected DomainExceptionBase(string message, int exceptionFamilyCode)
            : base(message, (int) ExceptionTypeCodes.DomainException, exceptionFamilyCode)
        {
        }
    }
}