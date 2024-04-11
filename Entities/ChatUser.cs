using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace SignalRApp.Entities;

[Index(nameof(Username), IsUnique = true)]
public class ChatUser
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [StringLength(16, MinimumLength = 3)]
    public string Username { get; set; }

    [StringLength(32, MinimumLength = 4)]
    public string Password { get; set; }

    public List<Publication> Publications { get; set; } = new List<Publication>();
    

}
