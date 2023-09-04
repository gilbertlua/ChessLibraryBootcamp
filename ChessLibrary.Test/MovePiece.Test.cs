namespace ChessLibrary;
using ChessLibrary;
using NUnit.Framework;

	
public class MovePiece{
	[Test]
	public void MovePieceSingleTest(){
				/*
				if the board look like this and the pawn start spot
				position in coordinate [6,0]. so the move validation list
				is in coordinate [5,0] and [4,0] look like illustration below

					  0   1   2   3   4   5   6   7   
					---------------------------------                
				0   |   |   |   |   |   |   |   |   |   
					---------------------------------
				1   |   |   |   |   |   |   |   |   |      
					---------------------------------
				2   |   |   |   |   |   |   |   |   |   
					---------------------------------
				3   |   |   |   |   |   |   |   |   |   
					---------------------------------
				4   | X1|   |   |   |   |   |   |   |   
					---------------------------------
				5   | X0|   |   |   |   |   |   |   |   
					---------------------------------
				6   | wP|   |   |   |   |   |   |   |   
					---------------------------------
				7   |   |   |   |   |   |   |   |   |   
					---------------------------------               

			so try using move and spot to move the peace, in correct position and will return true
			and incorect postion will return false
			*/
			/*start with set piece in board*/

			ChessBoard board = ChessBoard.GetTheBoard();

			board.SetNullAllBoard();
			Spot startSpot = new Spot(6,0);
			Spot endSpot = new Spot(4,0);      
			Piece piece = new Pawn(PieceColor.white);
			board.SetPiece(piece,startSpot);

			/* then move the piece to correct position, in example [2,0] or [3,0]*/
			/* using board.MovePiece to move the piece from current postion to destination position*/
			Move move= new Move(startSpot,endSpot);

			/*
				the move piece position will check the current position if it have piece or not
				if it have piece, then will check the destination spot, and will validate if the 
				destination is valid or not
			*/
			/*
				first of all is check if the move valid or not using Piece.IsMoveValid                
			*/
			bool check = piece.IsMovedValid(move);
			Console.WriteLine("is valid to move? "+check);

			if(check is true){
				bool canMove = board.MovePiece(move);
				Console.WriteLine("can move? " + canMove);
			}
			else{
				Console.WriteLine("Move invalid");
			}
			Console.WriteLine(board.GetPiece(endSpot).GetName());                           
		}

[Test]
	public void MoveKnightPieceTest(){
		
/*            0   1   2   3   4   5   6   7   
			---------------------------------                
		0   |   |   |   |   |   |   |   |   |   
			---------------------------------
		1   |   |   |   |   |   |   |   |   |      
			---------------------------------
		2   |   |   |   |   |   |   |   |   |   
			---------------------------------
		3   |   |   |   |   |   |   |   |   |   
			---------------------------------
		4   |   |   |   |   |   |   |   |   |   
			---------------------------------
		5   | X1|   | X0|   |   |   |   |   |   
		---------------------------------
		6   |   |   |   |   |   |   |   |   |   
			---------------------------------
		7   |   | Kn|   |   |   |   |   |   |   
			---------------------------------               
*/        
		
		ChessBoard board = ChessBoard.GetTheBoard();
		board.SetNullAllBoard();
		Spot startSpot = new Spot(7,1);
		Spot endSpot = new Spot(5,2);      
		Piece piece = new Knight(PieceColor.white);
		board.SetPiece(piece,startSpot);

		Move move= new Move(startSpot,endSpot);
		bool check = piece.IsMovedValid(move);
		Console.WriteLine("is valid to move? "+check);

		if(check is true){
			bool canMove = board.MovePiece(move);
			Console.WriteLine("can move? " + canMove);
		}
		else{
			Console.WriteLine("Move invalid");
		}
		Console.WriteLine(board.GetPiece(endSpot).GetName());
	}

	// [Test]
	public void MoveBishopPieceTest(){
		
/*            0   1   2   3   4   5   6   7   
			---------------------------------                
		0   |   |   |   |   |   |   |   |   |   
			---------------------------------
		1   |   |   |   |   |   |   |   |   |      
			---------------------------------
		2   |   |   |   |   |   |   |   |X4 |   
			---------------------------------
		3   |   |   |   |   |   |   |X3 |   |   
			---------------------------------
		4   |   |   |   |   |   |X2 |   |   |   
			---------------------------------
		5   |X7 |   |   |   |X1 |   |   |   |   
		---------------------------------
		6   |   |X6 |   |X0 |   |   |   |   |   
			---------------------------------
		7   |   |   | Bs|   |   |   |   |   |   
			---------------------------------               
*/        
		
		ChessBoard board = ChessBoard.GetTheBoard();
		board.SetNullAllBoard();
		Spot startSpot = new Spot(7,2);
		Spot endSpot = new Spot(5,4);      
		Piece piece = new Bishop(PieceColor.white);
		board.SetPiece(piece,startSpot);

		Move move= new Move(startSpot,endSpot);
		bool check = piece.IsMovedValid(move);
		Console.WriteLine("is valid to move? "+check);

		if(check is true){
			bool canMove = board.MovePiece(move);
			Console.WriteLine("can move? " + canMove);
		}
		else{
			Console.WriteLine("Move invalid");
		}
		Console.WriteLine(board.GetPiece(endSpot).GetName());
	}      

// [Test]
	public void MoveRookPieceTest(){
		
/*            0   1   2   3   4   5   6   7   
			---------------------------------                
		0   |   |   |   |X11|   |   |   |   |   
			---------------------------------
		1   |   |   |   |X12|   |   |   |   |      
			---------------------------------
		2   |   |   |   |X9 |   |   |   |   |   
			---------------------------------
		3   |   |   |   |X8 |   |   |   |   |   
			---------------------------------
		4   |X0 |X1 |X2 | R |X3 |X4 |X5 |X5 |   
			---------------------------------
		5   |   |   |   |X6 |   |   |   |   |   
			---------------------------------
		6   |   |   |   |X7 |   |   |   |   |   
			---------------------------------
		7   |   |   |   |X7 |   |   |   |   |   
			---------------------------------               
*/        
		
		ChessBoard board = ChessBoard.GetTheBoard();
		board.SetNullAllBoard();
		Spot startSpot = new Spot(4,3);
		Spot endSpot = new Spot(7,3);      
		Piece piece = new Rook(PieceColor.white);
		board.SetPiece(piece,startSpot);

		Move move= new Move(startSpot,endSpot);
		bool check = piece.IsMovedValid(move);
		Console.WriteLine("is valid to move? "+check);

		if(check is true){
			bool canMove = board.MovePiece(move);
			Console.WriteLine("can move? " + canMove);
		}
		else{
			Console.WriteLine("Move invalid");
		}
		Console.WriteLine(board.GetPiece(endSpot).GetName());
	}

	// [Test]
	public void MoveKingPieceTest(){
		
/*            0   1   2   3   4   5   6   7   
			---------------------------------                
		0   |   |   |   |   |   |   |   |   |   
			---------------------------------
		1   |   |   |   |   |   |   |   |   |      
			---------------------------------
		2   |   |   |   |   |   |   |   |   |   
			---------------------------------
		3   |   |   |   |   |   |   |   |   |   
			---------------------------------
		4   |   |X0 |X0 |X0 |   |   |   |   |   
			---------------------------------
		5   |   |X0 | K |X0 |   |   |   |   |   
		---------------------------------
		6   |   |X0 |X0 |X0 |   |   |   |   |   
			---------------------------------
		7   |   |   |   |   |   |   |   |   |   
			---------------------------------               
*/        
		
		ChessBoard board = ChessBoard.GetTheBoard();
		board.SetNullAllBoard();
		Spot startSpot = new Spot(5,2);
		Spot endSpot = new Spot(4,2);      
		Piece piece = new King(PieceColor.white);
		board.SetPiece(piece,startSpot);
		Move move= new Move(startSpot,endSpot);
		bool check = piece.IsMovedValid(move);
		Console.WriteLine("is valid to move? "+check);

		if(check is true){
			bool canMove = board.MovePiece(move);
			Console.WriteLine("can move? " + canMove);
		}
		else{
			Console.WriteLine("Move invalid");
		}
		Console.WriteLine(board.GetPiece(endSpot).GetName());
	}            

	[Test] 
	public void MoveQueenPieceTest(){
		
/*            0   1   2   3   4   5   6   7   
			---------------------------------                
		0   |   |   |X4 |   |   |   |   |X4 |   
			---------------------------------
		1   |   |   |X4 |   |   |   |X4 |   |      
			---------------------------------
		2   |   |   |X4 |   |   |X4 |   |   |   
			---------------------------------
		3   |X4 |   |X4 |   |X4 |   |   |   |   
			---------------------------------
		4   |   |X4 |X4 |X4 |   |   |   |   |   
			---------------------------------
		5   |X4 |X4 | Q |X4 |X4 |X4 |X4 |X4 |   
			---------------------------------
		6   |   |X0 |X4 |X2 |   |   |   |   |   
			---------------------------------
		7   |X1 |   |X4 |   |X3 |   |   |   |   
			---------------------------------               
*/        
		
		ChessBoard board = ChessBoard.GetTheBoard();
		board.SetNullAllBoard();
		Spot startSpot = new Spot(5,2);
		Spot endSpot = new Spot(5,3);      
		Piece piece = new Queen(PieceColor.white);
		board.SetPiece(piece,startSpot);
		Move move= new Move(startSpot,endSpot);
		bool check = piece.IsMovedValid(move);
		Console.WriteLine("is valid to move? "+check);

		if(check is true){
			bool canMove = board.MovePiece(move);
			Console.WriteLine("can move? " + canMove);
		}
		else{
			Console.WriteLine("Move invalid");
		}
		Console.WriteLine(board.GetPiece(endSpot).GetName());
	}
}
