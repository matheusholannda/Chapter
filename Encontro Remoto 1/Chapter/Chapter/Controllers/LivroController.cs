using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controllers
{
    [Produces("application/json")]//formato de reposta da api : json
    [Route("api/[controller]")]//rota para acesso do controller : api/livro
    [ApiController]//identificação que é uma classe controladora
    public class LivroController : ControllerBase//herança da classe ControllerBase
    {
        private readonly LivroRepository _livroRepository;//variável privada criada para armazenar os dados do repositório

        public LivroController(LivroRepository livroRepository)//injeção de dependência: o controller depende do repository
        {
            _livroRepository = livroRepository;//armazenamento das informações do repositório dentro da variável privada
        }

        [HttpGet]//verbo Get: de obter
        //IActionResult : https://learn.microsoft.com/pt-br/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0
        public IActionResult Listar()//nome do controller para listar os livros 
        {
            try//caso dê certo
            {
                return Ok(_livroRepository.Ler());//retorna um status code 200 e os itens da lista
            }
            catch (Exception e)//caso dê errado
            {
                throw new Exception(e.Message);//retorna uma mensagem de erro
            }
        } 
    }
}
