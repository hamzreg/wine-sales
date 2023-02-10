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
        private readonly ISaleInteractor saleInteractor;
        private readonly IMapper mapper;
        //private readonly UserConverters userConverters;

        public SupplierController(ISupplierInteractor supplierInteractor, ISaleInteractor saleInteractor ,IMapper mapper)//, UserConverters userConverters)
        {
            this.supplierInteractor = supplierInteractor;
            this.saleInteractor = saleInteractor;
            this.mapper = mapper;
            //this.userConverters = userConverters;
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

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SaleDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetBySupplierId(int id)
        {
            var sale = saleInteractor.GetBySupplierID(id);
            return sale != null ? Ok(mapper.Map<SaleDTO>(sale)) : NotFound();
        }
    }
}

