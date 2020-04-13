﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild()
        {
            this.roster = new List<Player>();
        }

        public Guild(string name, int capacity)
            : this()
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Capacity > this.Count)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);
            if (player != null)
            {
                this.roster.Remove(player);
                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.roster.FirstOrDefault(p => p.Name == name);

            if (player != null && player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {
            Player[] players = this.roster
                .Where(p => p.Class == clas)
                .ToArray();

            this.roster.RemoveAll(p => p.Class == clas);

            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
