using System.ComponentModel.DataAnnotations;

namespace Dynamic_AGgrid.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Rollno { get; set; }

        public string? Section { get; set; }

        public string? Branch { get; set; }

        public long ContactNo { get; set; }

    }
}
