using Microsoft.AspNetCore.Mvc;
using MovieRank.Services.LowLevelModel;

namespace MovieRank.Controllers.LowLevelModel
{
    [Route("setup")]
    public class SetupController : Controller
    {
        private readonly ISetupService _setupService;

        public SetupController(ISetupService setupService)
        {
            _setupService = setupService;
        }

        [HttpPost]
        [Route("createTable/{dynamoDbTableName}")]
        public async Task<IActionResult> CreateDynamoDbTable(string dynamoDbTableName)
        {
            await _setupService.CreateDynamoDbTable(dynamoDbTableName);

            return Ok();
        }

        [HttpDelete]
        [Route("deleteTable/{dynamoDbTableName}")]
        public async Task<IActionResult> DeleteTable(string dynamoDbTableName)
        {
            await _setupService.DeleteDynamoDbTable(dynamoDbTableName);

            return Ok();
        }
    }
}
