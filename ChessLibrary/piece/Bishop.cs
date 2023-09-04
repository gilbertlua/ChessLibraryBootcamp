namespace ChessLibrary{
    public class Bishop:Piece{
        public Bishop(PieceColor color){
            SetName("Bishop");
            SetSymbol("B");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(Move move){
            ValidateMove _validCheck = new ValidateMove();
            if (!base.IsMovedValid(move)){
                return false;
            }               
            return _validCheck.IsBishopMoveValid(move); 

        }
    }
}