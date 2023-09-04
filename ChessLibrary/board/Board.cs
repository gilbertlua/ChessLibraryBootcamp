namespace ChessLibrary
{
    public class Board
    {
        private int _height;
        private int _width;
        public Board(){
            _height = 8;
            _width = 8;
        }
        public int GetHeight() {
            return _height;
        }
        public int GetWidth(){
            return _width;
        }


    }
}

