namespace ChessLibrary.Test;
using ChessLibrary;
using NUnit.Framework;

public class PieceTest{
    // [Test]
    public void CreateNewSinglePiece(){
        Piece piece = new Pawn(PieceColor.black);

        string pieceName = piece.GetName();
        PieceColor colorPiece = piece.GetColor();

        Console.WriteLine("Piece Name\t:"+pieceName);
        Console.WriteLine("Piece Color\t:"+colorPiece);  
    }
    // [Test]
    public void CreatePieceUsingCreateInitPiece(){
        CreateInitPiece cP = new CreateInitPiece();
        Piece piece = cP.CreatePiece("King", PieceColor.white);
    
        string pieceName = piece.GetName();
        PieceColor colorPiece = piece.GetColor();
        Console.WriteLine("Piece Name\t:"+pieceName);
        Console.WriteLine("Piece Color\t:"+colorPiece);
    }
}