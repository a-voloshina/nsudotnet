using System;

namespace LinesCounter
{
    public class ReadFileException: Exception
    {
        public ReadFileException(string message) : base(message)
        {
        }
    }
}