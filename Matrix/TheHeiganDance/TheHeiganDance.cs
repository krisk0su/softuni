using System;
using System.Data;
using System.Runtime.InteropServices;

namespace TheHeiga_Dance
{
    class TheHeiganDance
    {
        static void Main(string[] args)
        {


            var player = new Player(double.Parse(Console.ReadLine()));

            var heigan = new Heigan();

            bool cloud = false;
            string lastSpell = " ";

            while (heigan.health > 0 && player.health > 0)
            {
                var matrix = new int[15, 15];
                heigan.health -= player.damage;

                if (cloud)
                {
                    player.health -= heigan.cloud;
                    cloud = false;
                }
                if (player.health <= 0)
                {
                    break;
                }
                if (heigan.health > 0)
                {
                    var input = Console.ReadLine().Split();

                    var skill = input[0];
                    var row = int.Parse(input[1]);
                    var col = int.Parse(input[2]);


                    if (skill == "Cloud")
                    {
                        lastSpell = "Plague Cloud";
                        //cant escape
                        if (row == player.row && col == player.col)
                        {
                            player.health -= heigan.cloud;
                            cloud = true;
                        }
                        //tryToEscape
                        else
                        {
                            var damagedCells = heigan.Range(row, col);

                            DamageMatrix(damagedCells, matrix);

                            bool isPlayerDamaged = CheckIfDamaged(matrix, player);

                            if (isPlayerDamaged)
                            {
                                bool didEscape = TryToEscape(player, matrix);

                                if (!didEscape)
                                {
                                    player.health -= heigan.cloud;
                                    cloud = true;
                                }
                            }
                        }
                    }
                    else if (skill == "Eruption")
                    {
                        lastSpell = "Eruption";

                        //cant escape
                        if (row == player.row && col == player.col)
                        {
                            player.health -= heigan.erruption;

                        }
                        else
                        {
                            var damagedCells = heigan.Range(row, col);

                            DamageMatrix(damagedCells, matrix);

                            bool isPlayerDamaged = CheckIfDamaged(matrix, player);

                            if (isPlayerDamaged)
                            {
                                bool didEscape = TryToEscape(player, matrix);

                                if (!didEscape)
                                {
                                    player.health -= heigan.erruption;

                                }
                            }
                        }
                    }

                }
                else
                {
                    break;
                }


            }
            if (player.health <= 0 && heigan.health > 0)
            {

                Console.WriteLine($"Heigan: {heigan.health:f2}");
                Console.WriteLine($"Player: Killed by {lastSpell}");
                Console.WriteLine($"Final position: {player.row}, {player.col}");
            }
            else if (player.health > 0 && heigan.health <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: {player.health}");
                Console.WriteLine($"Final position: {player.row}, {player.col}");

            }
            else
            {
                Console.WriteLine("Heigan: Defeated!");
                Console.WriteLine($"Player: Killed by {lastSpell}");
                Console.WriteLine($"Final position: {player.row}, {player.col}");
            }
        }

        private static bool TryToEscape(Player player, int[,] matrix)
        {
            bool didMove;
            //moveUp
            didMove = MoveUp(player, matrix);
            if (didMove)
            {
                if (player.row > 0)
                {
                    player.row--;
                }
                return true;
            }
            didMove = MoveRight(player, matrix);
            if (didMove)
            {
                if (player.col < matrix.GetLength(1) - 1)
                {
                    player.col++;
                }

                return true;
            }
            didMove = MoveDown(player, matrix);
            if (didMove)
            {
                if (player.row < matrix.GetLength(0) - 1)
                {
                    player.row++;
                }

                return true;
            }
            didMove = MoveLeft(player, matrix);
            if (didMove)
            {
                if (player.col > 0)
                {
                    player.col--;
                }
                return true;
            }
            return false;
        }

        private static bool MoveLeft(Player player, int[,] matrix)
        {
            if (player.col - 1 >= 0 && matrix[player.row, player.col - 1] == 0)
            {
                return true;
            }
            return false;
        }

        private static bool MoveDown(Player player, int[,] matrix)
        {
            if (player.row + 1 < matrix.GetLength(0) && matrix[player.row + 1, player.col] == 0)
            {
                return true;
            }
            return false;
        }

        private static bool MoveRight(Player player, int[,] matrix)
        {
            if (player.col + 1 < matrix.GetLength(1) && matrix[player.row, player.col + 1] == 0)
            {
                return true;
            }
            return false;
        }

        private static bool MoveUp(Player player, int[,] matrix)
        {
            if (player.row - 1 >= 0 && matrix[player.row - 1, player.col] == 0)
            {
                return true;
            }
            return false;
        }

        private static bool CheckIfDamaged(int[,] matrix, Player player)
        {
            if (matrix[player.row, player.col] == 1)
            {
                return true;
            }
            return false;
        }

        private static void Priter(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void DamageMatrix(int[] damagedCells, int[,] matrix)
        {
            var startRow = damagedCells[0];
            var startCol = damagedCells[1];
            var endRow = damagedCells[2];
            var endCol = damagedCells[3];

            for (int row = startRow; row <= endRow; row++)
            {
                for (int col = startCol; col <= endCol; col++)
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
                    {
                        matrix[row, col] = 1;
                    }
                }
            }
        }

        public class Player
        {
            public int row;

            public int col;

            public double damage;

            public double health;
            public Player(double damage)
            {
                this.row = 7;

                this.col = 7;

                this.damage = damage;

                this.health = 18500;
            }
        }

        public class Heigan
        {
            public double health = 3000000;

            public double cloud = 3500;

            public double erruption = 6000;

            public int[] Range(int row, int col)
            {
                var startEnd = new int[4];


                startEnd[0] = row - 1;
                startEnd[1] = col - 1;
                startEnd[2] = row + 1;
                startEnd[3] = col + 1;

                return startEnd;
            }

        }
    }
}