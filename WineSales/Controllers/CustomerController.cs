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


namespace WineSales.Controllers
{
    [EnableCors("MyPolicy")]
    [ApiController]
    [Route("/api/v1/customers")]

    public class CustomerController : Controller
    {
        private readonly ICustomerInteractor _customerInteractor;
        private readonly IMapper _mapper;
        private readonly CustomerConverter _customerConverter;

        public CustomerController(ICustomerInteractor customerInteractor, 
                                  IMapper mapper, 
                                  CustomerConverter customerConverter)
        {
            _customerInteractor = customerInteractor;
            _mapper = mapper;
            _customerConverter = customerConverter;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CustomerDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<CustomerDTO>>(_customerInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Create(CustomerDTO customer)
        {
            try
            {
                var createdCustomer = _customerInteractor
                    .CreateCustomer(_mapper.Map<CustomerBL>(customer));

                return Ok(_mapper.Map<CustomerDTO>(createdCustomer));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Patch(int id, CustomerBaseDTO customer)
        {
            try
            {
                var updatedCustomer = _customerInteractor
                    .UpdateCustomer(_customerConverter.ConvertCustomer(id, customer));

                return updatedCustomer != null ? Ok(_mapper.Map<CustomerDTO>(updatedCustomer)) : NotFound();
            }
            catch (CustomerException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var deletedCustomer = _customerInteractor.DeleteCustomer(id);
            return deletedCustomer != null ? Ok(_mapper.Map<CustomerDTO>(deletedCustomer)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetByID(int id)
        {
            var customer = _customerInteractor.GetByID(id);
            return customer != null ? Ok(_mapper.Map<CustomerDTO>(customer)) : NotFound();
        }
    }
}
