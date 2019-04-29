using System;
using System.Linq.Expressions;
using EffectiveWorker.controller;
using EffectiveWorker.model;

namespace EffectiveWorker
{
    class Program
    {
        //create worker Трегубов,Артем,Сергеевич
        //create project 3,Миниатюрный 3D-принтер,300
        //get worker 5
        //get workers
        //get projects
        //delete worker 1
        //update worker 2 
        static void Main(string[] args)
        {
            var workerController = new WorkerController();
            var projectController = new ProjectController();

            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                string res;
                if (line == null || line.Equals("exit"))
                {
                    break;
                }

                try
                {
                    if (line.StartsWith("create"))
                    {
                        if (line.Contains("worker"))
                        {
                            res = workerController.CreateWorker(line.Substring("create worker ".Length));
                        }
                        else if (line.Contains("project"))
                        {
                            res = projectController.CreateProject(line.Substring("create project ".Length));
                        }
                        else
                        {
                            res = "Unknown comand";
                        }
                    }
                    else if (line.StartsWith("get"))
                    {
                        if (line.Contains("worker"))
                        {
                            if (line.Contains("projects"))
                            {
                                res = workerController.GetWorkerProjects(line.Substring("get worker project ".Length));
                            }
                            else
                            {
                                res = workerController.FindWorker(line.Substring("get worker ".Length));
                            }
                        }
                        else if (line.Contains("project"))
                        {
                            res = projectController.FindProject(line.Substring("get project ".Length));
                        }
                        else
                        {
                            res = "Unknown comand";
                        }
                    }
                    else if (line.StartsWith("update"))
                    {
                        if (line.Contains("worker"))
                        {
                            res = workerController.UpdateWorker(line.Substring("update worker ".Length));
                        }
                        else if (line.Contains("project"))
                        {
                            res = projectController.UpdateProject(line.Substring("update project ".Length));
                        }
                        else
                        {
                            res = "Unknown comand";
                        }
                    }
                    else if (line.StartsWith("delete"))
                    {
                        if (line.Contains("worker"))
                        {
                            res = workerController.DeleteWorker(line.Substring("delete worker ".Length));
                        }
                        else if (line.Contains("project"))
                        {
                            res = projectController.DeleteProject(line.Substring("delete project ".Length));
                        }
                        else
                        {
                            res = "Unknown comand";
                        }
                    }
                    else
                    {
                        res = "Unknown comand";
                    }

                    Console.WriteLine(res);
                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine("Wrong command format");
                }
            }
        }
    }
}