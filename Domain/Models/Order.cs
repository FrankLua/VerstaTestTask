using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Город отправителя")]
        public string SenderCity { get; set; }
        [Required]
        [DisplayName("Адресс отправителя")]
        public string SenderAddress { get; set; }
        [Required]
        [DisplayName("Город Получателя")]
        public string RecipientCity { get; set; }
        [Required]
        [DisplayName("Адресс получателя")]
        public string RecipientAddress { get; set; }
        [Required]
        [DisplayName("Вес")]
        public double Weight { get; set; }
        [Required]
        [DisplayName("Дата забора")]
        public DateTime Date { get; set; }

    }
}
