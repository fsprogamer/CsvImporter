using System;
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
        public DateTime Birthday { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email указан неверно.")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Неправильный формат eMail")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Номер телефона указан неверно.")]
        [RegularExpression(@"^[0-9]{0,11}$", ErrorMessage = "Номер телефона должен содержать только цифры.")]
        [Display(Name = "Телефон")]        
        public string Phone { get; set; }        
    }   
}
