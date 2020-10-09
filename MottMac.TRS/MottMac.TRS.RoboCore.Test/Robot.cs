namespace MottMac.TRS.RoboCore.Test
{
    public class Robot
    {
        private int? _positionX;
        private int? _positionY;
        private Direction? _currentDirection;

        public bool IsPlacedInBoard => _positionX != null && _positionY != null && _currentDirection != null;

        public Robot()
        {
            _positionX = null;
            _positionY = null;
            _currentDirection = null;
        }
    
        public bool Place(int x, int y, Direction direction)
        {
            if (!IsValidBoardPosition(x,y))
                return false;

            _positionX = x;
            _positionY = y;
            _currentDirection = direction;
            return true;
        }

        public bool Move()
        {
            if (!IsPlacedInBoard)
                return false;

            if (_currentDirection == Direction.North && IsValidBoardPosition(_positionX, _positionY + 1))
            {
                _positionY = _positionY + 1;
                return true;
            }

            if (_currentDirection == Direction.South && IsValidBoardPosition(_positionX, _positionY - 1))
            {
                _positionY = _positionY - 1;
                return true;
            }

            if (_currentDirection == Direction.East && IsValidBoardPosition(_positionX + 1, _positionY))
            {
                _positionX = _positionX + 1;
                return true;
            }

            if (_currentDirection == Direction.West && IsValidBoardPosition(_positionX -1, _positionY))
            {
                _positionX = _positionX -1;
                return true;
            }

            return false;
        }

        public void ChangeDirection(DirectionChange directionChange)
        {
            if (!IsPlacedInBoard)
                return;

            if (directionChange == DirectionChange.Right)
            {
                switch (_currentDirection)
                {
                    case Direction.North:
                        _currentDirection = Direction.East;
                        break;
                    case Direction.East:
                        _currentDirection = Direction.South;
                        break;
                    case Direction.South:
                        _currentDirection = Direction.West;
                        break;
                    case Direction.West:
                        _currentDirection = Direction.North;
                        break;
                }
                
            }
            if (directionChange == DirectionChange.Left)
            {
                switch (_currentDirection)
                {
                    case Direction.North:
                        _currentDirection = Direction.West;
                        break;
                    case Direction.West:
                        _currentDirection = Direction.South;
                        break;
                    case Direction.South:
                        _currentDirection = Direction.East;
                        break;
                    case Direction.East:
                        _currentDirection = Direction.North;
                        break;
                }
            }
        }

        private bool IsValidBoardPosition(int? x, int? y)
        {
            if (x == null || y == null)
                return false;

            if (x < 0 || x > 4 || y < 0 || y > 4)
                return false;

            return true;
        }
    }
}