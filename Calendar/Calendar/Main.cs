namespace Calendar
{
    public class Program
    {
        public static void Main(string[] args)
        {
//            var colors = (ConsoleColor[]) Enum.GetValues(typeof(ConsoleColor));
//            foreach (var color in colors) {
//                Console.ForegroundColor = color;
//                Console.WriteLine("The foreground color is {0}.", color);
//            }
            var calendar = new Calendar();
            calendar.Start();
        }
    }
}