using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoccerProject.Models
{
    public class Player
    {
        public string TeamName { get; set; }
        public string PlayerName { get; set; }
        public int Age { get; set; }
        public int ShirtNum { get; set; }

        public Player(string teamName, string playerName, int age, int shirtNum)
        {
            TeamName = teamName;
            PlayerName = playerName;
            Age = age;
            ShirtNum = shirtNum;
        }
    }
}