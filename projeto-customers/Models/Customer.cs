using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace projeto_customers.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string NameCustomer { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string EmailCustomer { get; set; }
        [Required]
        public DateTime BirthdayCustomer { get; set; }
        [StringLength(15)]
        public string PhoneCustomer { get; set; }
        [Required]
        [StringLength(15)]
        public string CellPhoneCustomer { get; set; }
        [Required]
        [StringLength(250)]
        public string Address { get; set; }
        public int Status_Register { get; set; }

    }
}
