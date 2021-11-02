using StarSoccerSlim.Meta.AnimatorEntity.View;
using StarSoccerSlim.Meta.TournamentEntity.Congratulation.Service;
using StarSoccerSlim.Patterns.MVC.Controller;
using UnityEngine;

namespace StarSoccerSlim.Meta.TournamentEntity.Congratulation.View
{
    public class CongratulationTournamentAnimatorView : BaseAnimatorView
    {
        protected override IController CreateController() => new CongratulationTournamentAnimatorController(this);

        private class CongratulationTournamentAnimatorController : Controller<CongratulationTournamentAnimatorView, TournamentWinStepServiceLayer>
        {
            private static readonly int AnimatorLeftParameter = Animator.StringToHash("Left");
            private static readonly int AnimatorRightParameter = Animator.StringToHash("Right");
            public CongratulationTournamentAnimatorController(CongratulationTournamentAnimatorView view) : base(view)
            {
            }
            protected override void HandleServiceLayer()
            {
                var context = serviceLayer.GetContext();
                if (!context) return;
                SetRandomIndex();
            }

            private void SetRandomIndex()
            {
                var random = Random.Range(1, 3);
                View.SetTrigger(random %2 ==0? AnimatorLeftParameter:AnimatorRightParameter);
            }
        }
    }
}
