using System.Linq;
using StarSoccerSlim.Meta.TournamentEntity.Service;
using StarSoccerSlim.Meta.UserEntity.Service;
using StarSoccerSlim.Patterns.MVC.Controller;
using UnityEngine;

namespace StarSoccerSlim.Meta.TournamentEntity.View
{
    public class TournamentCharacterView : Patterns.MVC.View.View
    {
        [SerializeField] private SpriteRenderer characterImage;
        [SerializeField] private SpriteRenderer eyesImage;
        public void SetContext(UserContext context)
        {
            characterImage.sprite = context.CharacterSprite;
            eyesImage.sprite = context.EyeSprite;
        }
        public void SwitchCharacter(bool state)
        {
            characterImage.gameObject.SetActive(state);
        }

        public void SetPosition(Vector3 vector)
        {
            gameObject.transform.localPosition = vector;
        }
        protected override IController CreateController() => new TournamentCharacterController(this);
    }
    public class TournamentCharacterController : Controller<TournamentCharacterView, TournamentServiceLayer>
    {
        private readonly UserDtoServiceLayer userDtoServiceLayer;
        public TournamentCharacterController(TournamentCharacterView view) : base(view)
        {
            InitService(ref userDtoServiceLayer);
        }

        protected override void HandleServiceLayer()
        {
            if(!View.gameObject.activeInHierarchy) return;
            var context = serviceLayer.GetContext();
            foreach (var tournamentContext in context.Where(t => t.IsCupStarted))
            {
                SetPosition( (int) tournamentContext.CupsType-1);
                View.SwitchCharacter(true);
            }
            View.SetContext(userDtoServiceLayer.GetContext());
        }

        private void SetPosition(int winCount)
        {
            View.SetPosition(serviceLayer.GetContext()[winCount].WinMatchPosition);
        }
    }
}
