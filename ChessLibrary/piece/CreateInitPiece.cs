using System.Drawing;

namespace ChessLibrary{
	public class CreateInitPiece{
// ganti ke switch case
		public Piece CreatePiece(string name, PieceColor color){
			if(name.Equals("King",StringComparison.OrdinalIgnoreCase)){
				return new King(color);
			}
			else if(name.Equals("Knight",StringComparison.OrdinalIgnoreCase)){
				return new Knight(color);
			}
			else if(name.Equals("Queen",StringComparison.OrdinalIgnoreCase)){
				return new Queen(color);
			}
			else if(name.Equals("Rook",StringComparison.OrdinalIgnoreCase)){
				return new Rook(color);
			}
			else if(name.Equals("Bishop",StringComparison.OrdinalIgnoreCase)){
				return new Bishop(color);
			}
			return new Pawn(color);
		}
	}
}