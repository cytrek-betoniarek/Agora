using Agora.Contracts.Discussion.GetRequests.Response.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Contracts.Discussion.GetRequests.Response;

public record DiscussionsListResponse(DiscussionResponse[] Discussions);
