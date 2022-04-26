using System;
using System.ComponentModel.DataAnnotations;

namespace HoursWorkedAPI.ViewModels
{
    public class WorkReportViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string Note { get; set; }

        [Required]
        public int NumberOfHours { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}