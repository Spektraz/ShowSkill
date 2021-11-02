using System;
using System.Collections.Generic;
using StarSoccerSlim.Patterns.MVC.Model;
using StarSoccerSlim.Utils.Array;
using UnityEngine;

namespace StarSoccerSlim.Meta.TournamentEntity.Model
{
    [Serializable]
    [CreateAssetMenu(fileName = "TournamentData", menuName = "Data/Player/Meta/Tournament/TournamentData")]
    public class TournamentModel : ScriptableObject, IModel
    {
        [SerializeField] private TournamentDataList tournamentDataList;
        [SerializeField] private TournamentPositionDataList tournamentPositionDataList;
        public TournamentContext GetTournamentPreset(TournamentCupType tournamentName)
        {
            return tournamentDataList.GetById(tournamentName);
        }
        public List<Vector3> TournamentPositionDataList(TournamentCupType tournamentName)
        {
            return tournamentPositionDataList.GetById(tournamentName);
        }
        public List<Sprite> GetSpriteList(TournamentCupType tournamentCupType)
        {
            var listSprite = new List<Sprite>();
            var internalTutorialPreset = tournamentDataList.GetById(tournamentCupType);
            listSprite.Add(internalTutorialPreset.CupSprite);
            listSprite.Add(internalTutorialPreset.EmblemSprite); 
            listSprite.Add(internalTutorialPreset.LockCloseSprite); 
            listSprite.Add(internalTutorialPreset.LockOpenSprite);
            listSprite.Add(internalTutorialPreset.CupShadow);
            return listSprite;
        }

     
        [Serializable]
        public class TournamentDataList : DataList<TournamentPreset, TournamentContext, TournamentCupType> { }

        [Serializable]
        public class TournamentPreset : InternalData<TournamentCupType, TournamentContext>
        {
        }
        [Serializable]
        public class TournamentContext
        {
            [SerializeField] private Sprite cupSprite;
            [SerializeField] private Sprite cupShadow;
            [SerializeField] private Sprite emblemSprite;

            [SerializeField]  private Sprite lockCloseSprite;
            [SerializeField] private Sprite lockOpenSprite;
            public Sprite CupSprite => cupSprite;
            public Sprite EmblemSprite => emblemSprite;
            public Sprite  LockCloseSprite => lockCloseSprite;
            public Sprite LockOpenSprite => lockOpenSprite;
            public Sprite CupShadow => cupShadow;
        }
    }
    [Serializable]
    public class TournamentPositionDataList : DataList<TournamentPositionPreset,  List<Vector3>, TournamentCupType> { }

    [Serializable]
    public class TournamentPositionPreset : InternalData<TournamentCupType, List<Vector3>>
    {
    }
    [Serializable]
    public enum TournamentCupType
    {
        NO_CUP = 0,
        BRONZE = 1,
        SILVER = 2,
        GOLD = 3,
        WORLD = 4,
        STAR = 5,
    }
    
}
