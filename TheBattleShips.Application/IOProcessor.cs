
namespace TheBattleShips.Application
{
    public class IOProcessor
    {
        public int GetIntFromUser()
        {
            MessageDelimiter();
            Console.Write("Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine($"You entered: {number}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                return GetIntFromUser();
            }

            return number;
        }

        public string GetShipName()
        {
            MessageDelimiter();
            Console.WriteLine("The name of the ship determines its course. Let's name it:");
            return Console.ReadLine();
        }

        public int GetXCoordinate()
        {
            MessageDelimiter();
            Console.WriteLine("X coordinate to shoot:");
            return GetIntFromUser();
        }

        public int GetYCoordinate()
        {
            MessageDelimiter();
            Console.WriteLine("Y coordinate to shoot:");
            return GetIntFromUser();
        }

        public void MissedMessage()
        {
            MessageDelimiter();
            Console.WriteLine("missed");
        }

        public void MessageOneDeckShip()
        {
            MessageDelimiter();
            Console.WriteLine("A One deck ship will be dispatched. Give it coordinates:");
        }

        public void MessageTwoDeckShip()
        {
            MessageDelimiter();
            Console.WriteLine("A Two deck ship will be dispatched. Give it coordinates:");
        }

        public void MessageThreeDeckShip()
        {
            MessageDelimiter();
            Console.WriteLine("A Three deck ship will be dispatched. Give it coordinates:");
        }

        public void MessageFourDeckShip()
        {
            MessageDelimiter();
            Console.WriteLine("A Four deck ship will be dispatched. Give it coordinates:");
        }

        public void MessageSink(string name)
        {
            MessageDelimiter();
            Console.WriteLine($"sink {name}");
        }

        public void MessagePointIsAlreadyTaken()
        {
            MessageDelimiter();
            Console.WriteLine("Error: These coordinates are already taken!");
        }

        public void MessageHitAgain()
        {
            MessageDelimiter();
            Console.WriteLine("hit again");
        }

        public void MessageHit()
        {
            MessageDelimiter();
            Console.WriteLine("hit");
        }

        public void MessageGameFinished()
        {
            MessageDelimiter();
            Console.WriteLine("You won! Game Over!");
        }

        public void MessageDelimiter()
        {
            Console.WriteLine("------------");
        }

        public void MessageShipCellsMustComeTogether()
        {
            MessageDelimiter();
            Console.WriteLine("Error: Ship coordinates must come together!");
        }

        public void MessagePointIsOutsideTheBoard()
        {
            MessageDelimiter();
            Console.WriteLine("Error: Coordinates are outside of the board!");
        }
    }
}
