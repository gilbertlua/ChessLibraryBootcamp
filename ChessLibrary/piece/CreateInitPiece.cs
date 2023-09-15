using System.Drawing;

namespace ChessLibrary{
	public class CreateInitPiece{
// ganti ke switch case
		public Piece CreatePiece(string name, PieceColor color){
			switch (name.ToLower())
			{
				case "king":
					return new King(color);
				case "knight":
					return new Knight(color);
				case "queen":
					return new Queen(color);
				case "rook":
					return new Rook(color);
				case "bishop":
					return new Bishop(color);
				default:
					return new Pawn(color);
			}

		}
	}
}


// lukir
// promotion