using System.Collections.Generic;

namespace EffectiveWorker.model
{
    public class Worker
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }

        public virtual List<Project> Projects { get; set; }
    }
}