using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        public const string INVALID_NAME_EXP_MSG = "A name should not be empty.";
        public const string MISSING_PLAYER_EXP_MSG = "Player {0} is not in {1} team.";
        private string name;
        private readonly ICollection<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(String.IsNullOrWhiteSpace (value))
                {
                    throw new ArgumentException(INVALID_NAME_EXP_MSG);
                }
                this.name = value;
            }
        }
        public int Rating
        {
            get
            {   if(players.Count>0)
                {
                    return (int)(Math.Round(this.players.Average(p => p.OverallSkill)));
                }
                return 0; 
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(p => p.Name == playerName);
            if(playerToRemove==null)
            {
                throw new InvalidOperationException(String.Format(MISSING_PLAYER_EXP_MSG, playerName, this.Name));
            }
            this.players.Remove(playerToRemove);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
