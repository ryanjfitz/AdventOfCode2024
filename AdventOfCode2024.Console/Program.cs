namespace AdventOfCode2024.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        PlayDay15Part2();
    }

    private static void PlayDay15Part2()
    {
        Start:
        var day15Part2 = new Day15Part2("""
                                        ############################
                                        ##........................##
                                        ##........................##
                                        ##........................##
                                        ##.....[]#................##
                                        ##....[][]................##
                                        ##......@.................##
                                        ##........................##
                                        ##........................##
                                        ############################
                                        """);

        while (true)
        {
            System.Console.Clear();
            System.Console.Write(day15Part2.ToString());

            switch (System.Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    day15Part2.Tick('^');
                    break;
                case ConsoleKey.DownArrow:
                    day15Part2.Tick('v');
                    break;
                case ConsoleKey.LeftArrow:
                    day15Part2.Tick('<');
                    break;
                case ConsoleKey.RightArrow:
                    day15Part2.Tick('>');
                    break;
                case ConsoleKey.R:
                    goto Start;
                case ConsoleKey.Escape:
                    return;
            }
        }
    }
}