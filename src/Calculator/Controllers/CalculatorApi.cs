/*
 * Calculator API
 *
 * REST API for performing arithmetic operations using JWT
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Calculator.Attributes;
using Microsoft.AspNetCore.Authorization;
using Calculator.Models;
using Calculator.Core.Services;
using Microsoft.Extensions.Logging;
using Castle.Core.Logging;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Calculator.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class CalculatorApiController : ControllerBase
    {
        private readonly ICalculatorService calculatorService;
        private readonly ILogger<CalculatorApiController> logger;
        /// <summary>
        /// Constructor of CalculateApiController
        /// </summary>
        /// <param name="calculatorService">The calculator service instance.</param>
        public CalculatorApiController(ICalculatorService calculatorService, ILogger<CalculatorApiController> logger)
        {
            this.calculatorService = calculatorService;
            this.logger = logger;
        }
        /// <summary>
        /// Performs a calculation on two numbers
        /// </summary>
        /// <param name="body">FirstNumber and SecondNumber</param>
        /// <param name="operation">The arithmetic operation to perform</param>
        /// <response code="200">Calculation result</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("/calculator")]
        [Authorize]
        [ValidateModelState]
        [SwaggerOperation("Calculate")]
        [SwaggerResponse(statusCode: 200, type: typeof(CalculationResponse), description: "Calculation result")]
        public virtual IActionResult Calculate([FromBody]CalculationRequest body, [FromHeader][Required()]string operation)
        {
            try
            {
                logger.LogInformation($"Calculating {body.FirstNumber} {operation} {body.SecondNumber}");
                var result = calculatorService.PerformCalculation(body.FirstNumber, body.SecondNumber, operation);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                logger.LogError(ex, "Invalid calculation argument");
                return BadRequest(ex.Message);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Unexpected error during calculation");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
