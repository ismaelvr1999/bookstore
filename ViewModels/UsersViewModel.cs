using bookstore.Models;
using System.Collections.Generic;
namespace bookstore.ViewModels;

public class UsersViewModel
{
    public IList<User> Users { get; set; } = default!;
    public User User { get; set; } = default!;
}