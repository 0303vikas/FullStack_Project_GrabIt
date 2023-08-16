namespace GrabIt.Service.Dtos
{
    public class PaymentReadDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }

    public class PaymentCreateDto
    {
        public Guid OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }

    public class PaymentUpdateDto
    {
        public string PaymentMethod { get; set; }
        public string Transection_id { get; set; }
    }
}