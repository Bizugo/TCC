using System;
using System.ComponentModel.DataAnnotations;

namespace Studio.API.Entities
{
    /// <summary>
    /// Classe Pessoa
    /// </summary>
    public class Pessoa
    {
        /// <summary>
        /// Propriedade CPF
        /// </summary>
        [Key]
        [Required]
        [MaxLength(14)]
        [Display(Name = "CPF")]
        public string cpf { get; set; }
        /// <summary>
        /// Propriedade Nome
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        /// <summary>
        /// Propriedade Identidade
        /// </summary>
        [Required]
        [MaxLength(13)]
        [Display(Name = "Identidade")]
        public string identidade { get; set; }
        /// <summary>
        /// Propriedade Endereço
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Display(Name = "Endereco")]
        public string endereco { get; set; }
        /// <summary>
        /// Propriedade DataPagamento
        /// </summary>
        [Required]
        [Display(Name = "DataPagamento")]
        public DateTime data_pagamento { get; set; }
        /// <summary>
        /// Propriedade Inadimplente
        /// </summary>
        [Display(Name = "Inadimplente")]
        public bool inadimplente { get; set; }
        /// <summary>
        /// Propriedade TipoPagamento
        /// </summary>
        [Display(Name = "TipoPagamento")]
        public string tipo_pagamento { get; set; }
        /// <summary>
        /// Propriedade TipoAtividade
        /// </summary>
        [Display(Name ="TipoAtividade")]
        public string tipo_atividade { get; set; }
        /// <summary>
        /// Propriedade Funcionário
        /// </summary>
        [Required]
        [Display(Name = "Funcionario")]
        public bool funcionario { get; set; }
        /// <summary>
        /// Propriedade Senha
        /// </summary>
        [Display(Name = "Senha")]
        [MaxLength(8)]
        public string senha { get; set; }
        /// <summary>
        /// Propriedade TipoPessoa
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Display(Name = "TipoPessoa")]
        public string tipo_pessoa { get; set; }
    }
}