using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlinePollingSystem.Models
{
    public class Poll
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public string PostedBy { get; set; }

        [Required]
        public string UserIdentity { get; set; }
    }
}