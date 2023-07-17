using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Queries.Common;
using Agora.Application.Discussion.Queries.MyDiscussionsList;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.MyDiscussionsList;

public class MyDiscussionsListQueryHandler : IRequestHandler<MyDiscussionsListQuery, ErrorOr<DiscussionsListResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public MyDiscussionsListQueryHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DiscussionsListResult>> Handle(MyDiscussionsListQuery query, CancellationToken cancellationToken)
    {
        return new DiscussionsListResult(await _discussionRepository.MyListAsync(query.UserId));
    }
}
