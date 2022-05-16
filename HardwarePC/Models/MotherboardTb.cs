using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class MotherboardTb
    {
        [Key]
        public int IdMotherboard { get; set; }
        public string MotherboardName { get; set; }
        public int? MotherboardPrice { get; set; }
        public virtual ICollection<PcTb> PcTbs { get; set; }
    }
}
