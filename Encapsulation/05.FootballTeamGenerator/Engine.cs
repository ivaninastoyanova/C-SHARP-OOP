using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Engine
    {
        public const string MISSING_TEAM_EXC_MSG = "Team {0} does not exist.";
        private readonly ICollection<Team> teams ;
        public Engine()
        {
            this.teams = new List<Team>();
        }
        public void Run()
        {
            string command;
            while((command=Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(";").ToArray();
                string commandType = commandArgs[0];
                try
                {
                    if (commandType == "Team")
                    {
                        this.CreateTeam(commandArgs.Skip(1).ToList());
                    }
                    else if (commandType == "Add")
                    {
                        this.AddPlayerToTeam(commandArgs.Skip(1).ToList());
                    }
                    else if (commandType == "Remove")
                    {
                        this.RemovePlayerFromTeam(commandArgs.Skip(1).ToList());
                    }
                    else if(commandType=="Rating")
                    {
                        this.RateTeam(commandArgs.Skip(1).ToList());
                    }
                }
                catch(ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }

            }
        }
        private void CreateTeam(IList<string> commandArgs)
        {
            string teamName = commandArgs[0];
            Team team = new Team(teamName);
            this.teams.Add(team);
        }
        private void AddPlayerToTeam (IList<string> commandArgs)
        {
            string teamName = commandArgs[0];
            string playerName = commandArgs[1];
            this.ValidateTeamExists(teamName);
            Stats stats = this.BuildStats(commandArgs.Skip(2).ToArray());
            Player player = new Player(playerName, stats);
            Team team = this.teams.First(t => t.Name == teamName);
            team.AddPlayer(player);
        }
        private Stats BuildStats (string[] statsString)
        {
            int endurance = int.Parse(statsString[0]);
            int sprint = int.Parse(statsString[1]);
            int dribble = int.Parse(statsString[2]);
            int passing = int.Parse(statsString[3]);
            int shooting = int.Parse(statsString[4]);
            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);
            return stats;
        }
        private void ValidateTeamExists(string teamName)
        {
            if(!this.teams.Any (t =>t.Name == teamName))
            {
                throw new InvalidOperationException(String.Format(MISSING_TEAM_EXC_MSG, teamName));
            }
        }
        private void RemovePlayerFromTeam (IList <string> commandArgs)
        {
            string teamName = commandArgs[0];
            string playerName = commandArgs[1];
            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);
            team.RemovePlayer(playerName);
        }
        private void RateTeam(IList<string> commandArg)
        {
            string teamName = commandArg[0];
            this.ValidateTeamExists(teamName);
            Team team = this.teams.First(t => t.Name == teamName);
            Console.WriteLine(team);
        }
    }
}
