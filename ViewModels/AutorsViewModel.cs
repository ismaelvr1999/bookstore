using bookstore.Models;
using System.Collections.Generic;
namespace bookstore.ViewModels;

public class AutorsViewModel
{
    public IList<Autor> Autors { get; set; } = default!;
    public Autor Autor { get; set; } = default!;
}