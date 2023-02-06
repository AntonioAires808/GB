using GLOBALBLUE_CalculatorAPI.Models;

namespace GLOBALBLUE_CalculatorAPI.Services
{
    public interface ITaxCalculatorService
    {
        Task<TaxData> CalculateFinalValues(TaxData taxData);
    }
}
