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
    [Route("/api/v1/supplierWine")]

    public class SupplierWineController : Controller
    {
        private readonly ISupplierWineInteractor supplierWineInteractor;
        private readonly IMapper mapper;
        //private readonly UserConverters userConverters;

        public SupplierWineController(ISupplierWineInteractor supplierWineInteractor, IMapper mapper)//, UserConverters userConverters)
        {
            this.supplierWineInteractor = supplierWineInteractor;
            this.mapper = mapper;
            //this.userConverters = userConverters;
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<SupplierWineDTO>), StatusCodes.Status200OK)]
        //public IActionResult GetAll()
        //{
        //    return Ok(mapper.Map<IEnumerable<SupplierWineDTO>>(supplierWineInteractor.GetAll()));
        //}

        [HttpPost]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(SupplierWineDTO supplierWineDTO)
        {
            try
            {
                var addedSupplierWine = supplierWineInteractor.CreateSupplierWine(mapper.Map<SupplierWineBL>(supplierWineDTO));
                return Ok(mapper.Map<SupplierDTO>(addedSupplierWine));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedSupplierWine = supplierWineInteractor.DeleteSupplierWine(id);
            return deletedSupplierWine != null ? Ok(mapper.Map<SupplierWineDTO>(deletedSupplierWine)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SupplierWineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var supplierWine = supplierWineInteractor.GetByID(id);
            return supplierWine != null ? Ok(mapper.Map<SupplierWineDTO>(supplierWine)) : NotFound();
        }
    }
}

