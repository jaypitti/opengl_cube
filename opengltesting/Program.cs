using System;
using OpenTK;


namespace opengltesting
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(1920, 1080);
            Game gm = new Game(window);

        }
    }
}
