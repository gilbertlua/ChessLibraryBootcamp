namespace ChessLibrary{
    public class Spot{
        private int _x;
        private int _y;

        public Spot(int x, int y) {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// use to get x spot coordinate
        /// </summary>
        /// <returns></returns>
        public int Get_X() { return _x; }
        /// <summary>
        /// use to get y coordinate
        /// </summary>
        /// <returns></returns>
        public int Get_Y() { return _y;}
    }
}