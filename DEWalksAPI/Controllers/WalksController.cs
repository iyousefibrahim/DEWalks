using AutoMapper;
using DEWalksAPI.CustomActionFilters;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;
using DEWalksAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walks = await walkRepository.GetAllWalksAsync();
            if(walks == null)
            {
                return Ok("No Walks Founded!");
            }
            var walksDto = mapper.Map<List<WalkDto>>(walks);
            return Ok(walksDto);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetWalkByIdAsync([FromRoute]Guid Id)
        {
            var walkDomain = await walkRepository.GetWalkByIdAsync(Id);

            if(walkDomain == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalkAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomain = mapper.Map<Walk>(addWalkRequestDto);

            walkDomain = await walkRepository.CreateWalkAsync(walkDomain);

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return Ok(walkDto);
        }

        [HttpPut]
        [Route("{Id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkByIdAsync([FromRoute]Guid Id,[FromBody]UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkModel = await walkRepository.UpdateWalkByIdAsync(Id,walkModel);

            if(walkModel == null)
            {
                return NotFound();
            }

            var walkDto = mapper.Map<WalkDto>(walkModel);
            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid Id)
        {
            var walkDomain = await walkRepository.DeleteWalkAsync(Id);
            if(walkDomain == null)
            {
                return NotFound();
            }
            var walkDto = mapper.Map<WalkDto>(walkDomain);
            return Ok(walkDto);
        }
    }
}
