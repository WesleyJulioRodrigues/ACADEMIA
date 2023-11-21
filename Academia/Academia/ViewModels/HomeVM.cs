using Academia.Models;

namespace Academia.ViewModels;

public class HomeVM
{
    public List<Exercicio> Exercicios { get; set; }
    public List<Professor> Professores { get; set; }
    public List<Comida> Comidas { get; set; }

}
