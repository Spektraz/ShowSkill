using StarSoccerSlim.BaseServices.SceneService.Service;
using StarSoccerSlim.Patterns.MVC.Service;

namespace StarSoccerSlim.Meta.TournamentEntity.Service
{
    public class TournamentBuyServiceLayer : ServiceLayer<ITournamentCupPurchaseContext,ITournamentCupPurchaseContext>
    {
        public override SceneType ResetUnLoadScene => SceneType.Tournament;
        public override ITournamentCupPurchaseContext GetContext()
        {
            return dto;
        }
    }
    public interface ITournamentCupPurchaseContext
    {
        string TournamentCupType { get; set; }
    }
}