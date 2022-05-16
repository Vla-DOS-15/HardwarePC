using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class HardDriveTb
    {
        [Key]
        public int IdHardDrive { get; set; }
        public string HardDriveName { get; set; }
        public int? HardDrivePrice { get; set; }
        public virtual ICollection<PcTb> PcTbs { get; set; }
    }
}
