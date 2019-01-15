using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlinePollingSystem.Models
{
    public class NewPollViewModel
    {
        public Poll Post { get; set; }

        public Option OptionOne { get; set; }

        public Option OptionTwo { get; set; }

        public Option OptionThree { get; set; }
    }
}