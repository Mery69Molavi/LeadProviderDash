using LeadProviderDash.Server.Models;
using LeadProviderDash.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeadProviderDash.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeadProviderController : ControllerBase
    {

        private readonly ILogger<LeadProviderController> _logger;
        private readonly ILeadService _leadService;

        public LeadProviderController(ILogger<LeadProviderController> logger, ILeadService leadService)
        {
            _logger = logger;
            _leadService = leadService;
        }

        /// <summary>
        /// Endpoint used by 3rd party
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        [HttpPost(Name = "AddLead")]
        public IActionResult AddLead(AddLeadPayload payload)
        {
            if (payload.Lead == null)
                throw new ApplicationException("Lead needs to be set on the payload");

            _leadService.AddLead(payload.Lead);
            return Ok();
        }

        [HttpGet(Name = "Action")]
        public IEnumerable<Lead> Get()
        {
            return _leadService.GetLeads();
        }

       
    }
}
