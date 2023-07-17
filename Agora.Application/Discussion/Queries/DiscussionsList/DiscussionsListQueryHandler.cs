using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Queries.Common;
using Agora.Domain.Discussion.Entities;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.DiscussionsList;

public class DiscussionsListQueryHandler : IRequestHandler<DiscussionsListQuery, ErrorOr<DiscussionsListResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public DiscussionsListQueryHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DiscussionsListResult>> Handle(DiscussionsListQuery query, CancellationToken cancellationToken)
    {
        var discussions = await _discussionRepository.ListAsync();
        return new DiscussionsListResult(discussions);
    }
}
