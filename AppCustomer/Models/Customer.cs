using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppCustomer.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage = "Digite o nome completo")]
        public string NameCustomer { get; set; }
        [Required(ErrorMessage = "Digite o email")]
        [StringLength(100)]
        [EmailAddress]
        public string EmailCustomer { get; set; }
        [Required(ErrorMessage = "Digite a data de nascimento")]
        public DateTime BirthdayCustomer { get; set; }
        [Required(ErrorMessage = "Digite o telefone fixo")]
        [StringLength(15)]
        public string PhoneCustomer { get; set; }
        [Required(ErrorMessage = "Digite o celular")]
        [StringLength(15)]
        public string CellPhoneCustomer { get; set; }
        [Required(ErrorMessage = "Digite o endereço")]
        [StringLength(250)]
        public string Address { get; set; }
        public int Status_Register { get; set; }
    }
}
