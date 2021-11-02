using StarSoccerSlim.BaseServices.SceneService.Service;
using StarSoccerSlim.Patterns.MVC.Service;

namespace StarSoccerSlim.Meta.TournamentEntity.Congratulation.Service
{
    public class TournamentWinStepServiceLayer : ServiceLayer<bool, bool>
    {
        public override SceneType ResetUnLoadScene => SceneType.Tournament;
        public override SceneType ResetScene => SceneType.RankScene;

        public override bool GetContext()
        {
            return dto;
        }
    } 
}

