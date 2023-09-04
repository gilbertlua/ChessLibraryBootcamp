using System.Runtime.CompilerServices;

namespace ChessLibrary{
    /// <summary>
    /// Move class is use to handle the move piece
    /// </summary>
    public class Move{

        /// <summary>
        /// use to save data start spot
        /// </summary>
        private Spot _startSpot;
        /// <summary>
        /// use to save data end spot
        /// </summary>
        private Spot _endSpot;
        /// <summary>
        /// use to set start and the end spot
        /// </summary>
        /// <param name="startSpot">using this to the parameter new Spot(x,y)</param>
        /// <param name="endSPot">using this to the parameter new Spot(x,y)</param>
        public Move(Spot startSpot, Spot endSPot){
            _startSpot = startSpot;
            _endSpot = endSPot; 
        }
        /// <summary>
        /// Get start spot
        /// </summary>
        /// <returns>Spot</returns>
        public Spot GetStartSpot(){
            return _startSpot;
        }
        /// <summary>
        /// Get end spot
        /// </summary>
        /// <returns>Spot</returns>
        public Spot GetEndSpot(){
            return _endSpot;
        }
        
    }
}