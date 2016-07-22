using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "Player must have a firstname", AllowEmptyStrings = false), MaxLength(256)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Player must have a lastname", AllowEmptyStrings = false), MaxLength(256)]
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Player number must be specified"), Range(0,99)]
        public int PlayerNumber { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }

        //public Player(string firstname, string lastname, DateTime birthday, int playerNumber)
        //{
        //    Firstname = firstname;
        //    Lastname = lastname;
        //    Birthday = birthday;
        //    PlayerNumber = playerNumber;
        //}
    }
}