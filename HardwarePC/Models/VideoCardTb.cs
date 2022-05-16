using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class VideoCardTb
    {
        [Key]
        public int IdVideoCard { get; set; }
        public string VideoCardName { get; set; }
        public int? VideoCardPrice { get; set; }
        public virtual ICollection<PcTb> PcTbs { get; set; }
    }
}
