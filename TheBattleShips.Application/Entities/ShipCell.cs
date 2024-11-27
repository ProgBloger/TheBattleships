using System.Drawing;

namespace TheBattleShips.Application.Entities
{
    public class ShipCell
    {
        public Ship _ship;
        private IOProcessor _iOProcessor;
        private Point _point;

        public bool IsHit { get; private set; } = false;

        public ShipCell(Point point, IOProcessor iOProcessor)
        {
            _point = point;
            _iOProcessor = iOProcessor;
        }

        public void Initialize(Ship ship)
        {
            _ship = ship;
        }

        public void Hit()
        {
            if(_ship == null)
            {
                throw new InvalidOperationException();
            }

            if (_ship.IsLastHit())
            {
                _iOProcessor.MessageSink(_ship.Name);
                IsHit = true;
            }
            else
            {
                if (IsHit)
                {
                    _iOProcessor.MessageHitAgain();
                }
                else
                {
                    _iOProcessor.MessageHit();
                    IsHit = true;
                }
            }
        }
    }
}
