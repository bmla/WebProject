using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Match
    {
        public int MatchId { get; set; }

        [Required(ErrorMessage = "Date of match required", AllowEmptyStrings = false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The number of Home goals is required", AllowEmptyStrings = false)]
        [Display(Name = "Home Goals")]
        public int HomeGoals { get; set; }

        [Required(ErrorMessage = "The number of Away goals is required", AllowEmptyStrings = false)]
        [Display(Name = "Away Goals")]
        public int AwayGoals { get; set; }

        [Display(Name = "Home Team")]
        public int HomeTeamId { get; set; }

        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }

        [ForeignKey("HomeTeamId")]
        public Team Home { get; set; }

        [ForeignKey("AwayTeamId")]
        public Team Away { get; set; }

        public int Spectators { get; set; }

        [Display(Name = "Referee")]
        public int? RefereeId { get; set; }

        [DisplayFormat(NullDisplayText = "Referee not specified")]
        public Referee Referee { get; set; }

        public string Stadium { get; set; }

        public int Round { get; set; }

    }
}