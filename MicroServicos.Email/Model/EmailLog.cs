using MicroServicos.Email.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServicos.Email.Model
{
    [Table("EmailLog")]
    public class EmailLog: BaseEntity
    {
        public string Email { get; set; }
        public string Log { get; set; }
        public DateTime SentDate { get; set; }
    }
}
