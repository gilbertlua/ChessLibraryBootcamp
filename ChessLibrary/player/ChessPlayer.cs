namespace ChessLibrary{
	public class ChessPlayer:IPlayer{
		private string? _name;
		private int _id;
		public bool SetName(string name){
			if(name is not null){
				_name = name;
				return true;
			}
			return false;
		}
		public string GetPlayerName(){
			if(_name is not null){
				return _name;
			}
			else{
				return " ";
			}
		}
		public bool SetPlayerId(int id){
			if(id!=0){
				_id = id;
				return true;
			}
			return false;
		}
		public int GetPlayerId(){
			if(_id !=0){
				return _id;
			}   
			return 0;
		}
		
	}
}
