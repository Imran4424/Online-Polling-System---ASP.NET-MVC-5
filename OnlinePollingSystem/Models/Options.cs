using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinePollingSystem.Models
{
    public class Options
    {
        public int Id { get; set; }

        [Required]
        public string OptionName { get; set; }


        public string CheckedBy { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}