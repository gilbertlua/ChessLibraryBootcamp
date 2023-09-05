using System.Globalization;
using System.Text;
using ChessLibrary;

class GenerateBoard
{
	public Piece[,]? BoardPiece;
	// int numColomn,numRow;
	string[,] piecePos = new string[8,8];
	StringBuilder sb = new StringBuilder();
	public GenerateBoard(Piece[,] pieces)
	{
		BoardPiece = pieces;
		WriteBoard();
	}
	public void WriteBoard()
	{
		
	}
	

}