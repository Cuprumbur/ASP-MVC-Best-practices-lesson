//using Microsoft.Analytics.Interfaces;
//using Microsoft.Analytics.Types.Sql;

namespace Store.Model.Models
{
    public class Gadget
    {
        public int GadgetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}