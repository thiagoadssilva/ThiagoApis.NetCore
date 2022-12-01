﻿using ApiDotNet6.Domain.Validations;
using APiDotNet6.Application.DTOs;
using APiDotNet6.Application.Services;
using APiDotNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }

            
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _purchaseService.GetAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _purchaseService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.UpdateAsync(purchaseDTO);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoveAsync(int id)
        {
            var result = await _purchaseService.RemoveAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
