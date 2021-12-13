using CoreLibrary;
using CoreLibrary.Data;
using CoreLibrary.DataTransfer;
using GameCollection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameCollectionApi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IRepository<GameModel> _gameRepository;
        public GamesController(IRepository<GameModel> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var models = await _gameRepository.GetAllAsync();
            var response = models.Select(a => new GameViewModel(a)).ToModelResponse();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame(string id)
        {
            var model = await _gameRepository.GetAsync(id);
            if (model is null)
                return Ok(new ModelResponse<GameViewModel>
                {
                    Success = false
                });
            GameViewModel vm = model;
            return Ok(vm.ToModelResponse());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ModelRequest<GameViewModel> gameModel)
        {
            await _gameRepository.AddAsync(gameModel.Model);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] ModelRequest<GameViewModel> gameModel)
        {
            await _gameRepository.UpdateAsync(gameModel.Model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _gameRepository.DeleteAsync(id);
            return Ok();
        }
    }
}