using System;

namespace CookieBakery {
	static class CookieFactory {
        static readonly Random Rnd = new Random();
		public static ICookie CreateCookie() {
			var cookie = new Cookie(Rnd.Next(3));

		    var i = Rnd.Next(2);

		    if (i == 0)
		    {
		        return cookie;
		    }
		        return new BrandDecorator(cookie);    
		}
	}
}
