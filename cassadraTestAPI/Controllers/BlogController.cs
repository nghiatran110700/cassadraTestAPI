using cassadraTestAPI.Model;
using Cassandra;
using Cassandra.Mapping;
using Microsoft.AspNetCore.Mvc;
using ISession = Cassandra.ISession;

namespace cassadraTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ICluster _cluster;
        private ISession _session;
        private IMapper _mapper;
        public BlogController()
        {
            _cluster = Cluster.Builder().AddContactPoints("127.0.0.1").WithPort(9042).Build();
            _session = _cluster.Connect("blog");
            _mapper = new Mapper(_session);
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllPost()
        {
            var listPosts = _mapper.Fetch<Post>();

            return Ok(listPosts);
        }

        [HttpGet]
        [Route("getName")]
        public IActionResult GetByName(string tittle)
        {
            var listPosts = _mapper.Fetch<Post>();
            if (!string.IsNullOrEmpty(tittle))
            {
                listPosts = listPosts.Where(x => x.title.Contains(tittle)).ToList();
            }
            return Ok(listPosts);
        }

        [HttpPost]
        public IActionResult AddPost(Post post)
        {
            _mapper.Insert<Post>(post);
            return Ok("da add thanh con");
        }

        [HttpPatch]
        public IActionResult EditPost(Guid id, Post model)
        {
            var post = _mapper.Fetch<Post>().FirstOrDefault(x => x.post_id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Update<Post>(model);
                return Ok("da edit thanh cong");
            }
        }

        [HttpDelete]
        public IActionResult RemovePost(Guid id)
        {
            var post = _mapper.Fetch<Post>().FirstOrDefault(x => x.post_id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Delete<Post>(post);
                return Ok("da xoa thanh cong");
            }
        }
    }
}
