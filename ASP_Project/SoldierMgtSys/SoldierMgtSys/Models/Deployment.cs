using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoldierMgtSys.Models;

public class Deployment
{
    [Key]
    public int DeploymentId { get; set; }

    [Required, StringLength(100)]
    public string DeploymentLocation { get; set; }

    [DataType(DataType.Date)]
    public DateTime DeploymentStartDate { get; set; }

    [DataType(DataType.Date)]
    public DateTime DeploymentEndDate { get; set; }

    [ForeignKey("Soldier")]
    public int SoldierId { get; set; }
    public Soldier Soldier { get; set; }
}