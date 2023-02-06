namespace GLOBALBLUE_CalculatorAPI.Models
{
    public class TaxData
    {
        public int Id { get; set; }
        public decimal? Net { get; set; }
        public decimal? Gross { get; set; }
        public decimal? Vat { get; set; }
    }
}
