using System.Drawing;

namespace ExpensesManagment.Web.Models
{
    public class DisplayExpenseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
        public string CategoryColor { get; set; }
    }
}
