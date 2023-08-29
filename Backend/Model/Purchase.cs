namespace Backend.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public Account Account { get; set; }
        public string Phone { get; set; }
        public Concert Concert { get; set; }
        public int Qty { get; set; }

    }
}
