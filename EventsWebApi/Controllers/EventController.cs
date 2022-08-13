using Microsoft.AspNetCore.Mvc;
using EventsApplication.Queries.GetEventList;
using EventsApplication.Queries.GetEventById;
using EventsApplication.Commands.CreateEvent;
using EventsApplication.Commands.DeleteEvent;
using EventsApplication.Commands.UpdateEvent;
using EventsWebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace EventsWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EventController : BaseController
    {
        private readonly IMapper _mapper;

        public EventController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of events
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /event
        /// </remarks>
        /// <returns>Returns EventListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<EventListVm>> GetAll()
        {
            var query = new GetEventListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the event by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /event/1
        /// </remarks>
        /// <param name="id">Event id (int)</param>
        /// <param name="title">Event Title (string)</param>
        /// <param name="description">Event Description (string)</param>
        /// <param name="plan">Event Plan (string)</param>
        /// <param name="time">Event Time (DateTime)</param>
        /// <param name="venue">Event Venue (string)</param>
        /// <param name="speaker">Event Speaker (string)</param>
        /// <param name="sponsor">Event Sponsor (string)</param>
        /// <returns>Returns EventByIdVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [Authorize]
        [HttpGet("/{id}:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<EventByIdVm>> Get(int id)
        {
            var query = new GetEventByIdQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the event
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /event
        /// {
        ///     Title: "event Title",
        ///     Description: "event Description"
        ///     Plan: "event Plan"
        ///     Time: "event Time"
        ///     Venue: "event Venue"
        ///     Speaker: "event Speaker"
        ///     Sponsor: "event Sponsor"
        /// }
        /// </remarks>
        /// <param name="createEventDto">CreateEventDto object</param>
        /// <returns>Returns id (int)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<int>> Create([FromBody] CreateEventDto createEventDto)
        {
            var command = _mapper.Map<CreateEventCommand>(createEventDto);  
            var eventId = await Mediator.Send(command);
            return Ok(eventId);
        }

        /// <summary>
        /// Updates the note
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /event
        /// {
        ///     Title: "updated event Title",
        ///     Description: "updated event Description"
        ///     Plan: "updated event Plan"
        ///     Time: "updated event Time"
        ///     Venue: "updated event Venue"
        ///     Speaker: "updated event Speaker"
        ///     Sponsor: "updated event Sponsor"
        /// }
        /// </remarks>
        /// <param name="updateEventDto">UpdateEventDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Update([FromBody] UpdateEventDto updateEventDto)
        {
            var command = _mapper.Map<UpdateEventCommand>(updateEventDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the event by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /event/1
        /// </remarks>
        /// <param name="id">Id of the event (int)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [Authorize]
        [HttpDelete("/{id}:int")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteEventCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
