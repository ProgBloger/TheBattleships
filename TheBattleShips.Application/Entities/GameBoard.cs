using System.Drawing;

namespace TheBattleShips.Application.Entities
{
    public class GameBoard
    {
        private Dictionary<Point, ShipCell> _shipCellDictionary = new Dictionary<Point, ShipCell>();
        private ShipsInitializer _shipsInitializer;
        private IOProcessor _iOProcessor;
        private bool NotAllShipsSank => _shipCellDictionary.Any(it => !it.Value.IsHit);

        public GameBoard(ShipsInitializer shipsInitializer, IOProcessor iOProcessor)
        {
            _shipsInitializer = shipsInitializer;
            _iOProcessor = iOProcessor;
        }

        public void Initialize()
        {
            int oneDeckShips = 1, twoDeckShips = 1, threeDeckShips = 1, fourDeckShips = 1;

            for (int i = 0; i < oneDeckShips; i++)
            {
                _shipsInitializer.InitializeOneDeckShip(_shipCellDictionary);
            }

            for (int i = 0; i < twoDeckShips; i++)
            {
                _shipsInitializer.InitializeTwoDeckShip(_shipCellDictionary);
            }

            for (int i = 0; i < threeDeckShips; i++)
            {
                _shipsInitializer.InitializeThreeDeckShip(_shipCellDictionary);
            }

            for (int i = 0; i < fourDeckShips; i++)
            {
                _shipsInitializer.InitializeFourDeckShip(_shipCellDictionary);
            }
        }

        public void Play()
        {
            do
            {
                int x = _iOProcessor.GetXCoordinate();
                int y = _iOProcessor.GetYCoordinate();
                Hit(x, y);

            } while (NotAllShipsSank);

            _iOProcessor.MessageGameFinished();
        }

        public void Hit(int x, int y)
        {
            var point = new Point(x, y);

            ShipCell shipCell;

            if (_shipCellDictionary.TryGetValue(point, out shipCell))
            {
                shipCell.Hit();
            }
            else
            {
                _iOProcessor.MissedMessage();
            }
        }
    }
}
