using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace SoccerProject.Models
{
    public sealed class DBSoccerProject
    {
        public SqlConnection connection()
        {
            //from Web.Config
            string ConStr = ConfigurationManager.ConnectionStrings["localDB"].ConnectionString;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            return con;
        }

        public List<Team> GetTeams()
        {
            List<Team> teams = new List<Team>();
            Team t = null;
            SqlConnection con = connection();
            string query = "select * from dbo.Teams";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Team(Convert.ToInt16(reader["id_team"]), Convert.ToString(reader["club_name"]), Convert.ToInt16(reader["wins"]), Convert.ToInt16(reader["draws"]), Convert.ToInt16(reader["loses"]), Convert.ToInt16(reader["points"]));
                teams.Add(t);
            }
            con.Close();
            return teams;
        }

        public Team GetTeam(int id_team)
        {
            Team t = null;
            SqlConnection con = connection();
            string query = $"select * from dbo.Teams where id_team={id_team}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                t = new Team(Convert.ToInt16(reader["id_team"]), Convert.ToString(reader["club_name"]), Convert.ToInt16(reader["wins"]), Convert.ToInt16(reader["draws"]), Convert.ToInt16(reader["loses"]), Convert.ToInt16(reader["points"]));
            }
            return t;
        }

        public int Post(Team team)
        {
            SqlConnection con = connection();
            string query = "INSERT INTO Teams (club_name,wins,draws,loses) " + "VALUES('" + team.ClubName + "'," + team.Win + "," + team.Draw + "," + team.Lose + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Put(int id, Team team)
        {
            int res = 0;
            SqlConnection con = connection();
            List<Team> teams = GetTeams();
            Team t = teams.SingleOrDefault(ta => ta.IdTeam == id);
            if (t != null)
            {
                string qu = $"UPDATE Teams Set club_name='{team.ClubName}', wins={team.Win}, draws={team.Draw}, loses={team.Lose} where id_team={id}";
                con.Close();
                SqlCommand updateCom = new SqlCommand(qu, con);
                con.Open();
                res = updateCom.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                throw new Exception("Not Exist");
            }
            return res;
        }

        public int Delete(int id)
        {
            int res = 0;
            SqlConnection con = connection();
            string query = $"Delete From dbo.Teams where id_team={id}";
            SqlCommand cmd = new SqlCommand(query, con);
            res = cmd.ExecuteNonQuery();
            con.Close();
            if (res == 0)
            {
                throw new Exception("Not Exist");
            }
            return res;
        }


















        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            User u = null;
            SqlConnection con = connection();
            string query = "select * from dbo.Users";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                u = new User(Convert.ToInt16(reader["Id"]), Convert.ToString(reader["username"]), Convert.ToString(reader["password"]));
                users.Add(u);
            }
            con.Close();
            return users;
        }

        public User GetUser(int id)
        {
            User u = null;
            SqlConnection con = connection();
            string query = $"select * from dbo.Users where Id={id}";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                u = new User(Convert.ToInt16(reader["Id"]), Convert.ToString(reader["username"]), Convert.ToString(reader["password"]));
            }
            return u;
        }
    }
}