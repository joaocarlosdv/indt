using System.ComponentModel.DataAnnotations;

namespace Proposta.Application.Enums
{
    public enum StatusPropostaEnum
    {
        [Display(Name = "Em Análise")]
        EmAnalise = 0,
        [Display(Name = "Aprovada")]
        Aprovada = 1,
        [Display(Name = "Rejeitada")]
        Rejeitada = 2,
    }
}
