using UrunSatisPortali.Models;

namespace UrunSatiSPortali.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fiyat { get; set; }
        public bool IsActive { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
