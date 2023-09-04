namespace ChessLibrary{
    public class Knight:Piece{
         public Knight(PieceColor color){
            SetName("Knight");
            SetSymbol("Kn");
            SetColor(color);
        }

        // override
        public override bool IsMovedValid(Move move){
            ValidateMove _validCheck = new ValidateMove();
            if(!base.IsMovedValid(move)){
                return false;
            }
            return _validCheck.IsKnightMoveValid(move);
        }
    }
}

/*
example maps
    0   1   2   3   4   5   6   7 
0   
1
2
3
4
5   5,0
6
7       7,1


(x , y)
start spot -> (7 , 1)
end spot   -> (5 , 0)

xd = 5 - 7 = -2
yd = 1 - 0 = 0


*/