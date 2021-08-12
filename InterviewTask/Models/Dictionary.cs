using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace InterviewTask.Models
{
    public partial class Dictionary
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Hungarian { get; set; }
        public string Spanish { get; set; }
        public string Chinese { get; set; }
        public string Portuguese { get; set; }
    }
}
