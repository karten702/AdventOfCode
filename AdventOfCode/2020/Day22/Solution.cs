using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace AdventOfCode.Y2020.Day22 {
     
    class Solution{

        public static List<string> Input =>
              InputHelper.GetInput(2020, 22);

        public static void Run(){
            Console.WriteLine("Part 1:");
            Console.WriteLine(Part1());
            Console.WriteLine();
            Console.WriteLine("Part 2:");
            Console.WriteLine(Part2());
        }
        public static long Part1()
        {
            Player player1 = new Player(Input.GetRange(0, Input.IndexOf("")));
            Player player2 = new Player(Input.GetRange(Input.IndexOf(""), Input.Count- Input.IndexOf("")));
            var game = new Game1(player1, player2);
            return game.RunGame();
        }

        public static long Part2()
        {
            Player player1 = new Player(Input.GetRange(0, Input.IndexOf("")));
            Player player2 = new Player(Input.GetRange(Input.IndexOf(""), Input.Count - Input.IndexOf("")));
            return new Game2().RunGame(player1.Deck, player2.Deck, true);
        }
    }

    class Game2
    {
        public int RunGame(IEnumerable<int> p1, IEnumerable<int> p2, bool main = false)
        {
            HashSet<string> seen = new HashSet<string>();
            var player1 = new Queue<int>(p1);
            var player2 = new Queue<int>(p2);
            while (player1.Count > 0 && player2.Count > 0)
            {
                if (!main && player1.Max() > player2.Max() || !seen.Add(GetGameHash(player1, player2)))
                    return 1;

                int p1Card = player1.Dequeue();
                int p2Card = player2.Dequeue();

                int roundWinner;
                if (p1Card <= player1.Count && p2Card <= player2.Count)
                    roundWinner = RunGame(player1.Take(p1Card), player2.Take(p2Card));
                else
                    roundWinner = p1Card > p2Card ? 1 : 2;

                if (roundWinner == 1)
                {
                    player1.Enqueue(p1Card);
                    player1.Enqueue(p2Card);
                }
                else
                {
                    player2.Enqueue(p2Card);
                    player2.Enqueue(p1Card);
                }
            }

            int winner = player1.Count == 0 ? 2 : 1;
            Queue<int> winnerCards = player1.Count == 0 ? player2 : player1;                        

            return !main ? winner : CalculateScore(winnerCards);
        }

        private string GetGameHash(Queue<int> player1, Queue<int> player2)
        {
            return string.Join(',', player1) + "|" + string.Join(',', player2);
        }

        private int CalculateScore(Queue<int> winner)
        {
            int score = 0;

            Queue<int> winnerDeck = winner;
            while (winnerDeck.Count != 0)
            {
                score += winnerDeck.Peek() * winnerDeck.Count;
                winnerDeck.Dequeue();
            }
            return score;
        }
    }

    class Game1
    {
        Player Player1 { get; set; }
        Player Player2 { get; set; }

        public Game1(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public long RunGame()
        {
            Player winner = null;
            
            while(true)
            {
                int player1Attack = Player1.Deck.Dequeue();
                int player2Attack = Player2.Deck.Dequeue();

                if(player1Attack > player2Attack)
                {
                    Player1.Deck.Enqueue(player1Attack);
                    Player1.Deck.Enqueue(player2Attack);
                }
                else
                {
                    Player2.Deck.Enqueue(player2Attack);
                    Player2.Deck.Enqueue(player1Attack);
                }

                if (Player1.Deck.Count == 0)
                {
                    winner = Player2;
                    break;
                }
                else if(Player2.Deck.Count == 0)
                {
                    winner = Player1;
                    break;
                }
            }

            if(winner != null)            
                return CalculateScore(winner);            

            return 0;
        }

        private long CalculateScore(Player winner)
        {
            long score = 0;
            Queue<int> winnerDeck = winner.Deck;
            while (winnerDeck.Count != 0)
            {
                score += winnerDeck.Peek() * winnerDeck.Count;
                winnerDeck.Dequeue();
            }
            return score;
        }
    }

    class Player
    {
        public Queue<int> Deck = new Queue<int>();
        public string Name { get; set; }

        public Player(List<string> input)
        {
            foreach (string item in input)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                if (item.StartsWith('P'))
                    Name = item.Replace(":", "");
                else
                    Deck.Enqueue(int.Parse(item));
            }
        }
    }
}