using System.Text;

namespace AdventOfCode2024;

public class Day14
{
    private readonly List<Robot> _robots;
    private readonly int[,] _grid;

    public Day14(string input, int gridWidth, int gridHeight)
    {
        _robots = InitializeRobots(input);
        _grid = InitializeGrid(gridWidth, gridHeight, _robots);
    }

    private static List<Robot> InitializeRobots(string input)
    {
        List<Robot> robots = [];

        foreach (string line in input.Split(Environment.NewLine))
        {
            string[] pv = line.Split(' ');

            string p = pv[0];
            int[] pxy = p[2..].Split(',').Select(int.Parse).ToArray();
            int px = pxy[0];
            int py = pxy[1];

            string v = pv[1];
            int[] vxy = v[2..].Split(',').Select(int.Parse).ToArray();
            int vx = vxy[0];
            int vy = vxy[1];

            robots.Add(new Robot(px, py, vx, vy));
        }

        return robots;
    }

    private static int[,] InitializeGrid(int gridWidth, int gridHeight, IEnumerable<Robot> robots)
    {
        int[,] grid = new int[gridWidth, gridHeight];

        foreach (Robot robot in robots)
        {
            grid[robot.PositionX, robot.PositionY]++;
        }

        return grid;
    }

    public void Tick()
    {
        int gridWidth = _grid.GetLength(0);
        int gridHeight = _grid.GetLength(1);

        foreach (Robot robot in _robots)
        {
            _grid[robot.PositionX, robot.PositionY]--;
            robot.Move(gridWidth, gridHeight);
            _grid[robot.PositionX, robot.PositionY]++;
        }
    }

    public int CalculateSafetyFactor()
    {
        return CalculateSafetyFactor(_grid);
    }

    public static int CalculateSafetyFactor(int[,] grid)
    {
        int quadrantWidth = grid.GetLength(0) / 2;
        int quadrantHeight = grid.GetLength(1) / 2;

        int quadrant1Sum = 0;
        int quadrant2Sum = 0;
        int quadrant3Sum = 0;
        int quadrant4Sum = 0;

        for (int i = 0; i <= grid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= grid.GetUpperBound(1); j++)
            {
                if (grid[i, j] < 0)
                {
                    continue;
                }

                if (i < quadrantWidth && j < quadrantHeight)
                {
                    // Top-left quadrant
                    quadrant1Sum += grid[i, j];
                }
                else if (i > quadrantWidth && j < quadrantHeight)
                {
                    // Top-right quadrant
                    quadrant2Sum += grid[i, j];
                }
                else if (i < quadrantWidth && j > quadrantHeight)
                {
                    // Bottom-left quadrant
                    quadrant3Sum += grid[i, j];
                }
                else if (i > quadrantWidth && j > quadrantHeight)
                {
                    // Bottom-right quadrant
                    quadrant4Sum += grid[i, j];
                }
            }
        }

        return quadrant1Sum * quadrant2Sum * quadrant3Sum * quadrant4Sum;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        for (int j = 0; j <= _grid.GetUpperBound(1); j++)
        {
            for (int i = 0; i <= _grid.GetUpperBound(0); i++)
            {
                int cellValue = _grid[i, j];
                result.Append(cellValue > 0 ? cellValue : ".");
            }

            result.AppendLine();
        }

        return result.ToString().Trim();
    }

    private class Robot
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        private int VelocityX { get; }
        private int VelocityY { get; }

        public Robot(int positionX, int positionY, int velocityX, int velocityY)
        {
            PositionX = positionX;
            PositionY = positionY;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public void Move(int gridWidth, int gridHeight)
        {
            PositionX = (PositionX + VelocityX + gridWidth) % gridWidth;
            PositionY = (PositionY + VelocityY + gridHeight) % gridHeight;
        }
    }
}