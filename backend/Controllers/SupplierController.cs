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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;


namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/suppliers")]

    public class SupplierController : Controller
    {
        private readonly ISupplierInteractor _supplierInteractor;
        private readonly ISaleInteractor _saleInteractor;
        private readonly ISupplierWineInteractor _supplierWineInteractor;
        private readonly IMapper _mapper;
        private readonly SupplierConverter _supplierConverter;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ISupplierInteractor supplierInteractor, 
                                  ISaleInteractor saleInteractor,
                                  ISupplierWineInteractor supplierWineInteractor,
                                  IMapper mapper, 
                                  SupplierConverter supplierConverter,
                                  ILogger<SupplierController> logger)
        {
            _supplierInteractor = supplierInteractor;
            _saleInteractor = saleInteractor;
            _supplierWineInteractor = supplierWineInteractor;
            _mapper = mapper;
            _supplierConverter = supplierConverter;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SupplierDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Supplier (Request: GET)");
            return Ok(_mapper.Map<List<SupplierDTO>>(_supplierInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(SupplierDTO supplier)
        {
            try
            {
                var createdSupplier = _supplierInteractor
                    .CreateSupplier(_mapper.Map<SupplierBL>(supplier));

                return Ok(_mapper.Map<SupplierDTO>(createdSupplier));
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
                var updatedSupplier = _supplierInteractor
                    .UpdateSupplier(_supplierConverter.ConvertSupplier(id, supplier));

                return updatedSupplier != null ? Ok(_mapper.Map<SupplierDTO>(updatedSupplier)) : NotFound();
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
            var deletedSupplier = _supplierInteractor.DeleteSupplier(id);
            return deletedSupplier != null ? Ok(_mapper.Map<SupplierDTO>(deletedSupplier)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var supplier = _supplierInteractor.GetByID(id);
            return supplier != null ? Ok(_mapper.Map<SupplierDTO>(supplier)) : NotFound();
        }
        
        [HttpGet("{supplierId}/sales")]
        [ProducesResponseType(typeof(List<SaleDTO>), StatusCodes.Status200OK)]        
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetSalesBySupplierId(int supplierId)
        {
            return Ok(_mapper.Map<List<SaleDTO>>(_saleInteractor.GetBySupplierID(supplierId)));
        }
      
        [HttpGet("{supplierId}/supplierWines")]
        [ProducesResponseType(typeof(List<SupplierWineDTO>), StatusCodes.Status200OK)]      
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetSupplierWinesBySupplierId(int supplierId)
        {
            return Ok(_mapper.Map<List<SupplierWineDTO>>(_supplierWineInteractor.GetBySupplierID(supplierId)));
        }
    }
}
