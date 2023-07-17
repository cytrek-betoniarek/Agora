using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.Common;

public record DiscussionsListResult(Domain.Discussion.Discussion[] Discussions);
