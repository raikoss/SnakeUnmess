using System.Collections.Generic;
using System.Linq;

namespace SnakeUnMess.Models
{
	enum Directions {
		Up, 
		Right, 
		Down, 
		Left
	}

	class Snake : List<Point> {
		private Directions _direction;

		public Snake(Point spawn) {
			for (int i = 0; i < 4; i++) {
				Add(spawn);
			}

			_direction = Directions.Down;
		}

		public void ExtendSnake() {
			Add(new Point(this.Last()));
		}

		public void SwitchDirection(Directions newDirection) {
			if (newDirection == Directions.Up && _direction != Directions.Down) {
				_direction = newDirection;
			} else if (newDirection == Directions.Right && _direction != Directions.Left) {
				_direction = newDirection;
			} else if (newDirection == Directions.Down && _direction != Directions.Up) {
				_direction = newDirection;
			} else if (newDirection == Directions.Left && _direction != Directions.Right) {
				_direction = newDirection;
			}
		}

		public Directions GetDirection() {
			return _direction;
		}
	}
}