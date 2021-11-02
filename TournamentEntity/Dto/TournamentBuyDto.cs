using System;
using Newtonsoft.Json;

namespace StarSoccerSlim.Meta.TournamentEntity.Dto
{
    [Serializable]
    public class TournamentBuyDto : Patterns.MVC.Dto.Dto
    {
        [JsonProperty("successfully")] public bool SuccessfullyBought { get; private set; }
    }
}