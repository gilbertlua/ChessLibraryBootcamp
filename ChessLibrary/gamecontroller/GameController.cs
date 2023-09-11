namespace ChessLibrary{    
	public class GameController{
		private Dictionary<IPlayer, PieceColor>? _players = new Dictionary<IPlayer, PieceColor>();
		private ChessBoard _board = ChessBoard.GetTheBoard();
		private CheckMate checkMate = new CheckMate();
		private int _sequance = 0;
		// buat method equality compiller
		// 
		public bool CheckMateCheck(PieceColor color)
		{
			return checkMate.CheckMateConfirm(color);			
		}
		public CheckMateStatus GetCheckMateStatus()
		{
			return checkMate.GetStatus();
		}
		public bool ResetCheckMateStatus()
		{
			checkMate.SetCheckMateStatus(CheckMateStatus.NotCheckMate);
			return true;
		}
		public bool IncrementSequence(){
			_sequance++;
			return true;
		}
		public int GetSequenceNum(){
			return _sequance;
		}
		public bool AddPlayer(IPlayer player,PieceColor color){			
			if(player is not null){
				_players?.Add(player,color);
				return true;
			}
			return false;
		}
		public Dictionary<IPlayer,PieceColor> GetAllPlayers(){
			if(_players !=null){
				return _players;
			}
			throw new NullReferenceException("No player added in this game");
		}
		public IPlayer PlayerTurn(){
			if(_players != null){
				if(_sequance % 2 == 0){
					return _players.ElementAt(0).Key;
				}
				else{
					return _players.ElementAt(1).Key;
				}
			}
			throw new Exception("no player added");
		}
		/*
			buat metod Next turn
		*/

		public Piece[,] GetBoard(){
			return _board.GenerateBoard();
		}

		// Move handle
		public bool MovePiece(Move move){
			if(move is not null){
				Piece tempPiece = _board.GetPiece(move.GetStartSpot());
				bool check = tempPiece.IsMovedValid(move);
				if(check){
					_board.MovePiece(move);
					return true;
				}
				else{
					return false;
				}
			}
			return false;
		}	

		// get capture piece
		public List<IPiece> GetCapturedPiece(){
			return _board.GetCapturedPiece();
		}
	}
}