using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Common.Authentication;

public interface IPasswordManager
{
    public string Hash(string password);

    public bool Verify(string password, string passwordHash);
}
