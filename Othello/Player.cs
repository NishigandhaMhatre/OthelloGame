using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Player
    {
        string name { get; set; }
        Color playerColor { get; set; }
     
        public Player(String name, Color color)
        {
            this.name = name;
            this.playerColor = color;
        }

        public bool MakeMove(int row, int col)
        {
            return OthelloGame.GetGameInstance().GetBoard().PlacePiece(new Piece(this.playerColor), row, col);

        }

        public int GetScore()
        {
            return OthelloGame.GetGameInstance().GetBoard().GetScore(this.playerColor);
        }

        public Color GetColor()
        {
            return this.playerColor;
        }

        public string GetName()
        {
            return this.name;
        }
    }
}
