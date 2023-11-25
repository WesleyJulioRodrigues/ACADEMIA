using Academia.ViewModels;

namespace Academia.Services;

public interface IUsuarioService
{
    Task<UsuarioVM> GetUsuarioLogado();
}