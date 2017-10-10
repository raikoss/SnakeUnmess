
namespace CookieBakery {
    abstract class CookieDecorator : ICookie
    {
        private readonly ICookie _original;
        protected CookieDecorator(ICookie original)
        {
            _original = original;

        }

        public virtual int CookieNumber()
        {
            return _original.CookieNumber();
        }

        public override string ToString()
        {
            return _original.ToString();
        }
    }
}
