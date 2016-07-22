using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required, MaxLength(256)]
        public string Firstname { get; set; }
        [Required, MaxLength(256)]
        public string Lastname { get; set; }
        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }
        [Required, Range(0,99)]
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