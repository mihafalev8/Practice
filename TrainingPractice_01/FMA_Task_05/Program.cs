using System;
using System.IO;

namespace FMA_Task_05
{
    class Program
    {
        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void PassCorrectly(char[,] map, string correctRoute, ref int performerX, ref int performerY, ref int DX, ref int DY, int totalMoves)
        {
            bool repeatedVisit = false;

            for (int i = 0; i < correctRoute.Length; i++)
            {
                switch (correctRoute[i])
                {
                    case 'A':
                        DX = 0;
                        DY = -2;
                        break;
                    case 'S':
                        DX = 2;
                        DY = 0;
                        break;
                    case 'D':
                        DX = 0;
                        DY = 2;
                        break;
                    case 'W':
                        DX = -2;
                        DY = 0;
                        break;
                }
                repeatedVisit = MovePerformer(map, ref performerX, ref performerY, DX, DY, ref totalMoves);
                System.Threading.Thread.Sleep(200);
            }
        }
        static bool MovePerformer(char[,] map, ref int X, ref int Y, int DX, int DY, ref int totalMoves)
        {
            bool trafficPermit = false;

            trafficPermit = map[X + DX / 2, Y + DY / 2] != '║' &&
                map[X + DX / 2, Y + DY / 2] != '═' &&
                map[X + DX / 2, Y + DY / 2] != '╠' &&
                map[X + DX / 2, Y + DY / 2] != '╣' &&
                map[X + DX / 2, Y + DY / 2] != '╦' &&
                map[X + DX / 2, Y + DY / 2] != '╩' &&
                map[X + DX / 2, Y + DY / 2] != '╬' &&
                (X + DX / 2) < map.GetLength(0) - 1 && (X + DX / 2) > 0 &&
                (Y + DY / 2) < map.GetLength(1) - 1 && (Y + DY / 2) > 0;

            if (trafficPermit)
            {
                if (map[X + DX, Y + DY] != '*')
                {
                    Console.SetCursorPosition(Y, X);
                    Console.Write('*');
                    map[X, Y] = '*';
                    X += DX;
                    Y += DY;
                    Console.SetCursorPosition(Y, X);
                    Console.Write("■");

                    totalMoves++;
                    Console.SetCursorPosition(10, 32);
                    Console.WriteLine($"Осталось ходов - {Convert.ToString(202 - totalMoves),3:NO}");
                    return false;
                }
                else
                {
                    Console.SetCursorPosition(35, 15);
                    Console.Write("Вы уже проходили в этом месте");
                    Console.SetCursorPosition(35, 16);
                    Console.Write("Вы проиграли");
                    return true;
                }
            }
            return false;
        }

        static void ChangeMotion(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -2;
                    DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 2;
                    DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0;
                    DY = -2;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0;
                    DY = 2;
                    break;
            }
        }

        static void Main(string[] args)
        {
            bool isPlaying = true;
            bool repeatedVisit = false;
            int performerDX = 0, performerDY = 0;
            int totalMoves = 0;
            string correctRoute = "";
            Console.CursorVisible = false;
            char[,] map = ReadMap("level01", out int performerX, out int performerY);

            static char[,] ReadMap(string mapName, out int performerX, out int performerY)
            {
                performerX = 0;
                performerY = 0;

                string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
                char[,] map = new char[newFile.Length, newFile[0].Length];

                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        map[i, j] = newFile[i][j];

                        if (map[i, j] == '■')
                        {
                            performerX = i;
                            performerY = j;
                        }
                    }
                }
                return map;
            }
            Console.SetWindowSize(100, 40);
            DrawMap(map);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(35, 17);
                    Console.WriteLine("Игра закончена");
                    Console.WriteLine();
                    isPlaying = false;
                }
                else if (key.Key == ConsoleKey.F5)
                {
                    correctRoute = "AAASSSDWWDSSSAASSDWDDWWWWDSSSDWWWD" +
                        "SSSSAASAASAASDDDWDSSAAAASSSSDWWWDSSSDWWWDSSSD" +
                        "WWWWWWWDSSSSSSSDWDSDWWAAWDWAWDDSSDSSSDDDWAAWD" +
                        "DWAAWAWDDSDWWAAAAAAWWWWWWDSSSSSDWWWWWDSSSSSDD" +
                        "WAWDWAWWDSDWDSSASDSASDSSSSSSSSAAA";
                    PassCorrectly(map, correctRoute, ref performerX, ref performerY, ref performerDX, ref performerDY, totalMoves);
                    isPlaying = false;
                }
                else
                {
                    ChangeMotion(key, ref performerDX, ref performerDY);

                    repeatedVisit = MovePerformer(map, ref performerX, ref performerY, performerDX, performerDY, ref totalMoves);
                    if (repeatedVisit)
                    {
                        break;
                    }
                }
            }

            Console.SetCursorPosition(35, 17);
            Console.WriteLine();
            Console.SetCursorPosition(35, 19);
        }
    }
}
