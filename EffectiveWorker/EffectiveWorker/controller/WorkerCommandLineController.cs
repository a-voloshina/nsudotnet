using EffectiveWorker.model;

namespace EffectiveWorker.controller
{
    public class WorkerCommandLineController : WorkerController
    {
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
                Seniority = int.Parse(args[3])
            }).Id.ToString();
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

        public string UpdateWorker(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 5)
            {
                return "Wrong command format: should be 5 args";
            }

            UpdateWorker(new Worker
            {
                Id = int.Parse(args[0]),
                Surname = args[1],
                Name = args[2],
                Patronimic = args[3],
                Seniority = int.Parse(args[4])
            });

            return "worker updated";
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