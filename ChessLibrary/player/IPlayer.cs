namespace ChessLibrary{
    public interface IPlayer{
        public bool SetName(string name);
        public string GetPlayerName();
        public bool SetPlayerId(int id);
        public int GetPlayerId();
    }
}