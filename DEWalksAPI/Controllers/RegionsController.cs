using DEWalksAPI.Data;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;
using DEWalksAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regionDomain = await regionRepository.GetAllRegionsAsync();
            // Map Domain Model to -> DTO
            var regionsDto = new List<RegionDto>();

            foreach (var item in regionDomain)
            {
                regionsDto.Add(new RegionDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    RegionImageUrl = item.RegionImageUrl
                });
            }

            // Return DTO
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute]Guid Id)
        {
            // Get Data From DataBase (Domain Model)
            var region = await regionRepository.GetRegionByIdAsync(Id);
            if (region == null)
            {
                return NotFound();
            }

            // Map Domain Model to -> DTO
            var regionsDto = new RegionDto
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            // Return DTO
            return Ok(regionsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegionAsync([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Convert DTO To Domain Model
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Save new record
            regionDomainModel = await regionRepository.CreateRegionAsync(regionDomainModel);

            // Back To DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return StatusCode(201, regionDto);
        }

        [Route("{Id:guid}")]
        [HttpPut]
        public async Task<IActionResult> UpdateRegionByIdAsync([FromRoute]Guid Id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {

            // Map DTO To Domain Model
            var regionDomainModel = new Region {
                Name = updateRegionRequestDto.Name,
                Code = updateRegionRequestDto.Code,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl

            };

            regionDomainModel = await regionRepository.UpdateRegionByIdAsync(Id, regionDomainModel);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            // Convert Domain Model To DTO
            var regionDto = new RegionDto {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [Route("{Id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteRegionById([FromRoute] Guid Id)
        {
            var regionModel = await regionRepository.DeleteAsync(Id);

            if(regionModel == null)
            {
                return NotFound();
            }

            // Map regionModel To DTO
            var resgionDto = new RegionDto { 
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionImageUrl = regionModel.RegionImageUrl
            };

            return Ok(resgionDto);
        }

    }
}
