using CourtCase.Controllers;
using CourtCaseApplication.Case;
using CourtCaseDomain;
using Microsoft.AspNetCore.Mvc;

namespace CourtCase.API
{
    public class CaseController : BaseApiController
    {
        [HttpGet] 
        public async Task<IActionResult> GetCases([FromQuery] CaseFilterParams caseFilterParams)
        {
            return HandleResult(await Mediator.Send(new List.Query { CaseFilterParams = caseFilterParams }));
        }

        [HttpGet()]
        public async Task<IActionResult> GetCase([FromQuery] CaseCompositeKeyParams caseParams)
        {
            return HandleResult(await Mediator.Send(new Details.Query { CaseParams = caseParams }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCase([FromBody] RequestBody requestBody)
        {
            return HandleResult(await Mediator.Send(new Create.Command { CourtCase = (Case)requestBody.Data }));
        }

        [HttpPut]
        public async Task<IActionResult> EditCase([FromBody] RequestBody requestBody)
        {
            return HandleResult(await Mediator.Send(new Edit.Command { CourtCase = (Case)requestBody.Data }));
        }

        
    }
}
