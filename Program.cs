// Rules of the game
// Any live cell with fewer than two live neighbors dies, as if by underpopulation.
// Any live cell with two or three live neighbors lives on to the next generation.
// Any live cell with more than three live neighbors dies, as if by overpopulation.
// Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
using System;

namespace game_of_life
{
    class Program
    {
        public static int getGridY(){
            while (true)
            {   
                try{
                Console.Clear();
                Console.WriteLine("Input the number of rows");
                return Convert.ToInt32(Console.ReadLine());
                }catch(Exception e){
                    Console.Clear();
                    Console.WriteLine("Input a valid number");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }

        public static int getGridX(){
            while (true)
            {   
                try{
                Console.Clear();
                Console.WriteLine("Input the number of columns");
                return Convert.ToInt32(Console.ReadLine());
                }catch(Exception e){
                    Console.Clear();
                    Console.WriteLine("Input a valid number");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }
        }

        public static void printGrid(int[,] grid){

            for (int i = -1; i <= grid.GetLength(0); i++)
            {
                for (int j = -1; j <= grid.GetLength(1); j++)
                {
                    if (i == -1 && j == -1)
                    {
                        Console.Write("╔");
                    }

                    if (i == -1 && j == grid.GetLength(1))
                    {
                        Console.Write("╗\n"); 
                    }

                    if (i == grid.GetLength(0) && j == -1)
                    {
                        Console.Write("╚");
                    }

                    if (i == grid.GetLength(0) && j==grid.GetLength(1))
                    {
                        Console.Write("╝\n");
                    }

                    if(-1 < i && i < grid.GetLength(0))
                    {
                        if(j == -1)
                        {
                                Console.Write("║");
                        }

                        if(j == grid.GetLength(1))
                        {
                            Console.Write("║\n");
                        }
                    }

                    if (-1< j && j < grid.GetLength(1))
                    {
                        if (i == -1 || i == grid.GetLength(0))
                        {
                            Console.Write("══");
                        }else{

                            if(grid[i,j] == 0)
                            {
                                Console.Write("  ");
                            }

                            if(grid[i,j] == 1)
                            {
                                Console.Write("■ ");
                            }
                        }
                    }
                }
            }
        }

        public static int getNeighbors(int[,] grid, int y, int x){
            int aliveNeighbors = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (-1 < y+i && y+i < grid.GetLength(0))
                    {
                        if (-1 < x+j && x+j < grid.GetLength(1))
                        {
                            if (i == 0 && j == 0)
                            {
                                aliveNeighbors += 0;
                            }else if (grid[y+i,x+j] == 1)
                            {
                                aliveNeighbors +=  1;
                            }
                        }
                    }
                }
            }
            return aliveNeighbors;
        }

        // method for debugging
        public static string state(int[,] grid, int y, int x){
            
            string State="";

            int neighbors = getNeighbors(grid, y, x);

            if (neighbors < 2){
                State= $"{neighbors}   y:{y}  x:{x} State:dead 1";
            }
            if (neighbors == 2 || neighbors == 3){
                State= $"{neighbors}   y:{y}  x:{x} State:alive 1";
            }
            if (neighbors > 3){
                State= $"{neighbors}  y:{y}  x:{x} State:dead 2";
            }
            if (neighbors == 3){
                State= $"{neighbors}  y:{y}  x:{x} State:alive 2";
            }
            return State;

        }

        public static void move(int[,] grid){
            int maxY = grid.GetLength(0);
            int maxX = grid.GetLength(1);
            int[,] newGrid = new int[maxY, maxX];

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    newGrid[i,j] = grid[i,j];
                }
            }

            printGrid(grid);

            for (int i = 0; i < maxY; i++)
            {
                for (int j = 0; j < maxX; j++)
                {
                    int neighbors = getNeighbors(grid, i, j);
                    
                    if (neighbors < 2){
                        newGrid[i,j] = 0;
                    }
                    if (neighbors == 2 && grid[i,j]==1){
                        newGrid[i,j] = 1;
                    }
                    if (neighbors > 3){
                        newGrid[i,j] = 0;
                    }
                    if (neighbors == 3){
                        newGrid[i,j] = 1;
                    }
                    int test = newGrid[i,j];
                }
            }

            Console.ReadKey();
            move(newGrid);
        }

        static void Main(string[] args)
        {
            int[,] baseGrid = new int[15,20]{
                // {0,0,0,0,0},
                // {0,0,1,0,0},
                // {0,1,1,1,0},
                // {0,0,0,0,0},
                // {0,0,0,0,0}
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
            };

            Random random = new Random();
            int gridX=0, gridY=0, choice=0;

            while(true){
                try{
                    Console.WriteLine("1) Random grid \n2) Base grid");
                    choice = Convert.ToInt16(Console.ReadLine());
                    if (choice != 1 && choice != 2){
                        continue;
                    }
                    if (choice == 1){
                        gridY = getGridY();
                        gridX = getGridX();
                        // gridY = random.Next(5,30);
                        // gridX = random.Next(5,30);
                        break;
                    }
                    if (choice == 2){
                        gridY = baseGrid.GetLength(0);
                        gridX = baseGrid.GetLength(1);
                        break;
                    }
                }catch(Exception e){
                    Console.Clear();
                    Console.WriteLine("Input a valid choice");
                    Console.ReadKey();
                    Console.Clear();
                    continue; 
                }
            }
            int[,] grid = new int[gridY,gridX];
        
            if (choice == 1){
                for (int i = 0 ; i < gridY ; i++){
                    for (int j = 0 ; j < gridX ; j++){
                        grid[i,j] = random.Next(0, 2);
                    }
                }
            }else{
                for (int i = 0 ; i < gridY ; i++){
                    for (int j = 0 ; j < gridX ; j++){
                        grid[i,j] = baseGrid[i,j];
                    }
                }
            }

            move(grid);

            Console.ReadLine();
        }
    }
}