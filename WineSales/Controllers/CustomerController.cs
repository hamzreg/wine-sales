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
        private readonly ICustomerInteractor customerInteractor;
        private readonly IMapper mapper;
        private readonly CustomerConverter customerConverters;

        public CustomerController(ICustomerInteractor customerInteractor, IMapper mapper, CustomerConverter customerConverters)
        {
            this.customerInteractor = customerInteractor;
            this.mapper = mapper;
            this.customerConverters = customerConverters;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDTO>), StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            return Ok(mapper.Map<IEnumerable<CustomerDTO>>(customerInteractor.GetAll()));
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
        public IActionResult Add(UserPasswordDTO customerDTO)
        {
            try
            {
                var addedCustomer = customerInteractor.CreateCustomer(mapper.Map<CustomerBL>(customerDTO));
                return Ok(mapper.Map<CustomerDTO>(addedCustomer));
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
                var updatedCustomer = customerInteractor
                    .UpdateCustomer(customerConverters.ConvertCustomer(id, customer));
                return updatedCustomer != null ? Ok(mapper.Map<CustomerDTO>(updatedCustomer)) : NotFound();
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
            var deletedCustomer = customerInteractor.DeleteCustomer(id);
            return deletedCustomer != null ? Ok(mapper.Map<CustomerDTO>(deletedCustomer)) : NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            var customer = customerInteractor.GetByID(id);
            return customer != null ? Ok(mapper.Map<CustomerDTO>(customer)) : NotFound();
        }
    }
}

