using Microsoft.EntityFrameworkCore;
using SoldierMgtSys.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace SoldierMgtSys.Data;

public class WebAppDbContext: IdentityDbContext<AppUser>
{
    public WebAppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Soldier> TblSoldierInfo { get; set; }
    public DbSet<Unit> TblUnits { get; set; }
    public DbSet<Rank> TblRanks { get; set; }
    public DbSet<Assignment> TblAssignments { get; set; }
    public DbSet<Deployment> TblDeployments { get; set; }
    
    
}