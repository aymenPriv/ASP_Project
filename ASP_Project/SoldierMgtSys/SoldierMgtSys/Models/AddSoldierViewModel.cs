using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoldierMgtSys.Models;

public class AddSoldierViewModel
{
    [Key]
    public int SoldierId { get; set; }

    [Required, StringLength(100)]
    public string FirstName { get; set; }

    [Required, StringLength(100)]
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [ForeignKey("Rank")]
    public int RankId { get; set; }
    public Rank Rank { get; set; }

    [ForeignKey("Unit")]
    public int UnitId { get; set; }
    public Unit Unit { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfEnlistment { get; set; }

    public ICollection<Assignment> Assignments { get; set; }
}