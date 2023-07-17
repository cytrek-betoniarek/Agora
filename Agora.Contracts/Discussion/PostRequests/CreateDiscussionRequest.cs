﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Contracts.Discussion.PostRequests;

public record CreateDiscussionRequest(
    string title,
    string description
    );
