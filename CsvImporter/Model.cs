using System.ComponentModel.DataAnnotations;

namespace CsvImporter
{
    public class Person
    {
        //public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        public string Birthday { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        public int Phone { get; set; }        
    }
}
