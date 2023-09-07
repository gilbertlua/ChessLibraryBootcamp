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
								return new Spot(i,j);
							}                            
						}
					}
				}
			}
			throw new Exception("No king in board");
		}
		public void CheckMateConfirm(PieceColor color){
			for(int i=0; i<8; i++){
				for(int j=0; j<8 ; j++){
					Piece tempPiece = _board.GetPiece(i,j);
					if(tempPiece!=null){
						if(!tempPiece.GetColor().Equals(color)){
							_move = new Move(new Spot(i,j), CheckKingPosition(color));
							bool check = tempPiece.IsMovedValid(_move);
							if(check){
								_status = CheckMateStatus.CheckMate;                                
							}                                      
							else{
								_status = CheckMateStatus.NotCheckMate;
							}              
						}
					}
				}
			}
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