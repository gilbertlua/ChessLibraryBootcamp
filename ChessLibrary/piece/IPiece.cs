namespace ChessLibrary{
	public interface IPiece{
		public bool SetName(string name);
		public bool SetSymbol(string symbol);
		public bool SetColor(PieceColor color);
		public string GetName();
		public string GetSymbol();
		public PieceColor GetColor();
	}
}