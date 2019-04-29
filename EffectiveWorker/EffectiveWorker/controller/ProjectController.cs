using System.Collections.Generic;
using System.Linq;
using EffectiveWorker.model;

namespace EffectiveWorker.controller
{
    public class ProjectController
    {
        public Project CreateProject(Project project)
        {
            Project newProject;
            using (var db = new ApplicationContext())
            {
                newProject = db.Projects.Add(project).Entity;
                db.SaveChanges();
            }

            return newProject;
        }

        public string CreateProject(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 3)
            {
                return "Wrong command format: should be 3 args";
            }

            return CreateProject(new Project
            {
                WorkerId = int.Parse(args[0]),
                Name = args[1],
                Premium = int.Parse(args[2])
            }).Id.ToString();
        }

        public Project FindProject(int id)
        {
            using (var db = new ApplicationContext())
            {
                return db.Projects.Find(id);
            }
        }

        public string FindProject(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 1)
            {
                return "Wrong command format: should be 1 arg";
            }

            var project = FindProject(int.Parse(args[0]));
            return project.Name + " " + project.Premium + " " + project.Worker.Name + " " + project.Worker.Name +
                   " " + project.Worker.Patronimic;
        }

        public List<Project> GetAllProjects()
        {
            using (var db = new ApplicationContext())
            {
                return db.Projects
                    .OrderBy(p => p.Premium)
                    .ToList();
            }
        }

        public Project UpdateProject(Project project)
        {
            Project newProject;
            using (var db = new ApplicationContext())
            {
                newProject = db.Projects.Update(project).Entity;
                db.SaveChanges();
            }

            return newProject;
        }

        public string UpdateProject(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 3)
            {
                return "Wrong command format: should be 3 args";
            }

            UpdateProject(new Project
            {
                WorkerId = int.Parse(args[0]),
                Name = args[1],
                Premium = int.Parse(args[2])
            });
            return "project updated";
        }

        public void DeleteProject(Project project)
        {
            using (var db = new ApplicationContext())
            {
                db.Projects.Remove(project);
                db.SaveChanges();
            }
        }

        public string DeleteProject(string argsStr)
        {
            var args = argsStr.Split(",");
            if (args == null || args.Length != 3)
            {
                return "Wrong command format: should be 3 args";
            }

            DeleteProject(new Project
            {
                WorkerId = int.Parse(args[0]),
                Name = args[1],
                Premium = int.Parse(args[2])
            });
            return "project deleted";
        }
    }
}