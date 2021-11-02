using StarSoccerSlim.BaseServices.HttpService.Service;
using StarSoccerSlim.BaseServices.MapperEntity.Service;
using StarSoccerSlim.Meta.TournamentEntity.Controller;
using StarSoccerSlim.Meta.TournamentEntity.Service;

namespace StarSoccerSlim.Meta.TournamentEntity.Mapper
{
    public class TournamentMapper : BaseMapper<TournamentBuyServiceLayer>
    {
        private TournamentBuyRestController tournamentBuyRestController;

        protected override void HandleServiceUpdate()
        {
            RestApiService.ApplyController(
                new TournamentBuyRestController(service.GetContext()));
        }
    }
}