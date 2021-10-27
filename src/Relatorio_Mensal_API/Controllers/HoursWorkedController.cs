using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Relatorio_Mensal_API.Application.Commands.GetByUser;
using Relatorio_Mensal_API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Relatorio_Mensal_API.Controllers
{
    [ApiController]
    [Route("api/v1/hoursworked")]
    [EnableCors]
    public class HoursWorkedController : Controller
    {
        private readonly IMediator _mediator;

        public HoursWorkedController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetHoursMonthByUsuario")]
        public async Task<ActionResult<IList<HoursWorked>>> GetHoursMonthByUsuario(string usuario, int month)
        {
            try
            {
                var result = await _mediator.Send(new GetByUserCommand(usuario, month));
                return Ok(result.HoursWorkeds);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
