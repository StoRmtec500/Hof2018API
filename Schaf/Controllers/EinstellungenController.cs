using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Belgrade.SqlClient;
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
        private readonly IQueryPipe SqlPipe;
        private readonly ICommand SqlCommand;

        public EinstellungenController(IEinstellungen einstellungenService, ICommand sqlCommand, IQueryPipe sqlPipe)
        {
            this.SqlCommand = sqlCommand;
            this.SqlPipe = sqlPipe;
            _einstellungenService = einstellungenService ?? throw new ArgumentNullException(nameof(einstellungenService));
        }

        // GET: api/Einstellungen
    /*    [HttpGet("{sql}")]
        public ActionResult<IEnumerable<Einstellungen>> GetEinstellungen(string sql)
        {
            return Ok(_einstellungenService.GetAll(sql));
        }*/

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


        [HttpGet]
        public async Task Get()
        {
            await SqlPipe.Stream("Select * from einstellungen FOR JSON PATH", Response.Body, "[]");
        }

        [HttpGet("{sql}")]
        public async Task Get1(string sql)
        {
            var cmd = new SqlCommand("" + sql + " FOR JSON PATH");
            await SqlPipe.Stream(cmd, Response.Body, "[]");
        }

        [HttpPut("{sql}")]
        public async Task Put([FromBody]string sql )
        {
             var cmd = new SqlCommand(sql);
            await SqlCommand.ExecuteNonQuery(cmd);
        }

        [HttpGet("getabspaenntermin/{termin}")]
        public async Task GetAbspaenntermin(string termin)
        {
            await SqlPipe.Stream("select a.schaf_nr, s.ama_nummer, s.merkmal, s.geburtsdatum,DATEADD(dd,"+termin+",a.ablamm_datum) as abspaenntermin, s.bemerkung, s.geschlecht, a.lamm1_nr, a.lamm2_nr, a.lamm3_nr, s.ohrmarken_id, a.lfd_nr from ablamm a inner join schaf s ON s.schaf_nr = a.schaf_nr where a.abspaenn_datum is null and a.ablamm_datum is not null order by abspaenntermin FOR JSON PATH", Response.Body, "[]");
        }

        [HttpGet("getablammtermin/{termin}")]
        public async Task GetAblammtermin(string termin)
        {
            await SqlPipe.Stream("select a.schaf_nr, s.ama_nummer, s.merkmal, s.geburtsdatum,DATEADD(dd," + termin + ",a.zum_widder_datum) as ablammtermin, a.ablamm_datum, s.bemerkung, s.ohrmarken_id, a.lfd_nr from ablamm a inner join schaf s ON s.schaf_nr = a.schaf_nr where a.ablamm_datum is null order by ablammtermin FOR JSON PATH", Response.Body, "[]");
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