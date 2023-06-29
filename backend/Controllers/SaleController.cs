using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Models;
using WineSales.Domain.Interactors;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using WineSales.Data.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/sales")]

    public class SaleController : Controller
    {
        private readonly ISaleInteractor _saleInteractor;
        private readonly IMapper _mapper;

        public SaleController(ISaleInteractor saleInteractor, IMapper mapper)
        {
            _saleInteractor = saleInteractor;
            _mapper = mapper;
        }
  
        [HttpGet]
        [ProducesResponseType(typeof(List<SaleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<SaleDTO>>(_saleInteractor.GetAll()));
        }
 
        [HttpPost]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)] 
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(SaleBaseDTO sale)
        {
            try
            {
                var createdSale = _saleInteractor
                    .CreateSale(_mapper.Map<SaleBL>(sale));

                return Ok(_mapper.Map<SaleDTO>(createdSale));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
 
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Put(int id, SaleBaseDTO sale)
        {
            try
            {
                var updatedSale = _saleInteractor
                    .UpdateSale(_mapper.Map<SaleBL>(sale, x => x.AfterMap((src, dest) => dest.ID = id)));

                return updatedSale != null ? Ok(_mapper.Map<SaleDTO>(updatedSale)) : NotFound();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }
 
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedSale = _saleInteractor.DeleteSale(id);
            return deletedSale != null ? Ok(_mapper.Map<SaleDTO>(deletedSale)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetByID(int id)
        {
            var sale = _saleInteractor.GetByID(id);
            return sale != null ? Ok(_mapper.Map<SaleDTO>(sale)) : NotFound();
        }
    }
}
