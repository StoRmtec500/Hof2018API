using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schaf.Models;
using Schaf.Services;

namespace Schaf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EinstellungenController : ControllerBase
    {
        private readonly IEinstellungen _einstellungenService;

        public EinstellungenController(IEinstellungen einstellungenService)
        {
            _einstellungenService = einstellungenService ?? throw new ArgumentNullException(nameof(einstellungenService));
        }

        // GET: api/Einstellungen
        [HttpGet("{sql}")]
        public ActionResult<IEnumerable<Einstellungen>> GetEinstellungen(string sql)
        {
            return Ok(_einstellungenService.GetAll(sql));
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Einstellungen einstellungen)
        {
            if (einstellungen == null)
                return BadRequest();

            Einstellungen orig = _einstellungenService.GetEinstellungById(id);
            if (orig == null)
                return NotFound();

            _einstellungenService.UpdateEinstellungen(einstellungen);
            
            return new NoContentResult();
        }

        [HttpPut]
        public void Put([FromBody]Einstellungen einstellungen)
        {
            _einstellungenService.Update(einstellungen);

        }


        [HttpPost]
        public HttpResponseMessage Post([FromBody] string sql)
        {
            if (sql == null || sql.Length <= 2)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            _einstellungenService.Insert(sql);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

    }
}