using System.Linq;

using System.Collections.Generic;
using CounterStrike.Models.Players;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        public Map()
        {

        }

        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players
                .Where(p => p.GetType().Name == nameof(Terrorist))
                .ToList();

            var counterTerrorists = players
                .Where(p => p.GetType().Name == nameof(CounterTerrorist))
                .ToList();

            while (terrorists.Any(t => t.IsAlive) 
                && counterTerrorists.Any(c => c.IsAlive))
            {
                foreach (var terrorist in terrorists)
                {
                    if (terrorist.IsAlive)
                    {
                        foreach (var counter in counterTerrorists)
                        {
                            if (counter.IsAlive)
                            {
                                int bullets = terrorist.Gun.Fire();
                                counter.TakeDamage(bullets);
                            }
                        }
                    }
                }

                foreach (var counter in counterTerrorists)
                {
                    if (counter.IsAlive)
                    {
                        foreach (var terrorist in terrorists)
                        {
                            if (terrorist.IsAlive)
                            {
                                int bullets = counter.Gun.Fire();
                                terrorist.TakeDamage(bullets);
                            }
                        }
                    }
                }
            }

            if (counterTerrorists.Any(x => x.IsAlive))
            {
                return "CounterTerrorist wins!";
            }

            return "Terrorist wins!";
        }
    }
}
