using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/encomenda")]
public class BuscarEncomendaController : ControllerBase
{
    // Endpoint /api/encomenda/{codigo}
    [HttpGet("{codEncomenda}")]
    public IActionResult BuscarPorCodigo(string codEncomenda)
    {
        // Inicialização da classe Correios apra rastreamento dos pacotes.
        var rastreadorPacotes = new Correios.Pacotes.Services.Rastreador();
        var encomendaRastreada = rastreadorPacotes.ObterPacote(codEncomenda);

        // Verifica se a encomenda foi encontrada no sistema dos Correios. Se não for encontrada, retorna um erro status 404.
        if (encomendaRastreada == null)
            return BadRequest("Não foi possivel localizar essa encomenda! :(");

        // Verifica se a encomenda já foi entregue. Se sim, retorna um erro 409 indicando que a encomenda já foi entregue. 
        if (encomendaRastreada.Entregue)
            return Conflict("Essa encomenda já foi entregue :)");

        // Se a encomenda foi encontrada e Não foi entregue, retorna o status mais recente da encomenda com o código 200.\
        return Ok(encomendaRastreada.Historico[0]);
    }
}