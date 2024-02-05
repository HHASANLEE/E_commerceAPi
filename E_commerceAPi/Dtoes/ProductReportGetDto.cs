namespace E_commerceAPi.Dtoes
{
    public class ProductReportGetDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductDescription { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
