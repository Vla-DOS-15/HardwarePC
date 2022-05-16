using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class RAMTb
    {
        [Key]
        public int IdRAM { get; set; }
        public int? AmountRAM { get; set; }
        public int? RAMPrice { get; set; }
        public virtual ICollection<PcTb> PcTbs { get; set; }
    }
}
