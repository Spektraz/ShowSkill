using System;
using System.Collections.Generic;
using System.Linq;
using StarSoccerSlim.Meta.TournamentEntity.Model;
using StarSoccerSlim.Meta.TournamentEntity.Service;
using StarSoccerSlim.Meta.UserEntity.Service;
using StarSoccerSlim.Patterns.MVC.Controller;
using StarSoccerSlim.Patterns.MVC.Factory;
using StarSoccerSlim.Utils.Ui;
using UnityEngine;

namespace StarSoccerSlim.Meta.TournamentEntity.View
{
    public class TournamentBuyView : Patterns.MVC.View.View, ITournamentCupPurchaseContext
    {
        [SerializeField] private List<TournamentLockView> tournamentLockView;
        public void SetTournament(TournamentContext tournamentContext)
        {

            for (var i = (int) tournamentContext.CupsType - 1; i >= 0; i--)
            {
                tournamentLockView[i].SetAnimator();
            }
            for (var i = 0; i < 4; i++)
            {
                tournamentLockView[i].SetStateAndColor(false);
                tournamentLockView[i].StateLockButton(false);
            }
            tournamentLockView[(int) tournamentContext.CupsType-1].SetStateAndColor(true);
        }
        public void SetData(List<TournamentContext> tournamentContextEmblem)
        {
            for (var i = 0; i < tournamentContextEmblem.Count; i++)
            {
                tournamentLockView[i].SetImage(tournamentContextEmblem[i]);
            }
        }
        public void SetLock(Sprite sprite,TournamentCupType tournamentCupType )
        {
            tournamentLockView[(int)tournamentCupType-1].SetLock(sprite);
        }
        public void AddListeners(Action[] actions)
        {
            for (var i = 0; i < tournamentLockView.Count; i++)
            {
                tournamentLockView[i].AddListener(actions[i]);
            }
        }
        public void RemoveListener()
        {
            foreach (var lockView in tournamentLockView)
            {
                lockView.RemoveListener();
            }
        }
        public string TournamentCupType { get; set; }
        protected override IController CreateController() => new TournamentBuyController(this);
    }
    [Serializable]
    public class TournamentButtonInputView : ButtonInputView<TournamentCupType>
    {
       
    }
    public class TournamentBuyController : Controller<TournamentBuyView, TournamentServiceLayer>
    {
        public TournamentBuyController(TournamentBuyView view) : base(view)
        {
            View.SetData(serviceLayer.GetContext()); 
        }

        public override void RemoveListeners()
        {
            base.RemoveListeners();
            View.RemoveListener();
        }
        private void SetTournament(TournamentContext tournamentContext)
        {
            if (!tournamentContext.IsCanTakePart)
            {
                return;
            }

            if (!tournamentContext.IsEnoughMoney)
            {
                ServiceFactory.GetService<UserShopPurchaseServiceLayer>().UpdateDto(false);
                return;
            }
            
            
            View.SetLock(serviceLayer.GetSpriteOpenLock(tournamentContext.CupsType), tournamentContext.CupsType);
            View.SetTournament(tournamentContext);
            View.TournamentCupType = tournamentContext.TournamentCupsType;
            serviceLayer.CanBuyEmblem(tournamentContext.CupsType);
            ServiceFactory.GetService<UserShopPurchaseServiceLayer>().UpdateDto(true); // tell us that we buy cup
            ServiceFactory.GetService<TournamentBuyServiceLayer>().UpdateDto(View); // tell us which cup was bought by us 
        }
        protected override void HandleServiceLayer()
        {
            var actions = new List<Action>();
            var context = serviceLayer.GetContext();
            context.ForEach(x => actions.Add(() => SetTournament(x)));
            foreach (var variable in context.Where(variable => variable.IsCupStarted))
            {
                ServiceFactory.GetService<TournamentTypeServiceLayer>().UpdateDto(variable.CupsType);
            }
            View.AddListeners(actions.ToArray());
        }
    }
}
