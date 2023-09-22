using Web_Api_Inm.Entities.LOGIN;

namespace Web_Api_Inm.Services.LOGIN
{
    public interface IUsuarioServices
    {
        public Task<Usuario> ReadUser(string user);
        public Task<bool> ValidaUsuario(string user, string password);
        public Task<bool> ValidaPermiso(string user, string proceso);
    }

}
