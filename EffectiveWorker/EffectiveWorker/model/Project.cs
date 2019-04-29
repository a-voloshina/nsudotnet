using System;

namespace EffectiveWorker.model
{
    public class Project
    {
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public int Premium { get; set; }
        public virtual Worker Worker { get; set; }
    }
}