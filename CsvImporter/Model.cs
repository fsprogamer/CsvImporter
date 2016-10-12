using System.ComponentModel.DataAnnotations;

namespace CsvImporter
{    
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(256)]
        [Required]
        [DataType(DataType.Text, ErrorMessage = "ФИО указано неверно.")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Дата рождения указана неверно.")]
        [Display(Name = "День рождения")]
        public string Birthday { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email указан неверно.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Телефон указан неверно.")]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }        
    }
}
