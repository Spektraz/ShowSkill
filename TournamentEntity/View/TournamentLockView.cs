using System;
using StarSoccerSlim.Meta.TournamentEntity.Service;
using UnityEngine;
using UnityEngine.UI;

namespace StarSoccerSlim.Meta.TournamentEntity.View
{
    public class TournamentLockView : MonoBehaviour
    {
        [SerializeField] private TournamentLockAnimatorView tournamentLockAnimatorView;
        [SerializeField] private Image lockImage;
        [SerializeField] private Image emblemImage;
        [SerializeField] private Image cupImage;
        [SerializeField] private Image cupShadowImage;
        [SerializeField] private Image lightImage;
        [SerializeField] private Button lockButton;

        public void SetImage(TournamentContext tournamentContextEmblem)
        {
            lockImage.sprite = tournamentContextEmblem.LockSprite;
            emblemImage.sprite = tournamentContextEmblem.EmblemSprite;
            cupImage.sprite = tournamentContextEmblem.CupSprite;
            cupImage.enabled = tournamentContextEmblem.IsCanTakePart;
            cupShadowImage.enabled = tournamentContextEmblem.IsCanTakePart;
            lightImage.enabled = tournamentContextEmblem.IsCanTakePart && tournamentContextEmblem.IsEnoughMoney;
            emblemImage.color = tournamentContextEmblem.CupColor;
            lockButton.enabled = !tournamentContextEmblem.IsCupStarted;
        }
        public void SetStateAndColor(bool state)
        {
            cupImage.enabled = state;
            cupShadowImage.enabled = state;
            emblemImage.color = !state ? Color.black : Color.white;
        }
        public void SetLock(Sprite sprite)
        {
            lockImage.sprite = sprite;
        }
        public void StateLockButton(bool state)
        {
            lockButton.enabled = state;
        }

        public void SetAnimator()
        {
            tournamentLockAnimatorView.SetAnimator();
        }
        public void AddListener(Action action)
        {
            lockButton.onClick.AddListener(action.Invoke);
        }
        public void RemoveListener()
        {
            lockButton.onClick.RemoveAllListeners();
        }
    }
}
