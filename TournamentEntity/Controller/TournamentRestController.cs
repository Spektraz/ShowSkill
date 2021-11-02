using System.Collections.Generic;
using StarSoccerSlim.BaseServices.HttpService.Controller;
using StarSoccerSlim.Meta.TournamentEntity.Dto;
using StarSoccerSlim.Meta.TournamentEntity.Service;
using StarSoccerSlim.Patterns.MVC.Factory;

namespace StarSoccerSlim.Meta.TournamentEntity.Controller
{
    public class TournamentRestController : BaseRestController<List<TournamentDto>>, IRequestController
    {
        protected override string RoutePath => "tournament/available";
        protected override HttpMethod HttpMethod => HttpMethod.Get;
        protected override bool UseToken => true;
        protected override bool UseId => true;

        public TournamentRestController()
        {
        }

        protected override void InitData()
        {
        }

        protected override void SetQuery()
        {
        }

        protected override void HandleModel(List<TournamentDto> baseRequestModel)
        {
            ServiceFactory.GetService<TournamentServiceLayer>().UpdateDto(baseRequestModel);
        }

    }
}