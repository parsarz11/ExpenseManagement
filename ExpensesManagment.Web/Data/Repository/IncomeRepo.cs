using ExpensesManagment.Web.Data.Context;
using ExpensesManagment.Web.Data.Entities;

namespace ExpensesManagment.Web.Data.Repository
{
    public class IncomeRepo
    {
        private readonly DatabaseContext _databaseContext;
        public IncomeRepo(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddIncome(Income income)
        {
            var addIncome = _databaseContext.Incomes.Add(income);
            _databaseContext.SaveChanges();
        }

        public List<Income> GetAllIncomes() 
        {
            var GetIncome = _databaseContext.Incomes.ToList();
            return GetIncome;
        }

        public Income GetIncome(int id)
        {
            var Income = _databaseContext.Incomes.FirstOrDefault(x => x.Id == id);
            return Income;
        }
    }
}
