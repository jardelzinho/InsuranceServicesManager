
namespace PaymentService
{
    public class AppSettings
    {
        public string[] AllowedChatOrigins { get; set; }
    }

    public class RabbitMQSettings
    {
        public string User { get; set; }
        public string Pwd { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
    }
}
