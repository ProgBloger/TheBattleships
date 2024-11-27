using System.Drawing;
using TheBattleShips.Application.Entities;

namespace TheBattleShips.Application
{
    public class ShipsInitializer
    {
        private IOProcessor _iOProcessor;

        public ShipsInitializer(IOProcessor iOProcessor) 
        {
            _iOProcessor = iOProcessor;
        }

        public Ship InitializeOneDeckShip(Dictionary<Point, ShipCell> shipCellDictionary)
        {
            const int shipDecks = 1;
            _iOProcessor.MessageOneDeckShip();

            return InitializeSizedShip(shipCellDictionary, shipDecks);
        }

        public Ship InitializeTwoDeckShip(Dictionary<Point, ShipCell> shipCellDictionary)
        {
            const int shipDecks = 2;
            _iOProcessor.MessageTwoDeckShip();

            return InitializeSizedShip(shipCellDictionary, shipDecks);
        }

        public Ship InitializeThreeDeckShip(Dictionary<Point, ShipCell> shipCellDictionary)
        {
            const int shipDecks = 3;
            _iOProcessor.MessageThreeDeckShip();

            return InitializeSizedShip(shipCellDictionary, shipDecks);
        }

        public Ship InitializeFourDeckShip(Dictionary<Point, ShipCell> shipCellDictionary)
        {
            const int shipDecks = 4;
            _iOProcessor.MessageFourDeckShip();

            return InitializeSizedShip(shipCellDictionary, shipDecks);
        }

        private Ship InitializeSizedShip(Dictionary<Point, ShipCell> shipCellDictionary, int shipDecks)
        {
            var currentPoints = new List<Point>();
            var currentShipCells = new List<ShipCell>();

            for (var i = 0; i < shipDecks; i++)
            {
                var point = GetShipPoint(shipCellDictionary, currentPoints);

                var shipCell = new ShipCell(point, _iOProcessor);
                shipCellDictionary.Add(point, shipCell);

                currentPoints.Add(point);
                currentShipCells.Add(shipCell);
            }

            var name = _iOProcessor.GetShipName();
            return new Ship(currentShipCells, name);
        }

        private Point GetShipPoint(Dictionary<Point, ShipCell> shipCellDictionary, List<Point> currentPoints)
        {
            const int boardSize = 10;
            var x = _iOProcessor.GetIntFromUser();
            var y = _iOProcessor.GetIntFromUser();

            var point = new Point(x, y);

            bool validationFailed = false;

            if (currentPoints.Any() && !currentPoints.Any(isNeighboringPoint(point)))
            {
                _iOProcessor.MessageShipCellsMustComeTogether();

                validationFailed = true;
            }

            if (shipCellDictionary.ContainsKey(point))
            {
                _iOProcessor.MessagePointIsAlreadyTaken();

                validationFailed = true;
            }

            bool pointInBoardBorders = 
                0 < point.X && point.X <= boardSize &&
                0 < point.Y && point.Y <= boardSize;

            if(!pointInBoardBorders)
            {
                _iOProcessor.MessagePointIsOutsideTheBoard();

                validationFailed = true;
            }

            if(validationFailed)
            {
                return GetShipPoint(shipCellDictionary, currentPoints);
            }

            return point;
        }

        private Func<Point, bool> isNeighboringPoint(Point point)
        {
            const int maxDistance = 1;

            return (it) =>
            {
                return
                    Math.Abs(it.X - point.X) == maxDistance && it.Y - point.Y == 0 || 
                    Math.Abs(it.Y - point.Y) == maxDistance && it.X - point.X == 0;
            };
        }
    }
}
