using System.Collections.Generic;
using System.Linq;
using StarSoccerSlim.Meta.TournamentEntity.Dto;
using StarSoccerSlim.Meta.TournamentEntity.Model;
using StarSoccerSlim.Meta.UserEntity.Service;
using StarSoccerSlim.Patterns.MVC.Factory;
using StarSoccerSlim.Patterns.MVC.Service;
using UnityEngine;

namespace StarSoccerSlim.Meta.TournamentEntity.Service
{
    public class TournamentServiceLayer :ServiceLayer<TournamentModel, List<TournamentDto>, List<TournamentContext>>
    {
        public override List<TournamentContext> GetContext()
        {
            var content = dto;
            return content.Select(CreateContainer).ToList();
        }
        
        public Sprite GetSpriteCup(TournamentCupType tournamentCupType, bool state)
        {
            if (!state) return null;
            var list = Model.GetSpriteList(tournamentCupType);
            var sprite = list[0];
            return sprite;
        }

        public Sprite GetSpriteShadowCup(TournamentCupType tournamentCupType)
        {
            var list = Model.GetSpriteList(tournamentCupType);
            var sprite = list[4];
            return sprite;
        }
        private Sprite GetSpriteEmblem(TournamentCupType tournamentCupType)
          {
              var list = Model.GetSpriteList(tournamentCupType);
              var sprite = list[1];
              return sprite;
          }

        private Sprite GetSpriteLock(TournamentCupType tournamentCupType, bool state)
          {
              var list = Model.GetSpriteList(tournamentCupType);
              var count = state ? 3 : 2;
              var sprite = list[count];
              return sprite;
          }

        public Sprite GetSpriteOpenLock(TournamentCupType tournamentCupType)
        {
            var list = Model.GetSpriteList(tournamentCupType);
            var sprite = list[3];
            return sprite;
        }
        public bool CanBuyEmblem(TournamentCupType tournamentCupType)
        {
            return ServiceFactory.GetService<UserDtoServiceLayer>().TryBuyMedal(dto[(int)tournamentCupType-1].MedalPrice);
        }
        private TournamentContext CreateContainer(TournamentDto tournamentCupDto)
        {
            return new TournamentContext
            {
                CupsType = tournamentCupDto.TournamentCupType,
                TournamentCupsType = tournamentCupDto.CupsType,
                MedalPrice = tournamentCupDto.MedalPrice,
                WinCount = tournamentCupDto.WinCount,
                IsCanTakePart = tournamentCupDto.CanTakePart,
                IsEnoughMoney = tournamentCupDto.IsEnoughMoney,
                IsCupStarted = tournamentCupDto.CupStarted,
                CupSprite = GetSpriteCup(tournamentCupDto.TournamentCupType, tournamentCupDto.CanTakePart),
                EmblemSprite = GetSpriteEmblem(tournamentCupDto.TournamentCupType),
                LockSprite = GetSpriteLock(tournamentCupDto.TournamentCupType, tournamentCupDto.CupStarted),
                CupColor = SetColor(tournamentCupDto.CanTakePart, tournamentCupDto.IsEnoughMoney),
                WinMatchPosition = Model.TournamentPositionDataList(tournamentCupDto.TournamentCupType).ElementAt(tournamentCupDto.WinCount)
            };
        }
        private TournamentServiceLayer tournamentServiceLayer;

        private Color SetColor(bool haveEmblem, bool haveMoney)
        {
            var color = Color.black;
            if (haveEmblem && ! haveMoney)
            {
                color =  Color.gray;
            }

            if (haveMoney && haveEmblem)
            {
                color = Color.white;
            }

            return color;
        }
    }
    public struct TournamentContext
    {
        public TournamentCupType CupsType { get; set; } //type of cup
        public int MedalPrice { get; set; } // medal for take a take a part in current tournament
        public int WinCount { get; set; }
        public bool IsCanTakePart { get; set; }// canBuy // canPlay
        public bool IsCupStarted { get; set; }
        public bool IsEnoughMoney { get; set; }
        public string TournamentCupsType { get; set; }
        public Sprite CupSprite { get; set; }
        public Sprite EmblemSprite { get; set; }
        public Sprite LockSprite { get; set; }
        public Color CupColor { get; set; }
        
        public Vector3 WinMatchPosition { get; set; }

    }

}