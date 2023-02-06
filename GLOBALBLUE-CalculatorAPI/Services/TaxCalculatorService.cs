using GLOBALBLUE_CalculatorAPI.Models;

namespace GLOBALBLUE_CalculatorAPI.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        public TaxCalculatorService()
        {

        }

        public async Task<TaxData?> CalculateFinalValues(TaxData taxData)
        {
            var finalData = new TaxData();

            // If all are empty or if more than one are filled
            if (!taxData.Net.HasValue && !taxData.Gross.HasValue && !taxData.Vat.HasValue ||
                    taxData.Net.HasValue && taxData.Gross.HasValue && !taxData.Vat.HasValue ||
                    taxData.Net.HasValue && !taxData.Gross.HasValue && taxData.Vat.HasValue ||
                    !taxData.Net.HasValue && taxData.Gross.HasValue && taxData.Vat.HasValue)
                return null;            

            if (taxData.Net.HasValue)
            {
                finalData.Net = taxData.Net;
                finalData.Gross = taxData.Net * 0.20m;
                finalData.Vat = finalData.Gross + taxData.Net;                
            }

            if (taxData.Gross.HasValue)
            {
                finalData.Gross = taxData.Gross;
                finalData.Net = taxData.Gross / 0.20m;
                finalData.Vat = finalData.Gross + finalData.Net;
            }

            if (taxData.Vat.HasValue)
            {
                finalData.Vat = taxData.Vat;
                finalData.Gross = taxData.Vat * 0.166667m;
                finalData.Net = finalData.Gross / 0.20m;
            }

            return finalData;
        }
    }
}
