namespace SnakeUnMess.Models {
	static class PointFactory {
		public static Point Create(int x, int y) {
			return new Point(x, y);
		}

		public static Point Create(Point existingPoint) {
			return new Point(existingPoint.X, existingPoint.Y);
		}
	}
}
