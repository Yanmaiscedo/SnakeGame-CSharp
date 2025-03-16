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


}