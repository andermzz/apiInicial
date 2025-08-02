using HamburgueriaAPI.Models;

namespace HamburgueriaAPI.Repository
{
    public interface IPessoaRepository
    {
        void salvar(Pessoa pessoa);
        List<Pessoa> lista();  
        
    }
}
