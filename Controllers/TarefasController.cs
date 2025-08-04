using Microsoft.AspNetCore.Mvc;
using sistemaDeTarefasT2m.DTO;
using sistemaDeTarefasT2m.Entity;
using sistemaDeTarefasT2m.IService;

namespace sistemaDeTarefasT2m.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

         private readonly ITarefasService _tarefaService;
         public TarefasController(ITarefasService tarefaService)
         {
             _tarefaService = tarefaService;
         }
         [HttpGet]
         public async Task<ActionResult<IEnumerable<TarefasDto>>> GetAllTarefas()
         {
             try
             {
                 var tarefas = await _tarefaService.GetAllTarefasByUserId();
                 return Ok(tarefas);
             }
            catch (Exception ex)
             {
                 return StatusCode(500, $"Internal server error: {ex.Message}");
             }
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Tarefas>>>AddTarefaAsync([FromBody] CreateTarefaDto tarefa)
        {
            try
            {
                await _tarefaService.AddTarefaAsync(tarefa);
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
