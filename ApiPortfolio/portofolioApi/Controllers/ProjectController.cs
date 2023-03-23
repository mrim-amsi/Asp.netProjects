using Microsoft.AspNetCore.Mvc;
using portofolioApi.Interfaces;
using portofolioClassLibrary.Model;

namespace portofolioApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _postRepository.GetAllPosts());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Post>> Get(int id)
        {
            var post = await _postRepository.GetById(id);
            if (post == null)
                return NotFound();
            else
                return Ok(post);
        }

    }
}
