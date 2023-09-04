namespace ChessLibrary.Test;
using ChessLibrary;
using NUnit.Framework;

public class MoveTest{
    
    // [Test]
    public void UsingSpotTest(){
        Spot spot = new Spot(1,4);
        int x = spot.Get_X();
        int y = spot.Get_Y();
        Console.WriteLine($"x value : {x}");
        Console.WriteLine($"y value : {y}");
    }
    // [Test]
    public void MoveUsingSpotTest(){
        Spot startSpot = new Spot(1,4);
        Spot endSpot = new Spot(4,4);
        Move move = new Move(startSpot,endSpot);
        int startSpot_X = move.GetStartSpot().Get_X();
        int startSpot_Y = move.GetStartSpot().Get_Y();
        int endSpot_X = move.GetEndSpot().Get_X();
        int endSpot_Y = move.GetEndSpot().Get_Y();
        Console.WriteLine($"Start Spot x : {startSpot_X}");
        Console.WriteLine($"Start Spot x : {startSpot_Y}");
        Console.WriteLine($"Start Spot x : {endSpot_X}");
        Console.WriteLine($"Start Spot x : {endSpot_Y}");
    }
}