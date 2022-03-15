using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using UpStreamApi;

namespace NswagGeneration.AspNetCore
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AdvisersClient _advisersClient;
        public TestController(AdvisersClient advisersClient)
        {
            _advisersClient = advisersClient;
        }
        [HttpGet]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Test1()
        {
            return Ok();
        }

        [HttpGet]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        [ProducesResponseType(typeof(GetRecurringTransactionsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Test2(IList<string> accountKeys)
        {
            return Ok(await _advisersClient.RecurringTransactions_FindByAccountKeysAsync(accountKeys, 1, 20));
        }
    }
}
