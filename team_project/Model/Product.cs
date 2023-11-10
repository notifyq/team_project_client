using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_project.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? ProductPublisher { get; set; }
        public int? ProductDeveloper { get; set; }
        public int? ProductStatus { get; set; }
    }
}
