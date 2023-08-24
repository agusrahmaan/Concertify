namespace Backend.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public Account Nama { get; set; }
        public Concert Concert { get; set; }
        public int Qty { get; set; }

    }
}
