
namespace CookieBakery {
    class BrandDecorator : CookieDecorator {
        public BrandDecorator(ICookie original) : base(original){}
        public override string ToString()
        {
            return "Premium " + base.ToString();
        }
    }
}
