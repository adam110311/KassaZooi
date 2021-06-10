using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCashRegister.Domain.Models
{
    public class Product
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductCategorie Order { get; set; }
        public string Verkoopprijs { get; set; }
        public string Beschrijving { get; set; }
        public decimal Stuksprijs { get; set; }
        public bool IsActief { get; set; }

    }
}
