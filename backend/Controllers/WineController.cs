using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WineSales.Domain.DTO;
using WineSales.Domain.ModelsBL;
using WineSales.Domain.Models;
using WineSales.Domain.Interactors;
using WineSales.Domain.ModelConverters;
using WineSales.Domain.Exceptions;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using WineSales.Data.Repositories;
using Microsoft.AspNetCore.Authorization;


namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/wines")]

    public class WineController : Controller
    {
        private readonly IWineInteractor _wineInteractor;
        private readonly IMapper _mapper;
        private readonly WineConverter _wineConverter;

        public WineController(IWineInteractor wineInteractor, 
                              IMapper mapper, 
                              WineConverter wineConverter)
        {
            _wineInteractor = wineInteractor;
            _mapper = mapper;
            _wineConverter = wineConverter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<WineDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<WineDTO>>(_wineInteractor.GetAll()));
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(WineDTO wine)
        {
            try
            {
                var createdWine = _wineInteractor
                    .CreateWine(_mapper.Map<WineBL>(wine));

                return Ok(_mapper.Map<WineDTO>(createdWine));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [Authorize]
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, WineBaseDTO wine)
        {
            try
            {
                var updatedWine = _wineInteractor
                    .UpdateWine(_wineConverter.ConvertWine(id, wine));

                return updatedWine != null ? Ok(_mapper.Map<WineDTO>(updatedWine)) : NotFound();
            }
            catch (WineException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedWine = _wineInteractor.DeleteWine(id);
            return deletedWine != null ? Ok(_mapper.Map<WineDTO>(deletedWine)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WineDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var wine = _wineInteractor.GetByID(id);
            return wine != null ? Ok(_mapper.Map<WineDTO>(wine)) : NotFound();
        }
    }
}
