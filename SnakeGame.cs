using System;
using System.Threading;

class SnakeGame
{
    static bool gameOver;
    const int width = 40;
    const int height = 27;
    static int x, y, fruitX, fruitY, score;
    static int[] tailX = new int[100], tailY = new int[100];
    static int nTail;
    static Direction dir;

    enum Direction { STOP = 0, LEFT, RIGHT, UP, DOWN }
    
    static void Setup()
    {
        gameOver = false;
        dir = Direction.STOP;
        x = width / 2;
        y = height / 2;
        Random rand = new Random();
        fruitX = rand.Next(width);
        fruitY = rand.Next(height);
        score = 0;
    }
    
    static void Draw()
    {
        Console.Clear();
        Console.WriteLine("!!!!slither.io!!!!");

        for (int i = 0; i < width + 2; i++)
            Console.Write("#");
        Console.WriteLine();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j == 0)
                    Console.Write("#");
                if (i == y && j == x)
                    Console.Write("Q");
                else if (i == fruitY && j == fruitX)
                    Console.Write("$");
                else
                {
                    bool print = false;
                    for (int k = 0; k < nTail; k++)
                    {
                        if (tailX[k] == j && tailY[k] == i)
                        {
                            Console.Write("o");
                            print = true;
                        }
                    }
                    if (!print)
                        Console.Write(" ");
                }
                if (j == width - 1)
                    Console.Write("#");
            }
            Console.WriteLine();
        }

        for (int i = 0; i < width + 2; i++)
            Console.Write("#");
        Console.WriteLine();
        Console.WriteLine("Score: " + score);
    }

    static void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.A:
                    dir = Direction.LEFT;
                    break;
                case ConsoleKey.D:
                    dir = Direction.RIGHT;
                    break;
                case ConsoleKey.W:
                    dir = Direction.UP;
                    break;
                case ConsoleKey.S:
                    dir = Direction.DOWN;
                    break;
                case ConsoleKey.X:
                    gameOver = true;
                    break;
            }
        }
    }

    static void Logic()
    {
        int prevX = tailX[0], prevY = tailY[0], prev2X, prev2Y;
        tailX[0] = x;
        tailY[0] = y;

        for (int i = 1; i < nTail; i++)
        {
            prev2X = tailX[i];
            prev2Y = tailY[i];
            tailX[i] = prevX;
            tailY[i] = prevY;
            prevX = prev2X;
            prevY = prev2Y;
        }

        switch (dir)
        {
            case Direction.LEFT: x--; break;
            case Direction.RIGHT: x++; break;
            case Direction.UP: y--; break;
            case Direction.DOWN: y++; break;
        }

        if (x >= width) x = 0; else if (x < 0) x = width - 1;
        if (y >= height) y = 0; else if (y < 0) y = height - 1;

        for (int i = 0; i < nTail; i++)
        {
            if (tailX[i] == x && tailY[i] == y)
                gameOver = true;
        }

        if (x == fruitX && y == fruitY)
        {
            score += 10;
            Random rand = new Random();
            fruitX = rand.Next(width);
            fruitY = rand.Next(height);
            nTail++;
        }
    }

    static void Main()
    {
        Setup();
        while (!gameOver)
        {
            Draw();
            Input();
            Logic();
            Thread.Sleep(40);
        }
    }
}