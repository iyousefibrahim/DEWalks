﻿using AutoMapper;
using DEWalksAPI.CustomActionFilters;
using DEWalksAPI.Data;
using DEWalksAPI.Models.Domain;
using DEWalksAPI.Models.DTO;
using DEWalksAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regionDomain = await regionRepository.GetAllRegionsAsync();

            // Map Domain Models to -> DTOs
            var regionDto = mapper.Map<List<RegionDto>>(regionDomain);
            
            // Return DTO
            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute]Guid Id)
        {
            // Get Data From DataBase (Domain Model)
            var regionDomain = await regionRepository.GetRegionByIdAsync(Id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var regionsDto = mapper.Map<RegionDto>(regionDomain);

            // Return DTO
            return Ok(regionsDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegionAsync([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

                // Map DTO To Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // Save new record
                regionDomainModel = await regionRepository.CreateRegionAsync(regionDomainModel);

                // Map Domain Model To DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return StatusCode(201, regionDto);
        }

        [Route("{Id:guid}")]
        [HttpPut]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegionByIdAsync([FromRoute]Guid Id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {

                // Map DTO To Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                regionDomainModel = await regionRepository.UpdateRegionByIdAsync(Id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                // Convert Domain Model To DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
        }

        [Route("{Id:guid}")]
        [HttpDelete]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegionById([FromRoute] Guid Id)
        {
            var regionModel = await regionRepository.DeleteAsync(Id);

            if(regionModel == null)
            {
                return NotFound();
            }

            // Map regionModel To DTO
            var resgionDto = mapper.Map<RegionDto>(regionModel);

            return Ok(resgionDto);
        }

    }
}
