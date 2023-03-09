using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ComputerModel: ItemModel
    {
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Producer { get; set; }
    }
}
