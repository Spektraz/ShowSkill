using StarSoccerSlim.Meta.AnimatorEntity.View;
using UnityEngine;

namespace StarSoccerSlim.Meta.TournamentEntity.View
{
    public class TournamentLockAnimatorView : BaseAnimatorController
    {
        private static readonly int AnimatorJumpParameter = Animator.StringToHash("Jump");

        public void SetAnimator()
        {
            SetTrigger(AnimatorJumpParameter);
        }
    }
}
