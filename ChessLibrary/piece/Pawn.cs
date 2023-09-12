namespace ChessLibrary{
    public class Pawn:Piece{
        
        //constructor 
        public Pawn(PieceColor color){
            SetName("Pawn");
            SetSymbol("P");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(Move move){
            ValidateMove _validCheck = new ValidateMove();
            if(!base.IsMovedValid(move)){
                return false;
            }
            return _validCheck.IsPawnMoveValid(move);
        }
    }
}