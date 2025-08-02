using HamburgueriaAPI.Models;

namespace HamburgueriaAPI.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BdHamburgueriaContext _context = new BdHamburgueriaContext();

        public void salvar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges(); 
        }
        public List<Pessoa> lista()
        {
            return _context.Pessoas.ToList();
        }

    }
}
