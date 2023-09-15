using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using ChessLibrary;
using NLog;

class Program{
	private static readonly Logger logger = LogManager.GetCurrentClassLogger();	
	static GameController gameController = new GameController();
	ChessBoard _board = ChessBoard.GetTheBoard();
	ChessPlayer[] _player = new ChessPlayer[2];
	Dictionary<IPlayer,PieceColor> _allPplayer = gameController.GetAllPlayers();
	CheckMate _checkMate = new CheckMate();
	Move? _move;
	Spot? startSpot;
	Spot? endSpot;
	Piece? tempPiece;
	PromotionMove? _promotion;
	
	static void Main(){
		Program program = new();
		logger.Info("test");
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
			Console.WriteLine("\nstatus :" +gameController.GetCheckMateStatus()+"\n--------");
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
		Console.WriteLine("\nEnter piece destination :");	
		Console.Write("x : ");endX = Convert.ToInt32(Console.ReadLine());
		Console.Write("y : ");endY = Convert.ToInt32(Console.ReadLine());
		endSpot = new Spot(endX,endY);
		_move = new Move(startSpot,endSpot);
		
		try
		{
			tempPiece = _board.GetPiece(startSpot);	
		}
		catch
		{
			Console.WriteLine("position or destination not valid");
			Console.ReadKey();
			Console.Clear();
			ValidateMoveDestination();
		}
				
		
		if(tempPiece != null){
			_allPplayer.TryGetValue(gameController.PlayerTurn(), out PieceColor color);
			
			if(tempPiece.GetColor().Equals(color)){
				Console.WriteLine("current color :" + color);
				bool checkIsPieceValidToMove = tempPiece.IsMovedValid(_move);
				Console.Write(tempPiece.GetName()+"  ~  ");
				Console.WriteLine(tempPiece.GetColor());
				if(checkIsPieceValidToMove){
					bool canPromote = PromoteCheck(tempPiece,_move);
					bool check = _board.MovePiece(_move);
					if(check){
						bool checkStatus = gameController.CheckMateCheck(tempPiece.GetColor());
						if(!checkStatus)
						{
							if(canPromote)
							{
								SwapPiece(_move);
							}	
							else
							{
								
							}						
							gameController.IncrementSequence();	
						}
						else
						{
							_board.ResetPiece(endSpot);
							_board.SetPiece(tempPiece,startSpot);							
							Console.WriteLine("Skak!!!");
						}
						
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

	bool PromoteCheck(Piece piece, Move move)
	{
		_promotion = new PromotionMove();
		bool check = _promotion.IsPromotionMove(piece,move);
		return check;
	}
	
	public void SwapPiece(Move? move)
	{
		Console.WriteLine("\nWhich pieces do you want to promote:");
		Console.WriteLine("1. Rook");
		Console.WriteLine("2. Queen");
		Console.WriteLine("3. Bishop");
		Console.WriteLine("4. Knight");	
		
		
		bool validPiece = false;
		while(!validPiece)
		{
			Console.Write("Your choose :");
			int choose;
			
			if(int.TryParse(Console.ReadLine(),out choose))
			{
				Console.WriteLine(choose);
				bool check = (choose>=1)&&(choose<=4);
				if(!check)
				{
					Console.WriteLine("invalid input");
					continue;
				}
				else
				{
					Spot endSpot = _move!.GetEndSpot();
					gameController.SwapPiecePromote(endSpot,choose);
					validPiece = true;
				}	
			}				
		}
	
		
		
	}	
}