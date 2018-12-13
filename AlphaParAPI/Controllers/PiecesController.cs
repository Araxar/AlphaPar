using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaParAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            // Return the pieces list
            return _context.Piece.ToList();
        }

        // GET api/pieces/id
        [HttpGet("{id}", Name = "GetPiece")]
        public ActionResult<Piece> GetPiece(string id)
        {
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
            // Create the piece with all information
            _context.Piece.Add(piece);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/pieces/id
        [HttpPut("{id}")]
        public ActionResult ModifyPiece(string id, [FromBody]Piece piece)
        {
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
            // Delete the specified piece
            var specifiedPiece = _context.Piece.Find(id);
            if (specifiedPiece == null)
            {
                return NotFound();
            }

            _context.Piece.Remove(specifiedPiece);
            _context.SaveChanges();
            return Ok();
        }
    }
}
