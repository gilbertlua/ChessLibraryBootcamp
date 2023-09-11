namespace ChessLibrary.Test;

using System.Security.Authentication;
using ChessLibrary;
using NUnit.Framework;

public class PromotionTest{
    ChessBoard board = ChessBoard.GetTheBoard();
    PromotionMove _promote = new();


		/*
					  0   1   2   3   4   5   6   7   
					---------------------------------                
				0   |   |   |   |   |   |   |   |   |   
					---------------------------------
				1   |wP |   |   |   |   |   |   |   |      
					---------------------------------
				2   |   |   |   |   |   |   |   |   |   
					---------------------------------
				3   |   |   |   |   |   |   |   |   |   
					---------------------------------
				4   |   |   |   |   |   |   |   |   |   
					---------------------------------
				5   |   |   |   |   |   |   |   |   |   
					---------------------------------
				6   |   |   |   |   |   | wP|   |   |   
					---------------------------------
				7   |   |   |   |   | wK|   |   |   |   
					---------------------------------  
*/


    [Test]
    public void TestPromotion(){
        Piece[,] pieceHold = board.GenerateBoard();
        Move move;
        board.SetPiece(new Pawn(PieceColor.white),new Spot(1,0));
        Piece tempPiece = board.GetPiece(1,0);
        move = new Move(new Spot(1,0),new Spot(0,0));
        bool check = _promote.IsPromotionMove(tempPiece,move);
        Console.WriteLine("check");
        if(check){
            board.MovePiece(move);
            bool checkChoose = false;

            while(!checkChoose){
                Console.WriteLine("Choose which piece you want to promote");
                Console.WriteLine("1.Knight\n2.Queen\n3.Bishop\n4.Rook");
                int x = Convert.ToInt32(Console.ReadLine());

                switch(x){
                    case 1:
                        Console.WriteLine("Knight");
                        break; 
                    case 2:
                        Console.WriteLine("Queen");
                        break;
                    case 3:
                        Console.WriteLine("Bishop");
                        break;
                    case 4:
                        Console.WriteLine("Rook");
                        break;
                    default:
                        checkChoose = true;
                        break;
                }
                
            }
        }       
        
    }
    
}