namespace ChessLibrary{
    public class ValidateMove{
        private static ChessBoard _chessBoard = ChessBoard.GetTheBoard();
        public bool IsPawnMoveValid(Move move){
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();
            int xD = endSpot.Get_X() - startSpot.Get_X();//-2
            int yD = endSpot.Get_Y() - startSpot.Get_Y();//0
            int side;
            if(_chessBoard.GetPiece(startSpot).GetColor().Equals(PieceColor.white)){
                side = -1;
            }
            else{
                side = 1;
            }
            Console.WriteLine("Side is : "+side);
            if(xD == side && yD == 0 && _chessBoard.IsSpotEmpty(endSpot)){
                return true;
            }
            if(xD == 2*side && yD == 0 && _chessBoard.IsSpotEmpty(new Spot(startSpot.Get_X()+side,startSpot.Get_Y()))&& !_chessBoard.GetPiece(startSpot).HasBeenMoved()){
                return true;
            }
            if(xD == side && Math.Abs(yD) == 1 && !_chessBoard.IsSpotEmpty(endSpot)){
                return true;
            }
            return false;            
        }
        public bool IsKnightMoveValid(Move move){
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();
            int xD = endSpot.Get_X() - startSpot.Get_X();
            int yD = endSpot.Get_Y() - startSpot.Get_Y();
            return Math.Abs(xD * yD) == 2;
        } 
        public bool IsBishopMoveValid(Move move){
            ChessBoard board = ChessBoard.GetTheBoard();
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();
            int xD = endSpot.Get_X() - startSpot.Get_X();
            int yD = endSpot.Get_Y() - startSpot.Get_Y();
            
            bool canMove = true;
            if (Math.Abs(xD) == Math.Abs(yD) && xD != 0) {
                int verticalDirection = xD > 0 ? 1 : -1;
                int horizontalDirection = yD > 0 ? 1 : -1;

                for (int i = 1; i < Math.Abs(xD); i++) {
                    int x = startSpot.Get_X() + i * verticalDirection;
                    int y = startSpot.Get_Y() + i * horizontalDirection;
                    if (!board.IsSpotEmpty(new Spot(x, y))){
                        canMove = false;
                    }                        
                }
            } 
            else{
                canMove = false;
            } 
            return canMove;
        }
        public bool IsRookMoveValid(Move move){
            ChessBoard board = ChessBoard.GetTheBoard();
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();
            int xD = endSpot.Get_X() - startSpot.Get_X();
            int yD = endSpot.Get_Y() - startSpot.Get_Y();

            bool canMove = true;
            if (xD != 0 && yD == 0) {
                int direction = xD > 0 ? 1 : -1;
                for (int i = 1; i < Math.Abs(xD); i++)
                    if (!board.IsSpotEmpty(new Spot(startSpot.Get_X() + i * direction, startSpot.Get_Y())))
                        canMove = false;
            } else //horizontal movement check
                if (xD == 0 && yD != 0) {
                    int direction = yD > 0 ? 1 : -1;
                    for (int i = 1; i < Math.Abs(yD); i++)
                        if (!board.IsSpotEmpty(new Spot(startSpot.Get_X(), startSpot.Get_Y() + i * direction)))
                            canMove = false;
                } else
                    canMove = false;

            return canMove;
        }
        public bool IsKingMoveValid(Move move){
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();

            int xD = Math.Abs(endSpot.Get_X() - startSpot.Get_X());
            int yD = Math.Abs(endSpot.Get_Y() - startSpot.Get_Y());
            return xD <= 1 && yD <= 1;
        }
        public bool IsQueenMoveValid(Move move){
            ChessBoard board = ChessBoard.GetTheBoard();
            Spot startSpot = move.GetStartSpot();
            Spot endSpot = move.GetEndSpot();

            int xD = endSpot.Get_X() - startSpot.Get_X();
            int yD = endSpot.Get_Y() - startSpot.Get_Y();

            bool canMove = true;
            if (xD != 0 && yD == 0) {
                int direction = xD > 0 ? 1 : -1;
                for (int i = 1; i < Math.Abs(xD); i++)
                    if (!board.IsSpotEmpty(new Spot(startSpot.Get_X() + i * direction, startSpot.Get_Y())))
                        canMove = false;
            } else //horizontal movement check
                if (xD == 0 && yD != 0) {
                    int direction = yD > 0 ? 1 : -1;
                    for (int i = 1; i < Math.Abs(yD); i++)
                        if (!board.IsSpotEmpty(new Spot(startSpot.Get_X(), startSpot.Get_Y() + i * direction)))
                            canMove = false;
                } else //diagonal movement check
                    if (Math.Abs(xD) == Math.Abs(yD) && xD != 0) {
                        int verticalDirection = xD > 0 ? 1 : -1;
                        int horizontalDirection = yD > 0 ? 1 : -1;

                        for (int i = 1; i < Math.Abs(xD); i++) {
                            int x = startSpot.Get_X() + i * verticalDirection;
                            int y = startSpot.Get_Y() + i * horizontalDirection;
                            if (!board.IsSpotEmpty(new Spot(x, y)))
                                canMove = false;
                        }
                    } else
                        canMove = false;

            return canMove;
        }
    }
}