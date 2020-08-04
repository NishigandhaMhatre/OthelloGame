using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Board
    {
        private static Piece[,] Gameboard { get; set; }
        private static int BlackCount { get; set; } = 0;
        private static int WhiteCount { get; set; } = 0;
        private static int vacantPos { get; set; }

        public Board(int totalRows, int totalCols)
        {
            Gameboard = new Piece[totalRows,totalCols];
            vacantPos = totalRows * totalCols;
        }

        public bool PlacePiece(Piece piece, int row, int col)
        {
            if(IsEmpty(row, col))
            {
                Gameboard[row, col] = piece;
                Console.WriteLine($"Place piece of color {piece.pieceColor} at {row} , {col}");
                if (piece.pieceColor == Color.white) WhiteCount++;
                else
                    BlackCount++;

                vacantPos--;
                return true;
            }
            Console.WriteLine("Invalid move, try again");
            return false;
        }

        public Piece[,] GetBoard()
        {
            return Gameboard;
        }
        public bool IsEmpty(int row, int col)
        {
            if (Gameboard[row, col] == null) return true;
            return false;
        }

        public int GetScore(Color color)
        {
            if (color == Color.white) return WhiteCount;
            return BlackCount;
        }

        public void UpdateScore(Color prevColor, Color newColor)
        {
            if (prevColor == Color.white)
            {
                WhiteCount--;
                BlackCount++;
            }
            else {
                BlackCount--;
                WhiteCount++;
            }
        }

        public bool movesPossible()
        {
            Console.WriteLine($"Remaining moves {vacantPos}");
            return vacantPos > 0;
        }

        public override string ToString()
        {
            StringBuilder boardStr = new StringBuilder();
            for (int i = 0; i < Gameboard.GetLength(0); i++)
            {
                boardStr.Append("[");
                for (int j = 0; j < Gameboard.GetLength(1); j++)
                {
                    if (Gameboard[i, j] == null)
                        boardStr.Append(" xxxxx ");
                    else
                        boardStr.Append(" " + Gameboard[i, j].pieceColor + " ");
                }
                boardStr.Append("]");
                boardStr.Append("\n");
            }
            return boardStr.ToString();
        }
    }
}
