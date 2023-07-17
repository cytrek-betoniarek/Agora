using Agora.Application.Common.Persistence;
using Agora.Application.Discussion.Queries.Common;
using Agora.Application.Discussion.Queries.MyFavouritesList;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.Application.Discussion.Queries.MyFavouritesList;

public class MyFavouritesListQueryHandler : IRequestHandler<MyFavouritesListQuery, ErrorOr<DiscussionsListResult>>
{
    private readonly IDiscussionRepository _discussionRepository;

    public MyFavouritesListQueryHandler(IDiscussionRepository discussionRepository)
    {
        _discussionRepository = discussionRepository;
    }

    public async Task<ErrorOr<DiscussionsListResult>> Handle(MyFavouritesListQuery query, CancellationToken cancellationToken)
    {
        return new DiscussionsListResult(await _discussionRepository.MyFavouriteListAsync(query.UserId));
    }
}
