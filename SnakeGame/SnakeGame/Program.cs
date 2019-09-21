using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                                 SNAKE        KRAKEN         ");
         
         

            int[] xPosition = new int[50];
            xPosition[0] = 35;
            int[] yPosition = new int[50];
            yPosition [0] = 20;
            int appleXDin = 10;
            int appleYDin = 10;
            int applesEaten = 0;

            decimal gameSpeed = 150m;

            bool isGameOn = true;
            bool isWallHit = false;
            bool isAppleEaten = false;

            Console.CursorVisible = false;

            Random random = new Random();

            //Get the snake to appear on screen

            Console.SetCursorPosition(xPosition[0], yPosition[0]);
            Console.ForegroundColor = ConsoleColor.White ;
            Console.WriteLine((char)214);

            // set apple on screen
            setApplePositionOnScreen(random, out appleXDin, out appleYDin);
            paintApple(appleXDin, appleYDin);

           
            //Build Boundary
            buildwall();

            //Get the snake to move
            ConsoleKey command = Console.ReadKey().Key;

            do
            {
                switch (command)
                {
                 
                    case ConsoleKey.LeftArrow:
                       
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0] --;
                        break;

                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]--;
                        break;

                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        xPosition[0]++;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(xPosition[0], yPosition[0]);
                        Console.Write(" ");
                        yPosition[0]++;
                        break;
                    
                }
                //Paint the snake
                paintSnake(applesEaten, xPosition, yPosition , out xPosition , out yPosition );


                isWallHit = DidSnakeHitWall(xPosition[0], yPosition[0]);

                if (isWallHit)
                {
                    isGameOn = false;
                    Console.SetCursorPosition(28, 20);
                    Console.WriteLine("The snake hit the wall and died");
                }

                // Detect when apple´was eaten
                isAppleEaten = determineIfApplewasEaten(xPosition[0], yPosition[0], appleXDin , appleYDin);


                // Place apple on board (random)
                
                if(isAppleEaten)
                {
                    setApplePositionOnScreen(random, out appleXDin, out appleYDin);
                    paintApple(appleXDin, appleYDin);
                    applesEaten++;
                    gameSpeed *= .925m;

                }


                if (Console.KeyAvailable) command = Console.ReadKey().Key;
                System.Threading.Thread.Sleep(Convert.ToInt32(gameSpeed));

            } while (isGameOn);

            //Make snake longer

           


            Console.ReadLine();



            


            
              
         




        }

        private static void paintSnake(int applesEaten, int[] xPositionIn, int[] yPositionIn, out int[] xPositionOut, out int[] yPositionOut)
        {


            //paint the head
            Console.SetCursorPosition(xPositionIn[0], yPositionIn[0]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine('X');

            //Paint the body
            for (int i = 1; i < applesEaten +1; i++)
            {
                Console.SetCursorPosition(xPositionIn[1], yPositionIn[1]);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("o");
            }
            //Erase last part of snake
            Console.SetCursorPosition(xPositionIn[applesEaten +1], yPositionIn[applesEaten +1]);
            Console.WriteLine(" ");

            //Record location of each body part
            for (int i = applesEaten+1; i > 0; i--)
            {
                xPositionIn[i] = xPositionIn[i - 1];
                yPositionIn[i] = yPositionIn[i - 1];
            }



            xPositionOut = xPositionIn;
            yPositionOut = yPositionIn;
                
        }

        private static bool DidSnakeHitWall(int xPosition, int yPosition)
        {
            if (xPosition == 1 || xPosition == 70 || yPosition == 1 || yPosition == 40) return true; return false;
        }

        private static void buildwall()
        {

        
            for (int i = 1; i <41 ; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red ;
                Console.SetCursorPosition(1, i);
                Console.Write("#");
                Console.SetCursorPosition(70,i);
                Console.Write("#");

            }

            for (int i = 1; i < 71; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                Console.SetCursorPosition(i, 40);
                Console.Write("#");

            }
            {

            }
            {
                //Console.ForegroundColor = ConsoleColor.White;

            }

        }

        private static void setApplePositionOnScreen(Random random, out int appleXDin, out int appleYDin)
        {
            appleXDin = random.Next(0 + 2, 70 - 2);
            appleYDin = random.Next(0 + 2, 40 - 2);
        }

        private static void paintApple(int appleXDin, int appleYDin)
        {
            Console.SetCursorPosition(appleXDin, appleYDin);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write((char)64);
        }

        private static bool determineIfApplewasEaten(int xPosition, int yPosition, int appleXDin, int appleYDin)
        {
            if (xPosition == appleXDin && yPosition == appleYDin) return true; return false;

        }
    }

}
