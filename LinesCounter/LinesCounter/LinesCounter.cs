using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LinesCounter
{
    struct Comment
    {
        public string Start { get; }
        public string End { get; }

        public Comment(string start, string end)
        {
            Start = start;
            End = end;
        }
    }

    public class LinesCounter
    {
        private List<string> _filesList;
        private readonly List<Comment> _commentsTypes = new List<Comment>();

        public void Count(string pattern, string sourceDirectory, string configFileName)
        {
            ParseCommentConfig(configFileName);

            _filesList = Directory
                .GetFiles(sourceDirectory, pattern, SearchOption.AllDirectories)
                .ToList();

            var totalCount = 0;

            foreach (var file in _filesList)
            {
                var linesCount = CountLinesInFile(file);
                totalCount += linesCount;
                Console.WriteLine("\"{0}\": {1}\n", file, linesCount);
            }

            Console.WriteLine("Total lines count = {0}", totalCount);

            /*Directory
            .GetFiles(path, args[0], SearchOption.AllDirectories)
            .ToList()
            .ForEach(f => Console.WriteLine(Path.GetFileName(f)));
            */ Console.WriteLine();
        }

        private int CountLinesInFile(string name)
        {
            var linesCount = 0;
            var isComment = false;
            var isMultiLineComment = false;
            try
            {
                using (var streamReader = new StreamReader(name))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        line = line.TrimStart().TrimEnd();
                            foreach (var commentElem in _commentsTypes)
                            {
                                if (line.Contains(commentElem.Start) &&
                                    (commentElem.End == "" || commentElem.End != "" && line.Contains(commentElem.End)))
                                {
                                    var startIndex = line.IndexOf(commentElem.Start, StringComparison.Ordinal);
                                    if (startIndex == 0)
                                    {
                                        isComment = true;
                                        break;
                                    }
                                }
                                else if (line.Contains(commentElem.Start))
                                {
                                    var startIndex = line.IndexOf(commentElem.Start, StringComparison.Ordinal);
                                    isMultiLineComment = true;
                                    if (startIndex == 0)
                                    {
                                        isComment = true;
                                        break;
                                    }
                                }
                                else if (commentElem.End != "" && line.Contains(commentElem.End))
                                {
                                    var endIndex = line.IndexOf(commentElem.End, StringComparison.Ordinal);
                                    isMultiLineComment = false;
                                    if (endIndex == line.Length - 1)
                                    {
                                        isComment = true;
                                        break;
                                    }
                                }
                                isComment = false;
                            }
 
                        if (!isComment && !isMultiLineComment)
                        {
                            linesCount++;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Can't read from file \"{0}\": {1}", name, exception);
            }

            return linesCount;
        }
        
        private void ParseCommentConfig(string configFileName)
        {
            try
            {
                using (var streamReader = new StreamReader(configFileName))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        var commentsEntity = line.Split(' ');
                        switch (commentsEntity.Length)
                        {
                            case 1:
                                _commentsTypes.Add(new Comment(commentsEntity[0], ""));
                                break;
                            case 2:
                                _commentsTypes.Add(new Comment(commentsEntity[0], commentsEntity[1]));
                                break;
                            default:
                                Console.Error.WriteLine("Unknown comment format: {0}", line);
                                break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw new ReadFileException("Can't read from file \"" + configFileName + "\": "
                                            + exception.Message);
            }
        }
    }
}
