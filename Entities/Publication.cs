using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRApp.Entities;

public class Publication
{
    public Guid Id { get; set; }
    [StringLength(512)]
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
    public ChatUser User { get; set; }
}
