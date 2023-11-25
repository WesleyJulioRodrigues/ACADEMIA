namespace Academia.ViewModels;

public class UsuarioVM
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime? DataNascimento { get; set; }
    public string Foto { get; set; }
    public string Perfil { get; set; }
    public string TipoDev { get; set; }
    public string UsuarioId { get; internal set; }
}   
