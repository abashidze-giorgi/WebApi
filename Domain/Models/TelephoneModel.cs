using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TelephoneModel: ItemModel
    {
        public string Display { get; set; }
        public string Battery { get; set; }
        public string Model { get; set; }
    }
}
