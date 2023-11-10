using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace team_project.Model
{
    public class Library
    {
            public int libraryId { get; set; }
            public int productId { get; set; }
            public int userId { get; set; }
            public DateTime purchaseDate { get; set; }
            public int libraryStatus { get; set; }
            public Product product { get; set; }
    }
}
