namespace ExpensesManagment.Web.Data.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoryFK { get; set; }
    }
}
