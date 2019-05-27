using System;
using System.Collections.Generic;

namespace WebApplication
{
    public partial class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Premium { get; set; }
        public int? WorkerId { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
