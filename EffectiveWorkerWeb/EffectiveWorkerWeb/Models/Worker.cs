using System;
using System.Collections.Generic;

namespace WebApplication
{
    public partial class Worker
    {
        public Worker()
        {
            Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public int Seniority { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
