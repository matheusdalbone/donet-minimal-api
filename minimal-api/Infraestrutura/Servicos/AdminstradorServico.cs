using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.DB;

namespace minimal_api.Infraestrutura.Servicos
{
    public class AdminstradorServico : iAdminstradorServico
    {
        private readonly DbContexto _contexto;

        public AdminstradorServico(DbContexto contexto) 
        {
            _contexto = contexto;
        }

        public Administrador Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).SingleOrDefault();

            return adm;
        }
    }
}
