using System;

namespace PhoenixService.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
        public DateTime Expires { get; set; }
    }
}