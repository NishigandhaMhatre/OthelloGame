using System;
using System.Collections.Generic;

namespace Othello
{
    class OthelloGame
    {
        private List<Player> PlayerList { get; set; }
        private static OthelloGame _gameInstance { get; set; }
        private Board board { get; set; }
        private const int  ROW = 10;
        private const int COL = 10;

        public OthelloGame()
        {
            PlayerList = new List<Player>();
            PlayerList.Add(new Player("Nishi",Color.white));
            PlayerList.Add(new Player("Rakesh", Color.black));
            board = new Board(ROW, COL);
        }

        public static OthelloGame GetGameInstance()
        {
            if (_gameInstance == null)
                _gameInstance = new OthelloGame();
            return _gameInstance;
        }

        public Board GetBoard()
        {
            return board;
        }

        public void playGame()
        {
            int playerNum = 0;
            Console.WriteLine(board.ToString());
            while (this.board.movesPossible())
            {
                Player curPlayer = PlayerList[playerNum];
                Console.WriteLine($"Player {curPlayer.GetName()} turn");
                Console.WriteLine("Enter row: ");
                int row = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter col: ");
                int col = Convert.ToInt32(Console.ReadLine());
                if (row < 0 || row >= ROW || col < 0 || col >= COL)
                {
                    Console.WriteLine("Invalid Move, try again");
                    Console.WriteLine("Enter row: ");
                    row = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter col: ");
                    col = Convert.ToInt32(Console.ReadLine());

                }
                curPlayer.MakeMove(row, col);
                this.checkNeighBours(row, col);
                playerNum = FlipPlayer(playerNum);
                Console.WriteLine(board.ToString());
            }
        }
         
        public int FlipPlayer(int PlayerNum)
        {
            if (PlayerNum == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void checkNeighBours(int row, int col)
        {
            if (row - 1 >= 0 && board.GetBoard()[row-1,col] !=null) UpdateBoard(row - 1, col);
            if (row + 1 < ROW && board.GetBoard()[row + 1, col] != null) UpdateBoard(row + 1, col);
            if (col - 1 >= 0 && board.GetBoard()[row, col-1] != null) UpdateBoard(row, col - 1);
            if (col + 1 < COL && board.GetBoard()[row, col+1] != null) UpdateBoard(row, col + 1);
        }

        public void UpdateBoard(int row, int col)
        {
            Color curCol = board.GetBoard()[row,col].pieceColor;
            if (col-1 >= 0 && col+1 < COL) {
                if (board.GetBoard()[row, col - 1] != null && board.GetBoard()[row, col + 1] != null)
                {
                    if (board.GetBoard()[row, col - 1].pieceColor == board.GetBoard()[row, col + 1].pieceColor && board.GetBoard()[row, col - 1].pieceColor != curCol)
                    {
                        Color newCol = board.GetBoard()[row, col].FlipColor();
                        board.UpdateScore(curCol, newCol);
                    }
                }
            }
            if (curCol == board.GetBoard()[row, col].pieceColor)
            {
                if (row - 1 >= 0 && row + 1 < ROW)
                {
                    if (board.GetBoard()[row-1, col] != null && board.GetBoard()[row+1, col] != null)
                    {
                        if (board.GetBoard()[row-1, col].pieceColor == board.GetBoard()[row+1, col].pieceColor && board.GetBoard()[row-1, col].pieceColor != curCol)
                        {
                            Color newCol = board.GetBoard()[row, col].FlipColor();
                            board.UpdateScore(curCol, newCol);
                        }
                    }
                }
            }
        }

        public string  GetWinner()
        {
            int p1Score = PlayerList[0].GetScore();
            int p2Score = PlayerList[1].GetScore();

            if (p1Score > p2Score)
            {
                return PlayerList[0].GetName() +" "+ PlayerList[0].GetScore();
            }
            else if (p2Score > p1Score)
                return PlayerList[1].GetName() +" "+PlayerList[1].GetScore();
            else
                return "Its a tie";
        }
       
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game of Othello!");
            OthelloGame othelloGame = new OthelloGame();
            othelloGame.playGame();
            Console.WriteLine($"Winner of the game is {othelloGame.GetWinner()}");
        }
    }
}
