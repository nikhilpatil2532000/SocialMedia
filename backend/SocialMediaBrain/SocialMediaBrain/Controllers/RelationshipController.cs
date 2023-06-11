using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialMediaBrain.Interfaces;
using SocialMediaBrain.InternalModel;
using System.Net.Mime;

namespace SocialMediaBrain.Controllers
{
    [Route("api/relationship")]
    [ApiController]
    public class RelationshipController : ControllerBase
    {
        private IRelationshipManager _relationshipManager;
        public RelationshipController(IRelationshipManager relationshipManager)
        {
            _relationshipManager = relationshipManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RelationshipModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            List<RelationshipModel> relationships = await _relationshipManager.GetRelationshipsAsync();
            return relationships.IsNullOrEmpty() ? NotFound("No Relation found") : Ok(relationships);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RelationshipModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            RelationshipModel? relationshipModel = await _relationshipManager.GetRelationshipAsync(id);
            if(relationshipModel != null) 
                return Ok(relationshipModel);
            return NotFound($"Relationship {id} not found");
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] RelationshipModel relationshipModel)
        {
            try
            {
                RelationshipModel responseBody = await _relationshipManager.AddRelationshipAsync(relationshipModel);
                return CreatedAtAction(nameof(Post),new {
                    ResponseBody = responseBody,
                    IsSuccess = true,
                    StatusCode = Response.StatusCode.ToString()
                });
            }
            catch (Exception ex)
            {
                return Ok(new
                {
                    Response = new {},
                    Exception = ex.Message,
                    IsSuccess = false,
                    StatusCode = Response.StatusCode.ToString()
                });
            }
        }
    }
}
