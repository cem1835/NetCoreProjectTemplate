using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Extensions.MQ
{
    public class MessageRequest : MessageCommand
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Hash { get; set; }

        public MessageRequest(int id, string value, string hash)
        {
            this.Id = id;
            this.Value = value;
            this.Hash = hash;
        }
    }

    public class MessageResponse : MessageCommand
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Hash { get; set; }

        public MessageResponse(int status, string message, string hash)
        {
            this.Status = status;
            this.Message = message;
            this.Hash = hash;
        }
    }

    public interface MessageCommand
    {

    }
}
