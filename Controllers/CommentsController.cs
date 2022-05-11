﻿using _2rpnet.rpa.webAPI.Contexts;
using _2rpnet.rpa.webAPI.Domains;
using _2rpnet.rpa.webAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace _2rpnet.rpa.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        // Vincular a Interface
        private readonly ICommentRepository ctx;
        private readonly IEmployeeRepository Ectx;
        private readonly IPlayerRepository Pctx;
        private readonly IPostRepository Postctx;
        private readonly IUserNameRepository Uctx;

        public CommentsController(ICommentRepository context, IEmployeeRepository contextEmployee, IUserNameRepository contextUser, IPlayerRepository contextPlayer, IPostRepository contextPost)
        {
            ctx = context;
            Ectx = contextEmployee;
            Uctx = contextUser;
            Pctx = contextPlayer;
            Postctx = contextPost;
        }

        // Metodo GET - Listagem
        //[Authorize(Roles = "1, 2, 3")]
        //[HttpGet]
        //public IActionResult ReadAll()
        //{
        //    return Ok(ctx.ReadAll());
        //}

        //// Metodo GET por ID - Procurar pela ID
        //[Authorize(Roles = "1,2,3")]
        //[HttpGet("{id}")]
        //public IActionResult SearchByID(int id)
        //{
        //    var comment = ctx.SearchByID(id);

        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(comment);
        //}

        // Metodo PUT - Atualizacao
        [Authorize(Roles = "1,2,3")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, Comment comment)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);
                int UserRole = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == "Role").Value);
                comment.IdComment = id;
                if (Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == comment.IdPlayer).IdEmployee).IdUser != Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value) && Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == "Role").Value) == 3)
                {
                    return Forbid("O usuário comum só pode atualizar seus comentários");
                }
                else if (Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == comment.IdPlayer).IdEmployee).IdCorporation != Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == Uctx.SearchByID(UserId).Employees.First().Players.First().IdPlayer).IdEmployee).IdCorporation)
                {
                    return Forbid("O administrador empresarial só pode alterar comentários de usuários da sua empresa");
                }

                Comment UpdatedComment = ctx.Update(comment);
                if (UpdatedComment == null)
                {
                    return NotFound();
                }
                else return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        // Metodo POST - Cadastro
        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Post(Comment comment)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);
                int UserRole = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == "Role").Value);
                comment.IdPlayer = Ectx.ReadAll().FirstOrDefault(employee => employee.IdUser == Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value)).Players.First().IdPlayer;
                if (Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == Postctx.SearchByID(comment.IdPost).IdPlayer).IdEmployee).IdCorporation != Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == Uctx.SearchByID(UserId).Employees.First().Players.First().IdPlayer).IdEmployee).IdCorporation)
                {
                    return Forbid("O usuário só pode comentar em posts de outros usuários de sua própria empresa");
                }
                Comment ComentarioRetorno = ctx.Create(comment);

                return Ok(ComentarioRetorno);
            }
            catch (Exception error)
            {
                return BadRequest(error);
                throw;
            }
        }

        // Metodo DELETE - Remocao
        [Authorize(Roles = "1, 2, 3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int UserId = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value);
                int UserRole = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == "Role").Value);
                var comment = ctx.SearchByID(id);
                if (comment == null)
                {
                    return NotFound();
                }
                else
                {
                    if (Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == comment.IdPlayer).IdEmployee).IdUser != Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == JwtRegisteredClaimNames.Jti).Value) && Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(C => C.Type == "Role").Value) == 3)
                    {
                        return Forbid("O usuário comum só pode excluir seus comentários");
                    }
                    else if (Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == comment.IdPlayer).IdEmployee).IdCorporation != Ectx.SearchByID(Pctx.ReadAll().FirstOrDefault(p => p.IdPlayer == Uctx.SearchByID(UserId).Employees.First().Players.First().IdPlayer).IdEmployee).IdCorporation && UserRole == 2)
                    {
                        return Forbid("O administrador empresarial só pode alterar comentários de usuários da sua empresa");
                    }
                    ctx.Delete(comment);
                    return NoContent();
                }

            }
            catch (Exception error)
            {
                return BadRequest(error);
                throw;
            }
        }
    }
}