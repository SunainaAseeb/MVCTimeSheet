using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTimeSheet.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        //Employee Code will always be Unique;used as
        //foreign key in Timesheet data object
        [Index(IsUnique = true)]
        [StringLength(10)]
        [Required]
        public string Code { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

    }
}