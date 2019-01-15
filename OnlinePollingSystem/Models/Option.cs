using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinePollingSystem.Models
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        public string OptionName { get; set; }


        public List<string> CheckedBy { get; set; }

        [Required]
        public int VoteCount { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int PostId { get; set; }

        public Option()
        {
            VoteCount = 0;
            CheckedBy = new List<string>();
            Status = false;
        }
    }
}