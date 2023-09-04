namespace ChessLibrary{
	public abstract class Piece:IPiece{
		private string? _name;
		private string? _symbol;
		private PieceColor _color;
		private int _moveAmount;
		// set
		public bool SetName(string name)
		{
			if(name is not null)
			{
				_name = name;
				return true;
			}
			return false;
			
		}
		public bool SetSymbol(string symbol)
		{
			if(symbol is not null)
			{
				_symbol = symbol;
				return true;
			}
			return false;
		}
		
		public bool SetColor(PieceColor color)
		{
			_color = color;
			return true;
		}
		
		// get
		public string GetName()
		{
			if(_name is not null)
			{
				return _name;
			}
			else
			{
				throw new ArgumentNullException("require set name before");	
			}
			
		}
		public string GetSymbol()
		{
			if(_symbol is not null)
			{
				return _symbol;
			}
			else
			{
				throw new ArgumentNullException("require set symbol before");	
			}
		}
		public PieceColor GetColor(){
			return _color;
		}

		// is move valid
		public virtual bool IsMovedValid(Move move){
			ChessBoard board = ChessBoard.GetTheBoard();
			if (board.IsOutOfRange(move)){
				Console.WriteLine("IsOutOfRange");
				return false;
			}
			if (board.IsSpotEmpty(move.GetStartSpot())){
				Console.WriteLine(move.GetStartSpot().Get_X()+" "+" "+move.GetStartSpot().Get_Y());
				Console.WriteLine("IsSpotEmpty -> " + board.IsSpotEmpty(move.GetStartSpot()));
				return false;
			}
			if (move.GetStartSpot().Equals(move.GetEndSpot())){
				Console.WriteLine("IsEquals");
				return false;
			}
			return true;
		}

		public bool IsAllyPiece(IPiece piece){
			return piece != null && _color.Equals(piece.GetColor());
		}
		public int GetMoveAmount(){
			return _moveAmount;
		}
		public bool HasBeenMoved(){
			return _moveAmount!=0;
		}
		public void PieceGotMoved(){
			_moveAmount++;
		}
	}
}