using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursWorkedAPI.DBData.DTOModels
{
    public class WorkReportDTO
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserDTO User{ get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public int NumberOfHours { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
