using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
namespace ChessLibrary{

	
	public class ChessBoard{
		private static ChessBoard _boardChess = new ChessBoard();
		private Piece[,] _piecesHold;
		private int _sizeHeight;
		private int _sizeWidth;
		private List<IPiece> _captPiece = new List<IPiece>() ;
		private string[,] _configuration;
		CheckMate _checkMate = new();
		// string _json = "configuration.json"; 
		
		// constructur
		public ChessBoard(){
			Board board = new Board();
			_sizeWidth = board.GetWidth();
			_sizeHeight = board.GetHeight();
			_piecesHold = new Piece[_sizeWidth,_sizeHeight];
			_configuration = new string[,]{
				{"Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn", "Pawn"},
				{"Rook", "Knight", "Bishop", "Queen", "King", "Bishop", "Knight", "Rook"}
			};
			
			
			// configuration diganti ke serialization json atau xml
			// dibuat overloading yang parameter Piece
			// InitBoard();
			// SetNullAllBoard();
			SetPromoteBoard();
			// SetCheckMatBoard();
			// SetCapturedFriend();


		}
		public int GetHeight(){
			return _sizeHeight;
		}
		public int GetWidth(){
			return _sizeWidth;
		}
		/// <summary>
		/// get board 
		/// </summary>
		/// <returns></returns>
		public static ChessBoard GetTheBoard(){
			return _boardChess;
		}
		/// <summary>
		/// is used for intialize board of chess with configuration file
		/// </summary>
		public void InitBoard(){
			CreateInitPiece? ip = new CreateInitPiece();
			for (int i = 0; i < _sizeHeight; i++){
				for (int j = 0; j < _sizeWidth; j++){
					_piecesHold[i,j] = null!;
				}
			}            
			for(int i = 0; i < 2; i++){
				for(int j = 0; j < 8; j++){
					if(_configuration[i,j]!=null){
						SetPiece(ip.CreatePiece(_configuration[i,j], PieceColor.white), new Spot(i+_sizeHeight - 2, j));   
					}                         
				}
			}
			for(int i = 0; i < 2; i++){
				for(int j = 0; j < 8; j++){
					SetPiece(ip.CreatePiece(_configuration[i,j], PieceColor.black), new Spot(2-1-i, j));        
				}
			}

			
		}    
		/// <summary>
		/// set all tile to null piece
		/// </summary>
		public void SetNullAllBoard(){
			for (int i = 0; i < _sizeHeight; i++){
				for (int j = 0; j < _sizeWidth; j++){
					_piecesHold[i,j] = null!;
				}
			}     
		}
		public void SetPromoteBoard(){
			SetPiece(new Pawn(PieceColor.white),new Spot(1,0));
			SetPiece(new Pawn(PieceColor.black),new Spot(6,7));
			SetPiece(new King(PieceColor.white),new Spot(4,4));
			SetPiece(new King(PieceColor.black),new Spot(3,2));
		}		
		public void SetCheckMatBoard(){
			SetPiece(new Queen(PieceColor.white),new Spot(6,5));
			SetPiece(new King(PieceColor.white),new Spot(7,4));
			SetPiece(new Queen(PieceColor.black),new Spot(4,1));
			SetPiece(new King(PieceColor.black),new Spot(1,1));
		}
		public void SetCapturedFriend(){
			SetPiece(new Pawn(PieceColor.white),new Spot(6,5));
			SetPiece(new King(PieceColor.white),new Spot(7,4));
		}
		/// <summary>
		/// is used for move piece
		/// </summary>
		/// <param name="move"></param>
		/// <exception cref="Exception"></exception>
		public bool MovePiece(Move move){
			if(IsOutOfRange(move)){
				return false;
			}
			Piece tempPiece = GetPiece(move.GetStartSpot());
			if(tempPiece == null){
				return false;
			} 
			if(IsFriendPiece(move)){
				Console.WriteLine("Is Friend Piece");
				return false;
			}
			tempPiece.PieceGotMoved();
			if(!IsSpotEmpty(move.GetEndSpot())){
				CapturePiece(move.GetEndSpot());
			}
			SetPiece(tempPiece,move.GetEndSpot());
			ResetPiece(move.GetStartSpot());
			return true;
		}
		/// <summary>
		/// is use to reset tile
		/// </summary>
		/// <param name="spot"></param>
		public bool ResetPiece(Spot spot){
			if(_piecesHold[spot.Get_X(),spot.Get_Y()] is not null){
				_piecesHold[spot.Get_X(),spot.Get_Y()] = null!;
				return true;
			}
			return false;
		}
		/// <summary>
		/// is use to captured piece
		/// </summary>
		/// <param name="spot"></param>
		public bool CapturePiece(Spot spot){
			_captPiece.Add(GetPiece(spot));
			return true;
		}
		public List<IPiece> GetCapturedPiece(){
			if(_captPiece!=null){
				return _captPiece;
			}
			throw new NullReferenceException();
		}
		/// <summary>
		/// check if spot is empty
		/// </summary>
		/// <param name="spot"></param>
		/// <returns></returns>
		public bool IsSpotEmpty(Spot spot){
			bool check = _piecesHold[spot.Get_X(),spot.Get_Y()] == null!;
			return check;
		}
		/// <summary>
		/// is used for add piece for the position
		/// </summary>
		/// <param name="piece">the piece instance</param>
		/// <param name="spot">spot you want to go</param>
		public void SetPiece(Piece piece,Spot spot){
			if(IsOutOfRange(spot.Get_X(),spot.Get_Y())){
				throw new ArgumentOutOfRangeException();
			}
			else{
				if(piece!=null){
					_piecesHold[spot.Get_X(),spot.Get_Y()] = piece;
				}
			}
		}
		/// <summary>
		/// this method used to check if it is out of range
		/// </summary>
		/// <param name="move"></param>
		public bool IsOutOfRange(Move move){
			bool check = IsOutOfRange(move.GetStartSpot().Get_X(), move.GetStartSpot().Get_Y())
						|| IsOutOfRange(move.GetEndSpot().Get_X(), move.GetEndSpot().Get_Y());
			return check;
		}

		/// <summary>
		/// this method used to determine from move if is it out of ranges or not
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool IsOutOfRange(int x, int y){
			bool check = x < 0 || x >= _sizeHeight || y < 0 || y >= _sizeWidth;
			return check;
		}
		/// <summary>
		/// this metod used to view the board
		/// </summary>
		public Piece[,] GenerateBoard(){
			return _piecesHold;
		}      
		/// <summary>
		/// this method is used for get the piece in the coordinate
		/// </summary>
		/// <param name="spot"></param>
		/// <returns></returns>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public Piece GetPiece(Spot spot){
			if(IsOutOfRange(spot.Get_X(),spot.Get_Y())){
				throw new IndexOutOfRangeException();
			}
			return _piecesHold[spot.Get_X(),spot.Get_Y()];    
		}   
		public Piece GetPiece(int x, int y){
			if(IsOutOfRange(x,y)){
				throw new IndexOutOfRangeException();
			}
			return _piecesHold[x,y];    
		}   
		public bool IsFriendPiece(Move move){
			Piece destinationPiece = GetPiece(move.GetStartSpot());
			Piece startPiece = GetPiece(move.GetEndSpot());
			if(destinationPiece != null && startPiece != null){
				bool IsColorEqual = destinationPiece.GetColor().Equals(startPiece.GetColor());
				return IsColorEqual;	
			}
			
			return false;
		}
	}
}