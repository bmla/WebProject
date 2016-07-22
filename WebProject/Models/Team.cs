using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required, MaxLength(256)]
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        

        //public Team(string teamName, List<Player> players)
        //{
        //    TeamName = teamName;
        //    Players = players;
        //}
    }
}