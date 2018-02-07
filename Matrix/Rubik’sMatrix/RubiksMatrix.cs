using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace RubiksMatrix
{
    class RubiksMatrix
    {
        static void Main()
        {
            var indexes = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrice = MatriceCreator(indexes);

            int numOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOperations; i++)
            {
                var commands = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                OperationManager(commands, matrice);

            }

            ReArrangeManager(matrice);
        }

        private static void ReArrangeManager(int[,] matrice)
        {

            for (int row = 0; row < matrice.GetLength(0); row++)
            {
                for (int col = 0; col < matrice.GetLength(1); col++)
                {
                    var properValuee = row * matrice.GetLength(1) + col + 1;
                    if (matrice[row, col] == properValuee)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        var position = FindValuePosition(properValuee, matrice);
                        var currentPosition = new int[2];

                        currentPosition[0] = row;
                        currentPosition[1] = col;

                        Console.WriteLine($"Swap ({row}, {col}) with ({position[0]}, {position[1]})");
                        SwapValues(matrice, currentPosition, position);
                    }
                }
            }


        }

        private static void SwapValues(int[,] matrice, int[] currentPosition, int[] position)
        {
            var tempValue = matrice[currentPosition[0], currentPosition[1]];

            matrice[currentPosition[0], currentPosition[1]] = matrice[position[0], position[1]];
            matrice[position[0], position[1]] = tempValue;


        }

        private static int[] FindValuePosition(int properValuee, int[,] matrice)
        {

            for (int row = 0; row < matrice.GetLength(0); row++)
            {
                for (int col = 0; col < matrice.GetLength(1); col++)
                {
                    if (matrice[row, col] == properValuee)
                    {
                        var indexes = new int[2];
                        indexes[0] = row;
                        indexes[1] = col;
                        return indexes;
                    }
                }
            }
            return null;
        }

        private static void OperationManager(string[] commands, int[,] matrice)
        {
            var direction = commands[1];

            switch (direction)
            {
                case "right":
                    MoveRight(commands, matrice);
                    break;
                case "left":
                    MoveLeft(commands, matrice);
                    break;
                case "up":
                    MoveUp(commands, matrice);
                    break;
                case "down":
                    MoveDown(commands, matrice);
                    break;
            }



        }

        private static void MoveDown(string[] commands, int[,] matrice)
        {
            int moves = int.Parse(commands[2]);

            int col = int.Parse(commands[0]);
            // the tempArray holds the numbers after the moves


            for (int z = 0; z < moves; z++)
            {
                var last = matrice[matrice.GetLength(0) - 1, col];

                for (int row = matrice.GetLength(0) - 1; row > 0; row--)
                {
                    matrice[row, col] = matrice[row - 1, col];
                }
                matrice[0, col] = last;
            }

            //now we need to etract the numbers from the tempArray and put them into the matrix


        }

        private static void MoveUp(string[] commands, int[,] matrice)
        {
            int moves = int.Parse(commands[2]);

            int col = int.Parse(commands[0]);
            // the tempArray holds the numbers after the moves

            //here we shaffle the temp array according to the number of moves
            for (int z = 0; z < moves; z++)
            {
                var first = matrice[0, col];

                for (int i = 0; i < matrice.GetLength(0) - 1; i++)
                {
                    matrice[i, col] = matrice[i + 1, col];
                }
                matrice[matrice.GetLength(0) - 1, col] = first;

            }



        }

        private static void MoveLeft(string[] commands, int[,] matrice)
        {
            int moves = int.Parse(commands[2]);
            int row = int.Parse(commands[0]);

            int[] tempArray = new int[matrice.GetLongLength(0)];
            //here we get the the row from the matrice
            for (int col = 0; col < matrice.GetLength(1); col++)
            {
                tempArray[col] = matrice[row, col];
            }
            //here we need to shuffle the numbers into the temp array N times pointin moves

            for (int i = 0; i < moves; i++)
            {
                //logic for moving the numbers left <----
                int first = tempArray[0];
                /*here we need to access only the index before the last so we wont get out of the array boundaries*/
                for (int z = 0; z < tempArray.Length - 1; z++)
                {
                    tempArray[z] = tempArray[z + 1];
                }
                tempArray[tempArray.Length - 1] = first;
            }
            //after we are ready with the shuffle we need to pass the shaffled row into the matrix
            for (int col = 0; col < matrice.GetLongLength(1); col++)
            {
                matrice[row, col] = tempArray[col];
            }
        }

        private static void MoveRight(string[] commands, int[,] matrice)
        {
            int moves = int.Parse(commands[2]);
            int row = int.Parse(commands[0]);

            int[] tempArray = new int[matrice.GetLongLength(0)];
            //here we get the the row from the matrice
            for (int col = 0; col < matrice.GetLength(1); col++)
            {
                tempArray[col] = matrice[row, col];
            }
            //here we need to shuffle the numbers into the temp array N times pointin moves

            for (int i = 0; i < moves; i++)
            {
                //logic for moving the numbers right ---->
                int last = tempArray[tempArray.Length - 1];
                /*here we need to access only the index before the last so we wont get out of the array boundaries*/
                for (int z = tempArray.Length - 1; z > 0; z--)
                {
                    tempArray[z] = tempArray[z - 1];
                }
                tempArray[0] = last;
            }
            //after we are ready with the shuffle we need to pass the shaffled row into the matrix
            for (int col = 0; col < matrice.GetLongLength(1); col++)
            {
                matrice[row, col] = tempArray[col];
            }
        }

        private static int[,] MatriceCreator(int[] indexes)
        {
            int rows = indexes[0];
            int columns = indexes[1];

            var matrice = new int[rows, columns];

            int counter = 1;
            for (int row = 0; row < matrice.GetLength(0); row++)
            {
                for (int column = 0; column < matrice.GetLength(1); column++)
                {
                    matrice[row, column] = counter;
                    counter++;
                }
            }

            return matrice;
        }
    }
}