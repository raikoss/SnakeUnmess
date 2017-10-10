using System;
using System.Diagnostics;
using System.Threading;

namespace CookieBakery {
	class Bakery {
		private int _cookiesToMake;
		private bool _finishedSelling;
		private int _numberOfCookies;
	    private int _soldCookies;

	    private readonly ICookie[] _cookies;
		private readonly Stopwatch _customerStopwatch;
		private readonly View _view;

		private const int CookieTimer = 667;
		private const int CustomerTimer = 1000;

		public Bakery(int cookiesToMake) {
			_cookiesToMake = cookiesToMake;
			_finishedSelling = false;
			_numberOfCookies = 0;
		    _soldCookies = 0;

            _cookies = new ICookie[cookiesToMake];
			_customerStopwatch = new Stopwatch();
			_view = new View();
		}

		//Opens the bakery. Makes as long as there are more cookies to make, 
		//and sells as long as there are cookies. 
		public void OpenBakery() {
			var bakeryWatch = new Stopwatch();
			bakeryWatch.Start();
			_customerStopwatch.Start();

			StartThreads();

			while (!_finishedSelling) {
				if (bakeryWatch.ElapsedMilliseconds > CookieTimer && _cookiesToMake > 0) {
					//making a cookie
				    _cookies[_numberOfCookies] = CookieFactory.CreateCookie();
                    _view.PrintMadeCookie(_cookies[_numberOfCookies]);
					_cookiesToMake--;
					_numberOfCookies++;
					bakeryWatch.Restart();
				}

				//all cookies been made and sold
				if (_soldCookies == _cookies.Length && _cookiesToMake == 0) {
					_finishedSelling = true;
				}
			}

			Console.ReadKey();
		}

		//The threads' method. Checks if there are still not sold cookies
		//and sells it to one thread if there are. 
		public void CheckCookies() {
		        while (!_finishedSelling) {
					lock (this) {
						if (_customerStopwatch.ElapsedMilliseconds > CustomerTimer) {
							SellCookie();
				    }
		        }
            }
		}
  
		//Sells the cookie to a thread
		private void SellCookie() {
			if (_soldCookies != _cookies.Length && _cookies.Length > 0) {
				_view.PrintSoldCookie(_cookies[_soldCookies], Thread.CurrentThread.Name);
				_soldCookies++;
				_customerStopwatch.Restart();
            }
		}

		//Starts the three customer threads.
		private void StartThreads() {
			var ted = new Thread(new ThreadStart(CheckCookies)) { Name = "Ted" };
			var fred = new Thread(new ThreadStart(CheckCookies)) { Name = "Fred" };
			var greg = new Thread(new ThreadStart(CheckCookies)) { Name = "Greg" };

			ted.Start();
			fred.Start();
			greg.Start();
		}
	}
}
