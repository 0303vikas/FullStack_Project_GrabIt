namespace GrabIt.Service.Dtos
{
    public class PaymentReadDto
    {
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }

    public class PaymentCreateDto
    {
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }

    public class PaymentUpdateDto
    {
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }
}