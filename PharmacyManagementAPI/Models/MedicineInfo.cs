namespace PmsApi.Models
{
    public class MedicineInfo
    {
        public int Id { get; set; }
        public string? GenericName { get; set; }
        public string? Strength { get; set; }
        public string? Form { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? StorageLocation { get; set; }
        public int Qty { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
    }
}
