namespace Joshua_POE_CLDV.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string SessionId { get; set; }
        public Product Product { get; set; }
    }
}
