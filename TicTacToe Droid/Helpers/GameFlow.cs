using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Droid.Helpers
{
    public class GameFlow
    {
        public static void ArtPaint(bool?[] table, List<ImageButton> allButtons)
        {
            /*var tasks = new List<Task>();
            tasks.Add(
            Task.Factory.StartNew(() =>
            {*/

            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == true)
                {
                    allButtons[i].SetImageResource(Resource.Drawable.Cross);
                }
                else if (table[i] == false)
                {
                    allButtons[i].SetImageResource(Resource.Drawable.Circle);
                }
            }

            /*})
            );*/

            //Task.WaitAll(tasks.ToArray());
        }

        public static void ResetGame(bool?[] table, List<ImageButton> allButtons)
        {
            for (int i = 0; i < table.Length; i++)
            {
                allButtons[i].SetImageResource(Resource.Drawable.BlackHole);
                table[i] = null;
            }
        }

        public static bool IsGameFinished(bool?[] board)
        {
            return DoesPlayerWins(board, true) ||
                   DoesPlayerWins(board, false) ||
                   board.All(p => p != null);
        }

        public static bool DoesPlayerWins(bool?[] board, bool playerSymbol)
        {
            var winnningPossibilities = new List<int[]>
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9},
                new[] {1, 4, 7},
                new[] {2, 5, 8},
                new[] {3, 6, 9},
                new[] {1, 5, 9},
                new[] {7, 5, 3},
            };

            foreach (var possibility in winnningPossibilities)
            {
                var won = true;

                foreach (var posItem in possibility)
                {
                    //zero based
                    var i = posItem - 1;

                    if (board[i] == null || board[i].Value != playerSymbol)
                        won = false;
                }

                if (won)
                    return true;
            }

            return false;
        }

        public static string BoardValue(bool?[] board, int boardIndex)
        {
            return board[boardIndex] == null ? " " : (board[boardIndex].Value ? "X" : "O");
        }
    }
}