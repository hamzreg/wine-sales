﻿using System;
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
    [Route("/api/v1/wines")]

    public class WineController : Controller
    {
        private readonly IWineInteractor wineInteractor;
        private readonly IMapper mapper;
        //private readonly UserConverters userConverters;

        public WineController(IWineInteractor wineInteractor, IMapper mapper)//, UserConverters userConverters)
        {
            this.wineInteractor = wineInteractor;
            this.mapper = mapper;
            //this.userConverters = userConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WineDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<IEnumerable<WineDTO>>(wineInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(WineDTO wineDTO)
        {
            try
            {
                var addedSupplier = wineInteractor.CreateWine(mapper.Map<WineBL>(wineDTO));
                return Ok(mapper.Map<SupplierDTO>(addedSupplier));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedWine = wineInteractor.DeleteWine(id);
            return deletedWine != null ? Ok(mapper.Map<WineDTO>(deletedWine)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var wine = wineInteractor.GetByID(id);
            return wine != null ? Ok(mapper.Map<WineDTO>(wine)) : NotFound();
        }
    }
}
