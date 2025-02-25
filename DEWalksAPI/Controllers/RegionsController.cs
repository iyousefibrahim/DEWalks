using DEWalksAPI.Data;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly DEWalksDbContext _Dbcontext;
        public RegionsController(DEWalksDbContext Dbcontext)
        {
            this._Dbcontext = Dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Get Data From DataBase (Domain Model)
            var regions = await _Dbcontext.Regions.ToListAsync();

            // Map Domain Model to -> DTO
            var regionsDto = new List<RegionDto>();

            foreach (var item in regions)
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
        public async Task<IActionResult> GetRegionById([FromRoute]Guid Id)
        {
            // Get Data From DataBase (Domain Model)
            var region = await _Dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
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
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Convert DTO To Domain Model
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Save new record
            await _Dbcontext.Regions.AddAsync(regionDomainModel);
            await _Dbcontext.SaveChangesAsync();

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
        public async Task<IActionResult> UpdateRegionById([FromRoute]Guid Id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = await _Dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }
            // Map DTO To Domain Model
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            await _Dbcontext.SaveChangesAsync();

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
            var regionModel = await _Dbcontext.Regions.FirstOrDefaultAsync(r => r.Id == Id);

            if(regionModel == null)
            {
                return NotFound();
            }

            _Dbcontext.Regions.Remove(regionModel);
            await _Dbcontext.SaveChangesAsync();

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
