using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlphaParAPI.Controllers
{
    [Route("api/pieces")]
    public class PiecesController : Controller
    {
        // GET: api/pieces
        [HttpGet]
        public ActionResult<List<Piece>> GetPieces()
        {
            // Return the pieces list
            return null;
        }

        // GET api/pieces/id
        [HttpGet("{id}")]
        public ActionResult<string> GetPiece(string id)
        {
            // Return the specified piece
            return "Piece";
        }

        // POST api/pieces
        [HttpPost]
        public ActionResult AddPiece(Piece piece)
        {
            // Create the piece with all information
            return null;
        }

        // PUT api/pieces/id
        [HttpPut("{id}")]
        public ActionResult ModifyPiece(string id, Piece piece)
        {
            // Update the specified piece
            return null;
        }

        // DELETE api/pieces/id
        [HttpDelete("{id}")]
        public IActionResult DeletePiece(string id)
        {
            // Delete the specified piece
            return null;
        }
    }

    public class Piece
    {
    }
}
