using System;
using System.ComponentModel.DataAnnotations;

namespace Studio.API.Entities
{
    /// <summary>
    /// Classe Aula
    /// </summary>
    public class Aula
    {
        /// <summary>
        /// Propriedade AulaID
        /// </summary>
        [Key]
        [Display(Name = "AulaID")]
        public Int32 aula_id { get; set; }
        /// <summary>
        /// Propriedade Nome
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string nome { get; set; }
        /// <summary>
        /// Propriedade NomeInstrutor
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Display(Name = "NomeInstrutor")]
        public string nome_instrutor { get; set; }
        /// <summary>
        /// Propriedade HorarioInicio
        /// </summary>
        [Required]
        [MaxLength(5)]
        [Display(Name = "HorarioInicio")]
        public string horario_inicio { get; set; }
        /// <summary>
        /// Propriedade HorarioFim
        /// </summary>
        [Required]
        [MaxLength(5)]
        [Display(Name = "HorarioFim")]
        public string horario_fim { get; set; }
        /// <summary>
        /// Propriedade DiasSemana
        /// </summary>
        [Required]
        [MaxLength(14)]
        [Display(Name = "DiasSemana")]
        public string dias_semana { get; set; }
        /// <summary>
        /// Propriedade Sala
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "Sala")]
        public string sala { get; set; }
    }
}