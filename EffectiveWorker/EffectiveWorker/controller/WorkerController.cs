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

        public string CreateWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 4)
            {
                return "Wrong command format: should be 4 args";
            }

            return CreateWorker(new Worker
            {
                Surname = args[0],
                Name = args[1],
                Patronimic = args[2],
                Age = int.Parse(args[3])
            }).Id.ToString();
        }

        public Worker FindWorker(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers.Find(id);
            }
        }

        public string FindWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 args";
            }

            var worker = FindWorker(int.Parse(args[0]));
            return
                worker.Surname + " " + worker.Name + " " + worker.Patronimic;
        }

        public Worker FindWorkerBySurname(string surname)
        {
            using (var db = new ApplicationContext())
            {
                return db.Workers.First(w => w.Surname.Equals(surname));
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

        public string GetWorkerProjects(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 args";
            }

            var list = GetWorkerProjects(int.Parse(args[0]));
            var strList = "";
            foreach (var project in list)
            {
                strList += project.Name + " " + project.Premium + "\n";
            }

            return strList;
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

        public string UpdateWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 4)
            {
                return "Wrong command format: should be 4 args";
            }

            UpdateWorker(new Worker
            {
                Id = int.Parse(args[0]),
                Surname = args[1],
                Name = args[2],
                Patronimic = args[3]
            });

            return "worker updated";
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

        public string DeleteWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 args";
            }

            DeleteWorker(int.Parse(args[0]));
            return "worker deleted";
        }
    }
}