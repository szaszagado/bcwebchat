using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace probagetrequest.Models
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int Id { get; set; }
        public string Timestamp { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
    }

}