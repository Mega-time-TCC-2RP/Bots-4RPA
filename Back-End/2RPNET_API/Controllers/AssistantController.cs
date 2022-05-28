﻿using _2RPNET_API.Domains;
using _2RPNET_API.Interfaces;
using _2RPNET_API.Repositories;
using _2RPNET_API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace _2RPNET_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantsController : ControllerBase
    {
        private IAssistantRepository _AssistantRepository { get; set; }
        private IAssistantProcedureRepository _AssistantProcedureRepository { get; set; }
        private IRunRepository _RunRepository { get; set; }

        public AssistantsController(IAssistantRepository Assistant, IAssistantProcedureRepository assistantProcedure, IRunRepository run)
        {
            _AssistantRepository = Assistant;
            _AssistantProcedureRepository = assistantProcedure;
            _RunRepository = run;
        }

        /// <summary>
        /// Method responsible for list all Assistants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ReadAll()
        {
            try
            {
                return Ok(_AssistantRepository.ReadAll());
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        /// <summary>
        /// Method responsible for list Assistant by unique id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{IdAssistant}")]
        public IActionResult ReadMy(int IdAssistant)
        {
            try
            {
                return Ok(_AssistantRepository.SearchByID(IdAssistant));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Method responsible for list Assistant by unique id
        /// </summary>
        /// <returns></returns>
        [HttpGet("Employee/{IdEmployee}")]
        public IActionResult FindByIdEmployee(int IdEmployee)
        {
            try
            {
                return Ok(_AssistantRepository.FindByIdEmployee(IdEmployee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for analyze all Assistants
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(Assistant NewAssistant)
        {
            try
            {
                if (NewAssistant.AssistantName != null || NewAssistant.AssistantDescription != null)
                {
                    _AssistantRepository.Create(NewAssistant);
                    return Created("Assitant created successfully", NewAssistant);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Method responsible for update all Assistants
        /// </summary>
        /// <returns></returns>
        [HttpPut("{IdAssistant}")]
        public IActionResult Update(int IdAssistant, Assistant UpdatedAsssistant)
        {
            try
            {
                Assistant AssistantSought = _AssistantRepository.SearchByID(IdAssistant);

                if (AssistantSought != null)
                {
                    if (UpdatedAsssistant != null)
                    {
                        _AssistantRepository.Update(IdAssistant, UpdatedAsssistant);
                    }
                }
                else
                {
                    return BadRequest();
                }

                return Ok();

            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }


        /// <summary>
        /// Method responsible for delete all Assistants 
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{IdAssistant}")]
        public IActionResult Delete(int IdAssistant)
        {
            try
            {
                if (IdAssistant > 0)
                {
                    List<AssistantProcedure> listProcedures = _AssistantProcedureRepository.SearchByAssistant(IdAssistant);
                    List<Run> listRuns = _RunRepository.AssistantList(IdAssistant);
                    if (listProcedures != null)
                    {
                        _AssistantProcedureRepository.Delete(IdAssistant);
                    }
                    if (listRuns != null)
                    {
                        _RunRepository.Delete(IdAssistant);

                    }
                    _AssistantRepository.Delete(IdAssistant);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
        }

        [HttpPost("EnviarEmail")]
        public IActionResult EnviaEmail(int idAssistant, SendEmailViewModel assistant)
        {
            try
            {
                _AssistantRepository.EnviaEmail(idAssistant, assistant);
                return Ok(new
                {
                    Mensagem = "Código enviado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [HttpPost("EnviarEmailUsuario")]
        public IActionResult EnviaEmail(SendEmailViewModel assistant)
        {
            try
            {
                _AssistantRepository.EnviaEmail(assistant);
                return Ok(new
                {
                    Mensagem = "Código enviado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}