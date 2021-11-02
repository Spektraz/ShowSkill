using System;
using Newtonsoft.Json;
using StarSoccerSlim.Meta.TournamentEntity.Model;
using StarSoccerSlim.Utils.Parse;

namespace StarSoccerSlim.Meta.TournamentEntity.Dto
{
    [Serializable]
    public class TournamentDto : Patterns.MVC.Dto.Dto
    {   
            [JsonProperty("cups_type")] public string CupsType { get; private set; } //type of cup
            [JsonProperty("medal_price")] public int MedalPrice { get; private set; } // medal for take a take a part in current tournament
            [JsonProperty("win_count")] public int WinCount { get; private set; }
            [JsonProperty("can_take_part")] public bool CanTakePart  { get; private set; } // canBuy // canPlay
            [JsonProperty("cup_started")] public bool CupStarted { get; private set; }
            [JsonProperty("is_enough_money")] public bool IsEnoughMoney { get; private set; }

            [JsonIgnore] private JsonTypeParser<TournamentCupType> tournamentCupType;

            [JsonIgnore]  public TournamentCupType TournamentCupType
            {
                get
                {
                    if (tournamentCupType == null)
                    {
                        tournamentCupType = new JsonTypeParser<TournamentCupType>(CupsType);
                    }

                    return tournamentCupType.Value;
                }
            }
        }
}
