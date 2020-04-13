using System.Collections.Generic;

using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps.Contracts
{

    public interface IMap
    {
        string Start(ICollection<IPlayer> players);
    }
}
