﻿using Agora.Domain.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Common.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(Account account);
}
