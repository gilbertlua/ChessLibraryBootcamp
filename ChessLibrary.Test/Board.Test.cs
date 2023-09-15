namespace ChessLibrary.Test;
using ChessLibrary;
using NUnit.Framework;
public class Tests
{

    // [Test]
    public void TestGetBoard()
    {
        Board board = new Board();    
        int height = board.GetHeight();
        int width = board.GetWidth();
        Console.WriteLine("height \t: " + height);
        Console.WriteLine("width \t: "+ width);        
    }
    // [Test]
    public void TestGenerateChessBoardUsingAllNullTile(){
        ChessBoard board = ChessBoard.GetTheBoard();
        board.SetNullAllBoard();
        Piece[,] piece = board.GenerateBoard();
        int i=0;
        foreach(Piece _piece in piece){
            try{
                Console.WriteLine($"{i++}.\t{_piece.GetName()}");
            }
            catch{
                Console.WriteLine("null");
            }
        }
    }
    // [Test]
    public void TestGenerateChessBoardUsingForm(){
        ChessBoard board = ChessBoard.GetTheBoard();
        board.InitBoard();
        Piece[,] piece = board.GenerateBoard();
        int i=0;
        foreach(Piece _piece in piece){
            try{
                Console.WriteLine($"{i++}.\t{_piece.GetName()}");
            }
            catch{
                Console.WriteLine("null"); 
            }
        }
    }
    // [Test]
    public void SetPieceInBordCoordinate(){
        ChessBoard board = ChessBoard.GetTheBoard();
        Spot spot = new Spot(3,3);   
        Piece piece = new Pawn(PieceColor.white);
        board.SetPiece(piece,spot);
        
        Piece[,] pieceInBoard = board.GenerateBoard();
        string pieceInCoor = pieceInBoard[spot.Get_X(),spot.Get_Y()].GetName();
        Console.WriteLine(pieceInCoor);
    }
}