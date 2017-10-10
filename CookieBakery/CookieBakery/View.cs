using System;

namespace CookieBakery {
	class View {
		public void PrintSoldCookie(ICookie cookie, string customerName) {
			Console.WriteLine("\t\t\t\t\t\t\t{0} sold to: {1}", cookie, customerName);
		}

		public void PrintMadeCookie(ICookie cookie) {
			Console.WriteLine("{0} just finished!", cookie);
		}
	}
}
