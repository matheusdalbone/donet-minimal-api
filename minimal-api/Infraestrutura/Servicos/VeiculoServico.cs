using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using minimal_api.Infraestrutura.DB;

namespace minimal_api.Infraestrutura.Servicos
{
    public class VeiculoServico : iVeiculoServico
    {
        private readonly DbContexto _contexto;

        public VeiculoServico(DbContexto contexto) 
        {
            _contexto = contexto;
        }

        public void Apagar(Veiculo veiculo)
        {
            _contexto.Veiculos.Remove(veiculo!);
            _contexto.SaveChanges();
        }

        public Veiculo Atualizar(Veiculo veiculo)
        {
            _contexto.Veiculos.Update(veiculo);
            _contexto.SaveChanges();

            return veiculo;
        }

        public Veiculo BuscarPorId(int id)
        {
            return _contexto.Veiculos.Where(v => v.Id == id).FirstOrDefault()!;
        }

        public Veiculo Incluir(Veiculo veiculo)
        {
            _contexto.Add(veiculo);
            _contexto.SaveChanges();

            return veiculo;
        }

        public List<Veiculo> Todos(int pagina, string nome = null, string marca = null)
        {
            var query = _contexto.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                var listaVeiculos = query.Where(v => v.Nome.ToLower().Contains(nome));

                return listaVeiculos.ToList();
            }

            int itensPorPagina = 8;

            query = query.Skip((pagina - 1) * itensPorPagina).Take(itensPorPagina);

            return query.ToList();
        }
    }
}
