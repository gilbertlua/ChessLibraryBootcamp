using System.Security.Cryptography.X509Certificates;
using ChessLibrary;

class Program{
	static GameController gameController = new GameController();
	ChessBoard _board = ChessBoard.GetTheBoard();
	ChessPlayer[] _player = new ChessPlayer[2];
	Dictionary<IPlayer,PieceColor> _allPplayer = gameController.GetAllPlayers();
	CheckMate _checkMate = new CheckMate();
	Move? _move;
	Spot? startSpot;
	Spot? endSpot;
	
	static void Main(){
		Program program = new();		
		program.AddNewPlayer();
		program.GameStart();
	}
	void DisplayAllPlayer(){
		
		foreach(var x in _allPplayer ){
			Console.WriteLine("Player Name : " + x.Key.GetPlayerName()+ "\tPlayer id : "+x.Key.GetPlayerId()+"\tColor : "+x.Value);
		}

	}
	void AddNewPlayer()
	{
		_player[0] = new ChessPlayer();
		_player[0].SetName("Ando");
		_player[0].SetPlayerId(1);
		_player[1] = new ChessPlayer();
		_player[1].SetName("Joker");
		_player[1].SetPlayerId(2);
		gameController.AddPlayer(_player[0],PieceColor.white);
	 	gameController.AddPlayer(_player[1],PieceColor.black);
	}
	void GenerateBoard(){
		Piece[,] pieces = gameController.GetBoard();
		GenerateBoard genBoard = new(pieces);
	}
	void GameStart(){
		
		while(true){
			DisplayCapturedPiece();
			GenerateBoard();
			Console.WriteLine("\nstatus :" +_checkMate.GetStatus()+"\n--------");
			Console.WriteLine("\n--------\nPlayer "+ gameController.PlayerTurn().GetPlayerName()+" turn");
			ValidateMoveDestination();
			Console.ReadKey();
			Console.Clear();
		}	
		
	}
	void DisplayCapturedPiece(){
		DisplayAllPlayer();
		Console.WriteLine("\nPiece Captured");
		Console.WriteLine("--------------------------------------------------------------");
		if(gameController.GetCapturedPiece() is not null){
			foreach(var x in gameController.GetCapturedPiece()){
				Console.WriteLine("Piece Name : "+x.GetName()+"\t"+"Color : "+x.GetColor());
			}
		}
		else{
			Console.WriteLine("No Captured Piece yet");
		}
		Console.WriteLine("\n\n");

	}
	void ValidateMoveDestination(){
		int startX,startY;
		int endX,endY;
		Console.WriteLine("\nEnter piece position :");
		Console.Write("x : ");startX = Convert.ToInt32(Console.ReadLine());
		Console.Write("y : ");startY = Convert.ToInt32(Console.ReadLine());
		startSpot = new Spot(startX,startY);
		
// class diagram
// Skak
// check swith turn
// gabisa move kalo ke tempat teman
		Console.WriteLine("\nEnter piece destination :");	
		Console.Write("x : ");endX = Convert.ToInt32(Console.ReadLine());
		Console.Write("y : ");endY = Convert.ToInt32(Console.ReadLine());
		endSpot = new Spot(endX,endY);
		_move = new Move(startSpot,endSpot);
		
		Piece tempPiece = _board.GetPiece(startSpot);		
		if(tempPiece != null){
			_allPplayer.TryGetValue(gameController.PlayerTurn(), out PieceColor color);
			
			if(tempPiece.GetColor().Equals(color)){
				Console.WriteLine("current color :" + color);
				bool checkIsPieceValidToMove = tempPiece.IsMovedValid(_move);
				Console.Write(tempPiece.GetName()+"  ~  ");
				Console.WriteLine(tempPiece.GetColor());
				if(checkIsPieceValidToMove){
					bool check = _board.MovePiece(_move);
					if(check){
						Console.WriteLine("success move");
						_checkMate.IsCheckMate(tempPiece.GetColor());
						gameController.IncrementSequence();
					}
					else{
						Console.WriteLine("error to move");
					}
				}
				else{
					Console.WriteLine("Piece destination not valid");
				}	
			}
			else{
				Console.WriteLine("Bukan giliran anda gan!!!");
			}
			
		}
		else{
			Console.WriteLine("No piece in spot");
		}
		
	}

	
}