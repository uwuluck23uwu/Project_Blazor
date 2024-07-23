using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tangy_Models;

namespace WebLucky_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _cr;
        public CommentController(ICommentRepository cr)
        {
            _cr = cr;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAll(int productId)
        {
            return Ok(await _cr.GetAll(productId));
        }
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(int commentId)
        {
            return Ok(await _cr.Delete(commentId));
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Create([FromBody] CommentDTO objDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cr.Create(objDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new comment");
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Update([FromBody] CommentDTO objDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cr.Update(objDTO);
            if (result != null)
            {
                return Ok(result);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating comment");
        }
    }
}
