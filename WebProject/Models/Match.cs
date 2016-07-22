using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        public DateTime Date { get; set; }

        public int HomeGoals { get; set; }

        public int AwayGoals { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public Team Home { get; set; }

        [ForeignKey("AwayTeamId")]
        public Team Away { get; set; }

        public int Spectators { get; set; }

        public int RefereeId { get; set; }

        public Referee Referee { get; set; }

        public string Stadion { get; set; }
    }
}