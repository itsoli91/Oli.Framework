using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oli.Framework.Core.Providers
{
    public interface IEmailProvider
    {
        Task SendEmailAsync(string email, string title, string body);
        Task SendEmailsAsync(IEnumerable<string> emails, string title, string body);
    }
}