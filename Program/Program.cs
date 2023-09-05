using System.Security.Cryptography.X509Certificates;
using ChessLibrary;

class Program{
	static GameController gameController = new GameController();
	ChessPlayer[] _player = new ChessPlayer[5];
	
	static void Main(){
		Program program = new();
		// program.GenerateBoard();
		program.AddNewPlayer();
	}
	
	void AddNewPlayer()
	{
		_player[0] = new ChessPlayer();
		_player[0].SetName("Player 1");
		_player[0].SetPlayerId(1);
		_player[1] = new ChessPlayer();
		_player[1].SetName("Player 2");
		_player[1].SetPlayerId(2);
		gameController.AddPlayer(_player[0]);
	 	gameController.AddPlayer(_player[1]);
	}
	void GenerateBoard(){
		Piece[,] pieces = gameController.GetBoard();
		GenerateBoard genBoard = new(pieces);
	}
	
}