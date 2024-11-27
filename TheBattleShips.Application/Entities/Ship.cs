namespace TheBattleShips.Application.Entities
{
    public class Ship
    {
        List<ShipCell> _shipCellList = new List<ShipCell>();

        public string Name { get; private set; }

        public Ship(List<ShipCell> shipCellList, string name)
        {
            {
                _shipCellList = shipCellList;
                Name = name;

                foreach (ShipCell cell in _shipCellList)
                {
                    cell.Initialize(this);
                }
            }
        }

        public bool IsLastHit()
        {
            return _shipCellList.Where(it => !it.IsHit).Count() == 1;
        }
    }
}
