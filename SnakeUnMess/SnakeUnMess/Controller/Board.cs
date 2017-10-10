using System;
using System.Linq;
using System.Diagnostics;
using SnakeUnMess.Models;

namespace SnakeUnMess.Controller {
	class Board {
		private bool _gameFinished;
		private bool _pause;
		private int _maxWidth;
		private int _maxHeight;

		private readonly Snake _snake;
		private Point _apple;
		private readonly View.View _view;
		
		private const int GameSpeed = 100;

		public Board() {
			_gameFinished = false;
			_pause = false;
			_snake = new Snake(PointFactory.Create(10, 10));
			_view = new View.View();
		}

		//Main game loop
		public void Start() {
			SpawnApple();
			_view.UpdatePoint(_apple, "Apple");
			SetGameDimensions(_view.GetWidth(), _view.GetHeight());

			var stopwatch = new Stopwatch();
			stopwatch.Start();

			while (!_gameFinished) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					OnKeyDown(cki);
				}
				
				if (_pause == false) {
					if (stopwatch.ElapsedMilliseconds < GameSpeed) {
						continue;
					}

					Tick();
					stopwatch.Restart();
				}
			}
		}

		//Makes sure a key does it's respective action. 
		//The snake can not switch directions while the game is paused.
		private void OnKeyDown(ConsoleKeyInfo cki) {
			var keyPressed = Input.HandleKey(cki);

			switch (keyPressed) {
				case AvailableKeys.Escape:
					_gameFinished = true;
					break;
				case AvailableKeys.Spacebar:
					if (_pause == false) {
						_pause = true;
					} else {
						_pause = false;
					}
					break;
				default: 
					if (!_pause) {
						switch (keyPressed) {
							case AvailableKeys.Up:
								_snake.SwitchDirection(Directions.Up);
								break;
							case AvailableKeys.Right:
								_snake.SwitchDirection(Directions.Right);
								break;
							case AvailableKeys.Down:
								_snake.SwitchDirection(Directions.Down);
								break;
							case AvailableKeys.Left:
								_snake.SwitchDirection(Directions.Left);
								break;
						}
					}
					break; //out of outer switch
			}
		}

		//Does actions when the timer has passed a certain tick-timer.
		//Switches snake direction, checks collision, and updates snake
		//and GUI according to what happens. 
		private void Tick() {
			var newHead = PointFactory.Create(_snake.Last());
			var tailToClear = PointFactory.Create(_snake.First());
			var snakeDirection = _snake.GetDirection();

			switch (snakeDirection) {
				case Directions.Up:
					newHead.Y -= 1;
					break;
				case Directions.Right:
					newHead.X += 1;
					break;
				case Directions.Down:
					newHead.Y += 1;
					break;
				case Directions.Left:
					newHead.X -= 1;
					break;
			}

			CheckCollision(newHead);

			//clears tail
			_snake.RemoveAt(0);
			_view.UpdatePoint(tailToClear);

			//prints tail
			foreach (Point part in _snake) {
				_view.UpdatePoint(part, "Tail");
			}
			
			//prints new head
			_snake.Add(newHead);
			_view.UpdatePoint(_snake.Last(), "Head");
		}

		//Spawns an apple on the board and displays it
		private void SpawnApple() {
			var random = new Random();
			var appleOnSnake = false;

			while (!appleOnSnake) {
				appleOnSnake = true;
				int x = random.Next(_view.GetWidth());
				int y = random.Next(_view.GetHeight());
				_apple = PointFactory.Create(x, y);

				foreach (var p in _snake) {
					if (p == _apple) {
						appleOnSnake = false;
					}
				}
			}
		}

		//Checks if a point is colliding with the screen borders, the apple, or itself.
		private void CheckCollision(Point head) {
			if (head.X <= 0 || head.X >= _maxWidth - 1 ||
				head.Y <= 0 || head.Y >= _maxHeight) {
				_gameFinished = true;
			} else if (head == _apple) {
				SpawnApple();
				_snake.ExtendSnake();
				_view.UpdatePoint(_apple, "Apple");
			} else {
				foreach (var p in _snake) {
					if (head == p) {
						_gameFinished = true;
					}
				}
			}
		}

		//Sets the boundaries for the snake playground.
		private void SetGameDimensions(int width, int height) {
			_maxWidth = width;
			_maxHeight = height;
		}
	}
}