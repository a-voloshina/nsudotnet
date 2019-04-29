using System.Collections.Generic;
using System.Linq;
using EffectiveWorker.model;

namespace EffectiveWorker.controller
{
    public class WorkerController
    {
        public Worker CreateWorker(Worker worker)
        {
            Worker newWorker;
            using (var db = new ApplicationContext())
            {
                newWorker = db.Workers.Add(worker).Entity;
                db.SaveChanges();
            }

            return newWorker;
        }

        public Worker FindWorker(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers.Find(id);
            }
        }

        public Worker FindWorkerBySurname(string surname)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers.First(w => w.Surname.Equals(surname));
            }
        }

        public Worker FindWorkerByName(string name)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers.First(w => w.Name.Equals(name));
            }
        }

        public Worker FindWorkerByFullName(string surname, string name)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers.First(w => w.Name.Equals(name) && w.Surname.Equals(surname));
            }
        }

        public List<Project> GetWorkerProjects(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers
                    .Find(id)
                    .Projects
                    .OrderByDescending(p => p.Premium)
                    .ToList();
            }
        }

        public Worker UpdateWorker(Worker worker)
        {
            Worker newWorker;
            using (var db = new ApplicationContext())
            {
                newWorker = db.Workers.Update(worker).Entity;
                db.SaveChanges();
            }

            return newWorker;
        }

        public void DeleteWorker(int id)
        {
            using (var db = new ApplicationContext())
            {
                var worker = FindWorker(id);
                db.Workers.Remove(worker);
                db.SaveChanges();
            }
        }
    }
}