using System;
using System.Threading;

namespace CookieBakery {
	class Cookie : ICookie
	{
	    private readonly Enum _type;
        private static int _instanceCount;
	    private readonly int _cookieNumber;
        private enum CookieType{Chocolate,Vanilla,Strawberry};
		public Cookie(int typeValue)
		{
		    _type = (CookieType)typeValue;
		    _instanceCount++;
		    _cookieNumber = _instanceCount;
		}

	    public int CookieNumber()
	    {
	        return _cookieNumber;
	    }

		public override string ToString()
		{
		    return "Cookie number " + _cookieNumber + " with " + _type;
		}
	}
}
