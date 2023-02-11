using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Models;
using WineSales.Domain.Interactors;
using WineSales.Domain.Exceptions;
using WineSales.Domain.ModelConverters;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using WineSales.Data.Repositories;


namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/supplierWine")]

    public class SupplierWineController : Controller
    {
        private readonly ISupplierWineInteractor _supplierWineInteractor;
        private readonly ISupplierInteractor _supplierInteractor;
        private readonly IMapper _mapper;
        private readonly SupplierWineConverter _supplierWineConverter;

        public SupplierWineController(ISupplierWineInteractor supplierWineInteractor, 
                                      ISupplierInteractor supplierInteractor, 
                                      IMapper mapper, 
                                      SupplierWineConverter supplierWineConverter)
        {
            _supplierWineInteractor = supplierWineInteractor;
            _supplierInteractor = supplierInteractor;
            _mapper = mapper;
            _supplierWineConverter = supplierWineConverter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<SupplierWineDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<SupplierWineDTO>>(_supplierWineInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(SupplierWineDTO supplierWine)
        {
            try
            {
                var createdSupplierWine = _supplierWineInteractor
                    .CreateSupplierWine(_mapper.Map<SupplierWineBL>(supplierWine));

                return Ok(_mapper.Map<SupplierDTO>(createdSupplierWine));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, SupplierWineBaseDTO supplierWine)
        {
            try
            {
                var updatedSupplierWine = _supplierWineInteractor
                    .UpdateSupplierWine(_supplierWineConverter.ConvertSupplierWine(id, supplierWine));
    
                return updatedSupplierWine != null ? Ok(_mapper.Map<SupplierWineDTO>(updatedSupplierWine)) : NotFound();
            }
            catch (SupplierWineException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedSupplierWine = _supplierWineInteractor.DeleteSupplierWine(id);
            return deletedSupplierWine != null ? Ok(_mapper.Map<SupplierWineDTO>(deletedSupplierWine)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var supplierWine = _supplierWineInteractor.GetByID(id);
            return supplierWine != null ? Ok(_mapper.Map<SupplierWineDTO>(supplierWine)) : NotFound();
        }

        [HttpGet("{supplierWineId}/supplier")]
        [ProducesResponseType(typeof(SupplierDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetSupplierBySupplierWineID(int id)
        {
           var supplier = _supplierInteractor.GetBySupplierWineID(id);
           return supplier != null ? Ok(_mapper.Map<SupplierDTO>(supplier)) : NotFound();
        }
    }
}
