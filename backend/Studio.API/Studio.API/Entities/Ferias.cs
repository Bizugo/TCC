using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Entities
{
    /// <summary>
    /// Classe Ferias
    /// </summary>
    public class Ferias
    {
        /// <summary>
        /// Propriedade FeriasID
        /// </summary>
        [Key]
        [Display(Name = "FeriasID")]
        public Int32 ferias_id { get; set; }
        /// <summary>
        /// Propriedade Foreign Key CPF
        /// </summary>
        [Required]
        [MaxLength(14)]
        [Display(Name = "CPF")]
        public string cpf { get; set; }
        /// <summary>
        /// Propiedade DataInicio
        /// </summary>
        [Required]
        [Display(Name = "DataInicio")]
        public DateTime dataInicio { get; set; }
        /// <summary>
        /// Propiedade DataFim
        /// </summary>
        [Required]
        [Display(Name = "DataFim")]
        public DateTime dataFim { get; set; }
    }
}