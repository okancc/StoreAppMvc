using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Models
{
    public class SessionsCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
            .HttpContext?.Session;

            SessionsCart cart = session?.GetJson<SessionsCart>("cart") ?? new SessionsCart();
            cart.Session = session;
            return cart;

        }
        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionsCart>("cart", this);
        }

        public override void Clear()
        {
              base.Clear();
              Session?.Remove("cart");
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson<SessionsCart>("cart",this);
        }

    }

}