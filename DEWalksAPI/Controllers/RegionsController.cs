using DEWalksAPI.Data;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllRegions()
        {
            // Get Data From DataBase (Domain Model)
            var regions = _Dbcontext.Regions.ToList();

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
        public IActionResult GetRegionById([FromRoute]Guid Id)
        {
            // Get Data From DataBase (Domain Model)
            var region = _Dbcontext.Regions.FirstOrDefault(r => r.Id == Id);
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
        public IActionResult CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Convert DTO To Domain Model
            var regionDomainModel = new Region
            {
                Name = addRegionRequestDto.Name,
                Code = addRegionRequestDto.Code,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Save new record
            _Dbcontext.Regions.Add(regionDomainModel);
            _Dbcontext.SaveChanges();

            // Back To DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return StatusCode(201, regionDto);
        }

        [Route("{Id:guid}")]
        [HttpPut]
        public IActionResult UpdateRegionById([FromRoute]Guid Id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = _Dbcontext.Regions.FirstOrDefault(r => r.Id == Id);
            if(regionDomainModel == null)
            {
                return NotFound();
            }
            // Map DTO To Domain Model
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            _Dbcontext.SaveChanges();

            // Convert Domain Model To DTO
            var regionDto = new RegionDto {
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }

        [Route("{Id:guid}")]
        [HttpDelete]
        public IActionResult DeleteRegionById([FromRoute] Guid Id)
        {
            var regionModel = _Dbcontext.Regions.FirstOrDefault(r => r.Id == Id);

            if(regionModel == null)
            {
                return NotFound();
            }

            _Dbcontext.Regions.Remove(regionModel);
            _Dbcontext.SaveChanges();

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
