// 4 February 2026
using System.ComponentModel.DataAnnotations;

public class CreateCalcutlationDTO
{
    [Required]
    public double left  { get; set; }

    [Required]
    public double right { get; set; }
    [Required]
    public double OperationType { get; set; }
}