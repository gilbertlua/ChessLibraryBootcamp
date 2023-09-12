namespace ChessLibrary{
    public class King:Piece{
         public King(PieceColor color){
            SetName("King");
            SetSymbol("K");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(Move move){
            ValidateMove _validCheck = new ValidateMove();
            if(!base.IsMovedValid(move)){
                return false;
            }
            return _validCheck.IsKingMoveValid(move);
        }
    }
}