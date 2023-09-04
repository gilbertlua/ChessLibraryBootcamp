namespace ChessLibrary{    
    public class GameController{
        private List<IPlayer>? _players;
        private int _turn;
        private ChessBoard board = ChessBoard.GetTheBoard();

        public bool AddPlayer(IPlayer player){
            if(player is not null){
                _players?.Add(player);
                return true;
            }
            return false;
        }
        public List<IPlayer> GetAllPlayers(){
            if(_players is not null){
                return _players!;
            }
            throw new NullReferenceException("No player added in this game");
        }
        public bool PlayerTurn(IPlayer player, Move move){
            if(_turn == 1){
                return false;
            }
            return true;
        }
    }
}