using Microsoft.AspNetCore.Mvc;
using Application.Checkin.Queries;
using Application.Checkin.Commands.Models;
using Application.Checkin.Commands;
namespace API
{
    [ApiController]
    [Route("api/checkin")]
    public class CheckInController : ControllerBase
    {
        private readonly IGetCheckinById _igcbi;
        private readonly ICreateCheckin _icc;
        private readonly IUpdateCheckin _iuc;
        private readonly IGetCheckinListByFilter _igclbf;

        public CheckInController(
            IGetCheckinListByFilter igclbf,
            IGetCheckinById igcbi,
            ICreateCheckin icc,
            IUpdateCheckin iuc)
        {
            _icc = icc;
            _igclbf = igclbf;
            _igcbi = igcbi;
            _iuc = iuc;
        }

        [HttpGet("{checkin_id}")]
        public async Task<ActionResult<CheckinResponse>> GetCheckIn(long checkin_id, CancellationToken cancellationToken)
        {
            // Simulate a check-in process
            var result = await _igcbi.GetCheckinByIdAsync(checkin_id, cancellationToken);

            return Ok(result);
        }

        [HttpGet("search/{filter?}")]
        public async Task<ActionResult<CheckinResponse>> GetCheckInList(CancellationToken cancellationToken, [FromRoute]string? filter = "")
        {
            // Simulate a check-in process
            var result = await _igclbf.GetCheckinListByFilterAsync(filter ?? string.Empty, cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CheckinResponse>> PostCheckIn([FromBody] CreateCheckinRequest checkin)
        {
            if (checkin is null)
            {
                return BadRequest("Check-in data is required.");
            }

            var result = await _icc.CreateCheckinAsync(checkin);

            return CreatedAtAction(
                nameof(PostCheckIn),
                new { id = result.checkin_id },
                checkin);
        }

        [HttpPut("{checkin_id}")]
        public async Task<ActionResult<CheckinResponse>> UpdateCheckIn(long checkin_id, [FromBody] UpdateCheckinRequest checkin)
        {
            if (checkin is null)
            {
                return BadRequest("Check-in data is required.");
            }

            var result = await _iuc.UpdateCheckinAsync(checkin, checkin_id);

            return Ok(result);
        }
    }
}
