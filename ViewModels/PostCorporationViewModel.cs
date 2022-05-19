﻿using System;
using System.ComponentModel.DataAnnotations;

namespace _2rpnet.rpa.webAPI.ViewModels
{
    public class PostCorporationViewModel
    {
        [Required(ErrorMessage = "Nome fantasia da empresa inválido")]
        public string NameFantasy { get; set; }
        [Required(ErrorMessage = "Razão Social da corporação/empresa necessário")]
        public string CorporateName { get; set; }
        [Required(ErrorMessage = "Endereço da corporação/empresa necessário")]
        public string AddressName { get; set; }
        [Required(ErrorMessage = "Telefone da corporação/empresa necessário")]
        public string CorpPhone { get; set; }
        [Required(ErrorMessage = "CNPJ da corporação/empresa necessário")]
        public string Cnpj { get; set; }


        [Required(ErrorMessage = "Nome de usuário inválido")]
        public string UserName1 { get; set; }
        [Required(ErrorMessage = "Email do usuário necessário")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Senha necessária")]
        public string Passwd { get; set; }
        [Required(ErrorMessage = "CPF do usuário necessário")]
        public string Cpf { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Data de nascimento do usuário necessária")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Rg do usuário necessário")]
        public string Rg { get; set; }


        [Required(ErrorMessage = "Id de cargo do usuário inválido")]
        public int IdOffice { get; set; }
    }
}