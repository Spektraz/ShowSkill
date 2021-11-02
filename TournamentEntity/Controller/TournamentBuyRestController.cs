using StarSoccerSlim.BaseServices.HttpService.Controller;
using StarSoccerSlim.Meta.TournamentEntity.Dto;
using StarSoccerSlim.Meta.TournamentEntity.Service;

namespace StarSoccerSlim.Meta.TournamentEntity.Controller
{
    public sealed class TournamentBuyRestController  : BaseRestController<TournamentBuyDto, ITournamentCupPurchaseContext>
    {
        protected override HttpMethod HttpMethod => HttpMethod.Put;
        protected override bool UseToken => true;
        protected override bool UseId => true;
        protected override string RoutePath => "tournament/pay";
        protected override void SetQuery()
        {
            SetQueryParameters(QueryParams.CupType, context.TournamentCupType);
        }

        protected override void HandleModel(TournamentBuyDto baseRequestModel)
        {
            new TournamentRestController();
        }
        public TournamentBuyRestController(ITournamentCupPurchaseContext purchaseContext) : base(purchaseContext)
        {
        }

        protected override void InitData(ITournamentCupPurchaseContext context)
        {
        }
    }
}