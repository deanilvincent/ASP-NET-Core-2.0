using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTest.Models
{
    public class TestDetails
    {
        [Key]
        public int TestId { get; set; }

        public bool Status { get; set; }
    }
}
