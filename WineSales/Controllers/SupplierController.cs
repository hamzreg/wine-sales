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
    [Route("/api/v1/suppliers")]

    public class SupplierController : Controller
    {
        private readonly ISupplierInteractor supplierInteractor;
        private readonly IMapper mapper;
        //private readonly UserConverters userConverters;

        public SupplierController(ISupplierInteractor supplierInteractor, IMapper mapper)//, UserConverters userConverters)
        {
            this.supplierInteractor = supplierInteractor;
            this.mapper = mapper;
            //this.userConverters = userConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SupplierDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<IEnumerable<SupplierDTO>>(supplierInteractor.GetAll()));
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
    }
}

