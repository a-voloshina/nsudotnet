using System;
using System.IO;
using System.Linq;

namespace LinesCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceDirectory = @".\";
//            Directory
//                .GetFiles(mypath)
//                .ToList()
//                .ForEach(f => Console.WriteLine(Path.GetFileName(f)));
//            
//            Console.WriteLine();
//            
//            Directory
//                .GetFiles(mypath, args[0], SearchOption.AllDirectories)
//                .ToList()
//                .ForEach(f => Console.WriteLine(Path.GetFileName(f)));
            //ha-ha-ha
            if (args.Length < 2)
            {
                Console.Error.WriteLine("Wrong args format: even one argument(pattern)need.");
                return;
            }
            var counter = new LinesCounter();
            counter.Count(args[0], sourceDirectory, $"{sourceDirectory}{args[1]}");

//            var a = "       skdskdj sd";
//            a  = a.TrimStart();
//            Console.WriteLine(a);
        }
    }
}