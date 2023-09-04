namespace ChessLibrary{
    public class Queen:Piece{
         public Queen(PieceColor color){
            SetName("Queen");
            SetSymbol("Q");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(Move move){
            ValidateMove _validCheck = new ValidateMove();
            return _validCheck.IsQueenMoveValid(move);
        }
    }
}