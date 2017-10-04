using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbnLookup
{
    public interface IDialer
    {
        Task<bool> DialAsync(string number);
    }
}
