using Web_Api_Inm.Entities.LOGIN;

namespace Web_Api_Inm.Services.LOGIN
{
    public class UsuarioServices : IUsuarioServices
    {
        public async Task<Usuario> ReadUser(string user)
        {
            try
            {
                return await SeguridadDal.ReadUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ValidaUsuario(string user, string password)
        {
            try
            {
                return await SeguridadDal.ValidaUsuario(user, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ValidaPermiso(string user, string password)
        {
            try
            {
                return await SeguridadDal.ValidaPermiso(user, password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}