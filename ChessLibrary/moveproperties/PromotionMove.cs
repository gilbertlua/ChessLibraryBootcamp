namespace ChessLibrary{
    public class PromotionMove{
        public bool IsPromotionMove(Piece piece, Move move){
            ChessBoard board = ChessBoard.GetTheBoard();
            if(!piece.IsMovedValid(move)){
                return false;
            }
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();
            Piece tempPiece = board.GetPiece(startSpot);
            
            if(!(tempPiece is Pawn)){
                return false;
            }
            int limit;
            
            if(piece.GetColor().Equals(PieceColor.white)){limit = 0;}
            else{limit = board.GetHeight()-1;}
            
            return endSpot.Get_X() == limit;
        }
    }
}