using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Город отправителя")]
        public int SenderCityId { get; set; }
        [Required]
        [DisplayName("Адресс отправителя")]
        public string AddressSender { get; set; }
        [Required]
        [DisplayName("Город Получателя")]
        public int RecipientCityId { get; set; }
        [Required]
        [DisplayName("Адресс получателя")]
        public string AddressRecipient { get; set; }
        [Required]
        [DisplayName("Вес")]
        public double Weight { get; set; }
        [Required]
        [DisplayName("Дата забора")]
        public DateTime Data { get; set; }

    }
}
