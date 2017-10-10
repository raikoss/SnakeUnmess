namespace SnakeUnMess.Models {
	class Point {
		public int X { get; set; }
		public int Y { get; set; }

		//Constructor with default values
		public Point() {
			X = 0;
			Y = 0;
		}

		//Constructor that takes another point as parameter, 
		//and gives a new one with same X and Y
		public Point(Point point) {
			X = point.X;
			Y = point.Y;
		}

		//Constructor that takes and x and y value and gives a point
		public Point(int x, int y) {
			X = x;
			Y = y;
		}

		public static bool operator ==(Point p1, Point p2) {
			return (p1.X == p2.X) && (p1.Y == p2.Y);
		}

		public static bool operator !=(Point p1, Point p2) {
			return !((p1.X == p2.X) && (p1.Y == p2.Y));
		}
	}
}
