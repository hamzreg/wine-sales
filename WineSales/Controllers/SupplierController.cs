using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Models;
using WineSales.Domain.ModelConverters;
using WineSales.Domain.Exceptions;
using WineSales.Domain.Interactors;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using WineSales.Data.Repositories;

namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/suppliers")]

    public class SupplierController : Controller
    {
        private readonly ISupplierInteractor supplierInteractor;
        private readonly ISaleInteractor saleInteractor;
        private readonly IWineInteractor wineInteractor;
        private readonly IMapper mapper;
        private readonly SupplierConverter supplierConverters;

        public SupplierController(ISupplierInteractor supplierInteractor, ISaleInteractor saleInteractor
                                  ,IWineInteractor wineInteractor, IMapper mapper, SupplierConverter supplierConverters)
        {
            this.supplierInteractor = supplierInteractor;
            this.saleInteractor = saleInteractor;
            this.wineInteractor = wineInteractor;
            this.mapper = mapper;
            this.supplierConverters = supplierConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SupplierDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<List<SupplierDTO>>(supplierInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(SupplierDTO supplierDTO)
        {
            try
            {
                var addedSupplier = supplierInteractor.CreateSupplier(mapper.Map<SupplierBL>(supplierDTO));
                return Ok(mapper.Map<SupplierDTO>(addedSupplier));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, SupplierBaseDTO supplier)
        {
            try
            {
                var updatedSupplier = supplierInteractor
                    .UpdateSupplier(supplierConverters.ConvertSupplier(id, supplier));
                return updatedSupplier != null ? Ok(mapper.Map<SupplierDTO>(updatedSupplier)) : NotFound();
            }
            catch (SupplierException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedSupplier = supplierInteractor.DeleteSupplier(id);
            return deletedSupplier != null ? Ok(mapper.Map<SupplierDTO>(deletedSupplier)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var supplier = supplierInteractor.GetByID(id);
            return supplier != null ? Ok(mapper.Map<SupplierDTO>(supplier)) : NotFound();
        }

        [HttpGet("{SupplierId}/sales")]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetSalesBySupplierId(int supplierId)
        {
            var sales = saleInteractor.GetBySupplierID(supplierId);
            return sales != null ? Ok(mapper.Map<SaleDTO>(sales)) : NotFound();
        }

        [HttpGet("{SupplierId}/wines")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetWinesBySupplierId(int supplierId)
        {
            var wines = wineInteractor.GetBySupplierID(supplierId);
            return wines != null ? Ok(mapper.Map<WineDTO>(wines)) : NotFound();
        }

        [HttpGet("{SupplierId}/soldWines")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetSoldWinesBySupplierId(int supplierId)
        {
            var soldWines = wineInteractor.GetSoldWinesBySupplierID(supplierId);
            return soldWines != null ? Ok(mapper.Map<WineDTO>(soldWines)) : NotFound();
        }
    }
}

