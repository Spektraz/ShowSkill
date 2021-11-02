using StarSoccerSlim.BaseServices.SceneService.Service;
using StarSoccerSlim.Core.PlayerEntity.CharacterEntity.Model;
using StarSoccerSlim.Meta.TournamentEntity.Model;
using StarSoccerSlim.Patterns.MVC.Service;
using StarSoccerSlim.Utils.Parse;

namespace StarSoccerSlim.Meta.TournamentEntity.Service
{
    public class TournamentTypeServiceLayer : ServiceLayer<TournamentCupType,TournamentTypeContext >
    {
        public override SceneType ResetUnLoadScene => SceneType.Tournament;

        public override TournamentTypeContext GetContext()
        {
            return new TournamentTypeContext()
            {
                TournamentCupType = dto,
                EmblemsType = dto.ConvertToEmblem()
            };
        }
    }
    
    public class TournamentTypeContext
    {
        public TournamentCupType TournamentCupType { get; set; }
        public EmblemsType EmblemsType { get; set; }
    }
}