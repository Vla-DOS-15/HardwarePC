using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class PowerSupplyTb
    {
        [Key]
        public int IdPowerSupply { get; set; }
        public string PowerSupplyName { get; set; }
        public int? PowerSupplyPrice { get; set; }
        public virtual ICollection<PcTb> PcTbs { get; set; }
    }
}
