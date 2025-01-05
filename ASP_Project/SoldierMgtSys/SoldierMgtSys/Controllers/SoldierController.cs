using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoldierMgtSys.Data;
using SoldierMgtSys.Models;

namespace SoldierMgtSys.Controllers;

public class SoldierController : Controller
{
    private readonly WebAppDbContext wbAppDbContext;
    
    public SoldierController(WebAppDbContext wbAppDbContext)
    {
        this.wbAppDbContext = wbAppDbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddSoldierViewModel addSoldierRequest)
    {
        var soldierModel = new Soldier()
        {
            SoldierId = addSoldierRequest.SoldierId,
            FirstName = addSoldierRequest.FirstName,
            LastName = addSoldierRequest.LastName,
            DateOfBirth = addSoldierRequest.DateOfBirth,
            DateOfEnlistment = addSoldierRequest.DateOfEnlistment,
            RankId = addSoldierRequest.RankId,
            UnitId = addSoldierRequest.UnitId,
        };
        await wbAppDbContext.TblSoldierInfo.AddAsync(soldierModel);
        await wbAppDbContext.SaveChangesAsync();
        
        return RedirectToAction("Add");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var soldierList = await wbAppDbContext.TblSoldierInfo.ToListAsync();
        return View(soldierList);
    }
        
    [HttpGet]
    public async Task<IActionResult> Edit(int SoldierId)
    {
        var soldierDetails = await wbAppDbContext.TblSoldierInfo.FirstOrDefaultAsync(x => x.SoldierId == SoldierId);
        if (soldierDetails != null)
        {
            var fillSoldierDetails = new UpdateSoldierViewModel()
            {
                FirstName = soldierDetails.FirstName,
                LastName = soldierDetails.LastName,
                DateOfBirth = soldierDetails.DateOfBirth,
                DateOfEnlistment = soldierDetails.DateOfEnlistment,
            };
            return View(fillSoldierDetails);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateSoldierViewModel updateSoldierRequest)
    {
        var soldierInfo = await wbAppDbContext.TblSoldierInfo.FindAsync(updateSoldierRequest.SoldierId);
        if (soldierInfo != null)
        {
            soldierInfo.FirstName = updateSoldierRequest.FirstName;
            soldierInfo.LastName = updateSoldierRequest.LastName;
            soldierInfo.DateOfBirth = updateSoldierRequest.DateOfBirth;
            soldierInfo.DateOfEnlistment = updateSoldierRequest.DateOfEnlistment;
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
        
    }

    public async Task<IActionResult> Delete(UpdateSoldierViewModel deleteSoldierRequest)
    {
        var soldierRecord = await wbAppDbContext.TblSoldierInfo.FindAsync(deleteSoldierRequest.SoldierId);
        if (soldierRecord != null)
        {
            wbAppDbContext.TblSoldierInfo.Remove(soldierRecord);
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }   
        return RedirectToAction("Index");
    }
}
