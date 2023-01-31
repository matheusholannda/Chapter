﻿using Chapter.Interfaces;
using Chapter.Models;
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
        private readonly ILivroRepository _iLivroRepository;//variável privada criada para armazenar os dados do repositório

        public LivroController(LivroRepository iLivroRepository)//injeção de dependência: o controller depende do repository
        {
            _iLivroRepository = iLivroRepository;//armazenamento das informações do repositório dentro da variável privada
        }

        //IActionResult : https://learn.microsoft.com/pt-br/aspnet/core/web-api/action-return-types?view=aspnetcore-7.0

        /// <summary>
        /// método que controla acesso para listagem de livros
        /// </summary>
        /// <returns>status code ok e a lista de livros</returns>
        /// <exception cref="Exception">mensagem de erro</exception>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iLivroRepository.Ler());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// método que controla o acesso para busca de um livro por Id
        /// </summary>
        /// <param name="id">id do livro a ser buscado</param>
        /// <returns>status code Ok e livro buscado</returns>
        /// <exception cref="Exception">mensagem de erro</exception>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// método que controla o acesso para cadastro de livros
        /// </summary>
        /// <param name="livro">objeto a ser cadastrado</param>
        /// <returns>status code Ok</returns>
        /// <exception cref="Exception">mensagem de erro</exception>
        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _iLivroRepository.Cadastrar(livro);
                return Ok(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// método que controla o acesso para edição de um livro
        /// </summary>
        /// <param name="id">id do livro a ser atualizado</param>
        /// <param name="livro">objeto a ser atualizado</param>
        /// <returns>status code 204</returns>
        /// <exception cref="Exception">mensagem de erro</exception>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livro)
        {
            try
            {
                _iLivroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// método que controla o acesso para exclusão de um livro
        /// </summary>
        /// <param name="id">id do livro a ser excluído</param>
        /// <returns>status code 204</returns>
        /// <exception cref="Exception">mensagem de erro</exception>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _iLivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
