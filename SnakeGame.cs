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

}