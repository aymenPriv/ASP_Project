using System.ComponentModel.DataAnnotations;

namespace SoldierMgtSys.Models;

public class AddRankViewModel
{
    [Key]
    public int RankId { get; set; }

    [Required, StringLength(50)]
    public string RankName { get; set; }

    public ICollection<Soldier> Soldiers { get; set; }
}