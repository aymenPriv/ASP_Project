using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoldierMgtSys.Models;

public class Assignment
{
    [Key]
    public int AssignmentId { get; set; }

    [Required, StringLength(200)]
    public string AssignmentDetails { get; set; }

    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [ForeignKey("Soldier")]
    public int SoldierId { get; set; }
    public Soldier Soldier { get; set; }
}