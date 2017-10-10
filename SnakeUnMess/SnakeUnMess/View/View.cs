using System;

namespace SnakeUnMess.View {
	class View {
		private readonly int _windowWidth;
		private readonly int _windowHeight;

		public View() {
			_windowWidth = Console.WindowWidth;
			_windowHeight = Console.WindowHeight;
			Console.CursorVisible = false;
		}

		public int GetWidth() {
			return _windowWidth;
		}

		public int GetHeight() {
			return _windowHeight;
		}

		public void UpdatePoint(Models.Point point, string pointType = "") {
			switch (pointType) {
				case "Tail":
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.SetCursorPosition(point.X, point.Y);
					Console.Write("0");
					break;
				case "Head":
					Console.SetCursorPosition(point.X, point.Y);
					Console.Write("@");
					break;
				case "Apple":
					Console.ForegroundColor = ConsoleColor.Green;
					Console.SetCursorPosition(point.X, point.Y);
					Console.Write("$");
					break;
				default:
					Console.SetCursorPosition(point.X, point.Y);
					Console.Write(" ");
					break;
			}
		} 
	}
}
