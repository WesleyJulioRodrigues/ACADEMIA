using Academia.ViewModels;

namespace ImobiliariaGallo.Services;

public interface IUsuarioService
{
    Task<UsuarioVM> GetUsuarioLogado();
}