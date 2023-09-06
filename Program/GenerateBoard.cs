using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ChessLibrary;

class GenerateBoard
{
	public Piece[,]? BoardPiece;
	// int numColomn,numRow;
	string[,] piecePos = new string[8,8];
	ChessBoard board = ChessBoard.GetTheBoard();
	public GenerateBoard(Piece[,] pieces)
	{
		BoardPiece = pieces;
		WriteBoard();
	}
	public void WriteBoard()
	{
		Console.Write("  ");
        for (int j = 0; j < 8; j++)
            Console.Write("\t" + j + " ");
        Console.Write("\n\n");
        for (int i = 0; i < 8; i++) {
            Console.Write(i);
            for (int j = 0; j < 8; j++)
                Console.Write("\t" + GetPiecesSymbol(new Spot(i, j)) + " ");
            Console.Write(' ');
            Console.WriteLine();
        }
	}
	private string GetPiecesSymbol(Spot spot){
		if(spot is not null){
			Piece? piece = board.GetPiece(spot);
			if(piece is not null){
				string symbol = piece.GetSymbol();
				if(piece.GetColor().Equals(PieceColor.white)){
					return "w"+symbol;
				}
				else if(piece.GetColor().Equals(PieceColor.black)){
					return "b"+symbol;
				}  
			}
			else{
				return "~";
			} 	
		}
		return "~";
	}
	

}