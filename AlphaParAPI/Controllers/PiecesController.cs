using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaParAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/pieces")]
    public class PiecesController : ControllerBase
    {
        private readonly ModelContext _context;

        public PiecesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/pieces
        [HttpGet("", Name = "GetPieces")]
        public ActionResult<List<Piece>> GetPieces()
        {
            Log.Warning($"Request to GetPieces by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Return the pieces list
            return _context.Piece.Include(x => x.ProductionChain).ToList();
        }

        // GET api/pieces/id
        [HttpGet("{id}", Name = "GetPiece")]
        public ActionResult<Piece> GetPiece(string id)
        {
            Log.Warning($"Request to GetPiece {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Return the specified piece
            var specifiedPiece = _context.Piece.Find(id);

            if (specifiedPiece == null)
            {
                return NotFound();
            }

            return specifiedPiece;
        }

        // POST api/pieces
        [HttpPost]
        public ActionResult AddPiece([FromBody]Piece piece)
        {
            Log.Warning($"Request to AddPiece {piece.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Create the piece with all information
            var specifiedProductionChain = _context.Plan.Find(piece.IdProductionChain);
            if (piece.Name == null || specifiedProductionChain == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Piece.Add(piece);
                _context.SaveChanges();

                return Ok();
            }
        }

        // PUT api/pieces/id
        [HttpPut("{id}")]
        public ActionResult ModifyPiece(string id, [FromBody]Piece piece)
        {
            Log.Warning($"Request to ModifyPiece {piece.Id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Update the specified piece
            var specifiedPiece = _context.Piece.Find(id);
            if (specifiedPiece == null)
            {
                return NotFound();
            }


            if (piece.Name == null)
            {
                return BadRequest();
            }
            else
            {
                specifiedPiece.Name = piece.Name;
                specifiedPiece.Stock = piece.Stock;
            }

            _context.Piece.Update(specifiedPiece);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/pieces/id
        [HttpDelete("{id}")]
        public IActionResult DeletePiece(string id)
        {
            Log.Warning($"Request to DeletePiece {id} by authentified user {HttpContext.User.Identity.Name}");
            Utils.GetClientMac(this.HttpContext);
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Forbid();
            }
            // Delete the specified piece
            var specifiedPiece = _context.Piece.Find(id);
            var PieceExistsInPlan = _context.Plan.Select(x => x.IdPiece == id).FirstOrDefault();

            if (specifiedPiece == null || PieceExistsInPlan)
            {
                return NotFound();
            }

            _context.Piece.Remove(specifiedPiece);
            _context.SaveChanges();
            return Ok();
        }
    }
}
