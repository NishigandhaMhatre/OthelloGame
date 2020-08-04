using System;
using System.Collections.Generic;
using System.Text;

namespace Othello
{
    class Piece
    {
        public Color pieceColor { get; set; } = Color.black;
        public Piece(Color color)
        {
            this.pieceColor = color;
        }

        public Color FlipColor()
        {
            if (this.pieceColor == Color.white)
            {
                this.pieceColor = Color.black;
            }
            else {
                this.pieceColor = Color.white;
            }
            return this.pieceColor;
        }

        public Color getColor()
        {
            return this.pieceColor;
        }
    }
}
