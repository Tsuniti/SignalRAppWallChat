using Microsoft.AspNetCore.SignalR;
using SignalRApp.Database;
using SignalRApp.Entities;
namespace SignalRApp;

public class ChatHub : Hub
{
    WallDB db = new WallDB();
    public async Task Send(ChatUser user, string message)
    {

            Publication publication = new Publication();
            publication.Message = message;
            publication.UserId = user.Id;
            publication.Date = DateTime.Now;
            db.AddPublication(publication);
            await this.Clients.All.SendAsync("Receive", user.Username, message, publication.Date);

    }

    public async Task<List<Publication>> ReceiveAll()
    {
        //foreach(var item in db.GetAllPublications())
        //{
        //    await this.Clients.Caller.SendAsync("Receive", db.GetUserById(item.UserId).Username, item.Message, item.Date);
        //}
        return db.GetAllPublications().ToList();
    }
    public async Task<string> ReceiveUsernameById(Guid id)
    {
        return db.GetUserById(id).Username;
    }
    public async Task<bool> CheckIsUsernameAvailable(string username) => db.GetAllUsers().Any(u => u.Username == username);

    public async Task RegisterNewUser(string username, string password)
    {
        ChatUser chatUser = new ChatUser();
        chatUser.Username = username;
        chatUser.Password = password;
        db.AddUser(chatUser);
    }

    public async Task<ChatUser> LogIn(string username, string password)
    {
        ChatUser user = db.GetUserByUsername(username);
        
        return user;
    }
}