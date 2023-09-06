namespace ChessLibrary{    
	public class GameController{
		private List<IPlayer>? _players = new List<IPlayer>();
		private ChessBoard _board = ChessBoard.GetTheBoard();

		public bool AddPlayer(IPlayer player){			
			if(player is not null){
				_players?.Add(player);
				return true;
			}
			return false;
		}
		public List<IPlayer> GetAllPlayers(){
			if(_players !=null){
				return _players;
			}
			throw new NullReferenceException("No player added in this game");
		}
		public bool PlayerTurn(IPlayer player, Move move){
			
			return true;
		}
		public bool SetPlayerToGame(IPlayer player1, IPlayer _player2){
				return true;
		}
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