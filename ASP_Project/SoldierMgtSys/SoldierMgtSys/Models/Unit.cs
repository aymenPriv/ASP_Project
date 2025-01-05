using System.ComponentModel.DataAnnotations;

namespace SoldierMgtSys.Models;

public class Unit
{
    [Key]
    public int UnitId { get; set; }

    [Required, StringLength(100)]
    public string UnitName { get; set; }

    [Required, StringLength(200)]
    public string Location { get; set; }

    public ICollection<Soldier> Soldiers { get; set; }
}