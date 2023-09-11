namespace ChessLibrary{
 
	public class CheckMate{

		ChessBoard _board = ChessBoard.GetTheBoard();
		Move? _move;
		CheckMateStatus _status;
		public Spot CheckKingPosition(PieceColor color){
			for(int i=0; i<8; i++){
				for(int j=0; j<8 ; j++){
					Piece tempPiece = _board.GetPiece(i,j);
					if(tempPiece!=null){
						if(tempPiece.GetColor().Equals(color)){
							if(tempPiece.GetName().Equals("King")){
								Console.WriteLine($"Piece Color {i} {j} "+ tempPiece.GetColor());
								return new Spot(i,j);
							}                            
						}
					}
				}
			}
			throw new Exception("No king in board");
		}
		public bool CheckMateConfirm(PieceColor color){
			Spot kingSpot = CheckKingPosition(color);
			for(int i=0; i<8; i++){
				for(int j=0; j<8 ; j++){
					Piece tempPiece = _board.GetPiece(i,j);
					
					if(tempPiece!=null){
						if(!tempPiece.GetColor().Equals(color)){
							_move = new Move(new Spot(i,j), kingSpot);
							Console.WriteLine($"{tempPiece.GetName()} {i}-{j}");
							bool check = tempPiece.IsMovedValid(_move);
							if(check){
								return true;                           
							}              
						}
						
					}
				}
			}
			return false;
		}
		public bool SetCheckMateStatus(CheckMateStatus status)
		{
			_status = status;
			return true;
		}
		public CheckMateStatus GetStatus(){    
			return _status;
		}
	}
}