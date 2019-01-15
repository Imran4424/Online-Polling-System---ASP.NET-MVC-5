using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePollingSystem.Models
{
    public class DetailsViewModel
    {
        public Poll Post { get; set; }

        public IEnumerable<Option> Options { get; set; }

        public Option NewOption { get; set; }
    }
}