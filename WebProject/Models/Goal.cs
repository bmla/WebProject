using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class Goal
    {
        public int GoalId { get; set; }

        public int Time { get; set; }

        public int PlayerId { get; set; }

        public Player Player;

        public int MatchId { get; set; }

        public Match Match { get; set; }

    }
}