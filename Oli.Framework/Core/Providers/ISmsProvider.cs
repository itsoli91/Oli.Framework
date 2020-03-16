using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oli.Framework.Core.Providers
{
    public interface ISmsProvider
    {
        Task SendTextAsync(string msisdn, string text);
        Task SendTextsAsync(IEnumerable<string> msisdns, string text);
    }
}