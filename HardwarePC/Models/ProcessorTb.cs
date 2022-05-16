using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class ProcessorTb
    {
        [Key]
        public int IdProcessor { get; set; }
        public string ProcessorName { get; set; }
        public string ProcessorModel { get; set; }
        public int? ProcessorPrice{ get; set; }
        public virtual ICollection<PcTb> PcTbs { get; set; }
    }
}
