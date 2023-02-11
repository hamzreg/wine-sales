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

namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/sales")]

    public class SaleController : Controller
    {
        private readonly ISaleInteractor saleInteractor;
        private readonly IMapper mapper;

        public SaleController(ISaleInteractor saleInteractor, IMapper mapper)
        {
            this.saleInteractor = saleInteractor;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SaleDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<IEnumerable<SaleDTO>>(saleInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(SaleDTO saleDTO)
        {
            try
            {
                var addedSale = saleInteractor.CreateSale(mapper.Map<SaleBL>(saleDTO));
                return Ok(mapper.Map<SupplierDTO>(addedSale));
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
                var updatedSale = saleInteractor.UpdateSale(mapper.Map<SaleBL>(sale, o => o.AfterMap((src, dest) => dest.ID = id)));

                return updatedSale != null ? Ok(mapper.Map<SaleDTO>(updatedSale)) : NotFound();
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
            var deletedSale = saleInteractor.DeleteSale(id);
            return deletedSale != null ? Ok(mapper.Map<SaleDTO>(deletedSale)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var sale = saleInteractor.GetByID(id);
            return sale != null ? Ok(mapper.Map<SaleDTO>(sale)) : NotFound();
        }
    }
}

