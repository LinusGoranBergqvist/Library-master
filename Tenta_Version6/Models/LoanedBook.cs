namespace Tenta_Version6.Models
{
    public class LoanedBook
    {
        public int Id { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
