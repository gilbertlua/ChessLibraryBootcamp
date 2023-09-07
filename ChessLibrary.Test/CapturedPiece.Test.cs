using NUnit.Framework;
using ChessLibrary;
class CapturedPiece{
	// [Test]

    public void CapturedPieceTest(){
/*
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
				4   |   |   |   |   |   |   |   |   |   
					---------------------------------
				5   |   | bP|   |   |   |   |   |   |   
					---------------------------------
				6   | wP|   |   |   |   |   |   |   |   
					---------------------------------
				7   |   |   |   |   |   |   |   |   |   
					---------------------------------  
*/
        Piece piece1 =  new Pawn(PieceColor.white);
		Piece piece2 =  new Pawn(PieceColor.black);
		ChessBoard board = ChessBoard.GetTheBoard();
		board.SetPiece(piece1,new Spot(6,0));
		board.SetPiece(piece2,new Spot(5,1));

		
		Move move = new Move(new Spot(6,0), new Spot(5,1) );
		Piece pc = board.GetPiece(new Spot(6,0));
		bool check = pc.IsMovedValid(move);
		
		if(check){
			board.MovePiece(move);
			Console.WriteLine("Success captured piece");
		}

		foreach(Piece piece in board.GetCapturedPiece()){
			Console.WriteLine(piece.GetName());
			Console.WriteLine(piece.GetColor());
		}		
    }

[Test]
	public void CheckMateTest(){
		CheckMate _checkMate= new CheckMate();
		ChessBoard _board = ChessBoard.GetTheBoard();


		/*
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
				4   |   |   |   |   |   |   |   |   |   
					---------------------------------
				5   |   |   |   |   |   |   |   |   |   
					---------------------------------
				6   |   |   |   |   |   | wP|   |   |   
					---------------------------------
				7   |   |   |   |   | wK|   |   |   |   
					---------------------------------  
*/

		_board.SetPiece(new Pawn(PieceColor.white),new Spot(6,0));
		_board.SetPiece(new King(PieceColor.black),new Spot(6,1));
		Spot spot = _checkMate.CheckKingPosition(PieceColor.black);
		Console.WriteLine($"{spot.Get_X()} {spot.Get_Y()}");
		_checkMate.CheckMateConfirm(PieceColor.white);


	}
}