﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoccerProject.Models
{
    public class Team
    {
        public int IdTeam { get; set; }
        public string ClubName { get; set; }
        public string Info { get; set; }
        public string ImgClub { get; set; }
        public int Win { get; set; }
        public int Draw { get; set; }
        public int Lose { get; set; }
        public int Point { get; set; }

        public Team(int idTeam, string clubName,string info,string img, int wins, int draws, int loses, int points)
        {
            IdTeam = idTeam;
            ClubName = clubName;
            Info = info;
            ImgClub = img;
            Win = wins;
            Draw = draws;
            Lose = loses;
            Point = points;
        }
    }
}