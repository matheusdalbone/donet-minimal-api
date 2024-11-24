using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Dominio.Interfaces
{
    public interface iVeiculoServico
    {
        List<Veiculo> Todos(int pagina, string nome = null, string marca = null);
        Veiculo BuscarPorId(int id);
        Veiculo Incluir(Veiculo veiculo);
        Veiculo Atualizar(Veiculo veiculo);
        void Apagar(Veiculo veiculo);
    }
}
