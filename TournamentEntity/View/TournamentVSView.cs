using System.Linq;
using StarSoccerSlim.BaseServices.AuthorizationEntity.View;
using StarSoccerSlim.BaseServices.SceneService.Service;
using StarSoccerSlim.Meta.TournamentEntity.Service;
using StarSoccerSlim.Meta.UserEntity.Service;
using StarSoccerSlim.Meta.VersusEntity.MainVersusEntity.Service;
using StarSoccerSlim.Meta.VersusEntity.Services;
using StarSoccerSlim.Patterns.MVC.Controller;
using StarSoccerSlim.Patterns.MVC.Factory;

namespace StarSoccerSlim.Meta.TournamentEntity.View
{
    public class TournamentVSView : AuthView
    {
        protected override IController CreateController() => new TournamentVSController(this);
    }
    public class TournamentVSController : Controller<TournamentVSView, TournamentServiceLayer>
    {
        private readonly TimeBlockServiceLayer timeBlockServiceLayer;
        private readonly TournamentTypeServiceLayer tournamentTypeServiceLayer;
        public TournamentVSController(TournamentVSView view) : base(view)
        {
            InitService(ref timeBlockServiceLayer);
            InitService(ref tournamentTypeServiceLayer);
        }
        public override void AddListeners()
        {
            View.AddListener(HandleStartButtonClick);
        }
        public override void RemoveListeners()
        {
            View.RemoveListener(HandleStartButtonClick);
        }

        private void HandleStartButtonClick()
        {
            var context = serviceLayer.GetContext();
            var timeContext = timeBlockServiceLayer.GetContext();
            var tournamentTypeContext = tournamentTypeServiceLayer.GetContext();
            if (timeContext.IsBlocked)
            {
                ServiceFactory.GetService<VersusWaitServiceLayer>().UpdateDto(timeContext.IsBlocked);
                return;
            }
            foreach (var variable in context.Where(variable => 
                variable.IsCupStarted))
            {
                ServiceFactory.GetService<TournamentTypeServiceLayer>().UpdateDto(variable.CupsType);
                ServiceFactory.GetService<MatchModeServiceLayer>().UpdateDto(new MatchModelBuilder()
                    .SetCup(tournamentTypeContext.TournamentCupType)
                    .Build());
                LevelService.LoadScene(SceneType.StartVersusInternalScene);
            }
        }
        protected override void HandleServiceLayer()
        {
        }
    }
}

