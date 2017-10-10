using System;

namespace SnakeUnMess.Models {

	enum AvailableKeys {
		Up, 
		Right, 
		Down, 
		Left, 
		Escape, 
		Spacebar, 
		Other
	}

	
	static class Input {
		//Takes a key as input and returns what key was pressed as an enum.
		public static AvailableKeys HandleKey(ConsoleKeyInfo cki) {
			string keyString = cki.Key.ToString();
			switch (keyString) {
				case "UpArrow": 
					return AvailableKeys.Up;
				case "RightArrow":
					return AvailableKeys.Right;
				case "DownArrow":
					return AvailableKeys.Down;
				case "LeftArrow":
					return AvailableKeys.Left;
				case "Spacebar":
					return AvailableKeys.Spacebar;
				case "Escape":
					return AvailableKeys.Escape;
				default:
					return AvailableKeys.Other;
			}
		}
	}
}
