using HamburgueriaAPI.Models;
using HamburgueriaAPI.Repository;
using HamburgueriaAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HamburgueriaAPI.Controllers
{
    [ApiController]
    [Route("/hamburgueria/pessoa")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _essoaRepository;

        public PessoaController(IPessoaRepository essoaRepository)
        {
            _essoaRepository = essoaRepository;
        }

        [HttpPost]
        public IActionResult salvar(PessoaViewModel pessoaView)
        {
            var pessoa = new Pessoa(pessoaView);
            _essoaRepository.salvar(pessoa);
             return Ok();
        }

        [HttpGet]
        public IActionResult lista()
        {
            var pessoa = _essoaRepository.lista();
            return Ok(pessoa);
        }
    }
}
