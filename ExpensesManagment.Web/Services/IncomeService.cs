using ExpensesManagment.Web.Data.Repository;
using ExpensesManagment.Web.Models;

namespace ExpensesManagment.Web.Services
{
    public class IncomeService
    {
        
        private readonly IncomeRepo _incomeRepo;

        public IncomeService( IncomeRepo incomeRepo)
        {
            _incomeRepo = incomeRepo;
        }

        public List<DisplayIncomeModel> IncomeDisplay()
        {
            var incomes = _incomeRepo.GetAllIncomes();
            

            var IncomeDisplay = incomes.Select(x =>
            {
                var displayModel = new DisplayIncomeModel
                {
                    id = x.Id,
                    Source = x.Source,
                    IncomeMoney = x.IncomeMoney,
                };
                return displayModel;
            }).ToList();
            return IncomeDisplay;
        }


        public int Incomes(string Type)
        {
            if(Type == "Monthly")
            {
                int MonthlyIncome = _incomeRepo.GetAllIncomes().Sum(x => x.IncomeMoney);
                return MonthlyIncome;
            }
            else
            {
                int AnnualIncome = _incomeRepo.GetAllIncomes().Sum(x => x.IncomeMoney) * 12;
                return AnnualIncome;
            }
        }
    }
}
