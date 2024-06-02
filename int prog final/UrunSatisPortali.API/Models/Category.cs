using Microsoft.AspNetCore.Http.HttpResults;
using UrunSatiSPortali.Models;

namespace UrunSatisPortali.Models

{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<Urun> Urun { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
