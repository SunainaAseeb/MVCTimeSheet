using System;

namespace MVCTimeSheet.Models
{
    internal class IndexAttribute : Attribute
    {
        public bool IsUnique { get; set; }
    }
}