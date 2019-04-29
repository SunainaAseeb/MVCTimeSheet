using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTimeSheet.Models
{
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

    }
}