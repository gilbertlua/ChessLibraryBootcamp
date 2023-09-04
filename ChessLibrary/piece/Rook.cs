namespace ChessLibrary{
    public class Rook:Piece{
         public Rook(PieceColor color){
            SetName("Rook");
            SetSymbol("R");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(Move move){
            ValidateMove _validCheck = new ValidateMove();
            if (!base.IsMovedValid(move)){
                return false;
            }
            return _validCheck.IsRookMoveValid(move);
        }
    }    
}