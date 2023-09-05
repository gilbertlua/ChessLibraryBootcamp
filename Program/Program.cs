using ChessLibrary;

class Program{
    static GameController gameController = new GameController();
    
    static void Main(){
        Program program = new();
        program.GenerateBoard();
    }
    void GenerateBoard(){
        Piece[,] pieces = gameController.GetBoard();

        foreach(Piece piece in pieces){
            Console.WriteLine(piece.GetName());
        }
    }
}