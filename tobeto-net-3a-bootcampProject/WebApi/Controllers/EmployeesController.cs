﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Employee;
using Business.Dtos.Instructor;
using Business.Requests.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(EmployeeRegisterDto employeeRegisterDto)
        {
            var result = await _employeeService.Register(employeeRegisterDto);
            return HandleDataResult(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(new DeleteEmployeeRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            return HandleDataResult(result);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(new GetEmployeeByIdRequest { Id = id });
            return HandleDataResult(result);
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, UpdateEmployeeRequest request)
        {
            request.Id = id;
            var result = _employeeService.Update(request);
            return HandleDataResult(result);
        }
    }
}
