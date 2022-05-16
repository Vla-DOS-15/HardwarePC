using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Models
{
    public class PcTb
    {
        [Key]
        public int Id { get; set; }
        public int? ProcessorId { get; set; }
        [ForeignKey("ProcessorId")]
        public ProcessorTb ProcessorTb { get; set; }
        public int? MotherboardId { get; set; }
        [ForeignKey("MotherboardId")]
        public MotherboardTb MotherboardTb { get; set; }
        public int? RAMId { get; set; }
        [ForeignKey("RAMId")]
        public RAMTb RAMTb { get; set; }
        public int? VideoCardId { get; set; }
        [ForeignKey("VideoCardId")]
        public VideoCardTb VideoCardTb { get; set; }
        public int? HardDriveId { get; set; }
        [ForeignKey("HardDriveId")]
        public HardDriveTb HardDriveTb { get; set; }
        public int? PowerSupplyId { get; set; }
        [ForeignKey("PowerSupplyId")]
        public PowerSupplyTb PowerSupplyTb { get; set; }
        public int? Price { get; set; }
        public bool? SuitableSurfing { get; set; }
        public bool? SuitableWorkingTextEd { get; set; }
        public bool? SuitableComputerGames { get; set; }

    }
}
