using Microsoft.AspNetCore.Mvc;
using CourtCase.Controllers;
using CourtCaseDomain;
using CourtCaseApplication.Employees;

namespace CourtCase.API
{
    public class EmployeeController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] RequestBody requestBody)
        {
            return HandleResult(await Mediator.Send(new Create.Command { EmployeeObj = (Employee)requestBody.Data, EmployeeId = requestBody.UserId }));
        }
    }
}
