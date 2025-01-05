using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoldierMgtSys.Data;
using SoldierMgtSys.Models;

namespace SoldierMgtSys.Controllers;

public class UnitController : Controller
{
    private readonly WebAppDbContext wbAppDbContext;
    
    public UnitController(WebAppDbContext wbAppDbContext)
    {
        this.wbAppDbContext = wbAppDbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddUnitViewModel addUnitRequest)
    {
        var unitModel = new Unit()
        {
            UnitId = addUnitRequest.UnitId,
            UnitName = addUnitRequest.UnitName,
            Location = addUnitRequest.Location,
        
        };
        await wbAppDbContext.TblUnits.AddAsync(unitModel);
        await wbAppDbContext.SaveChangesAsync();
        
        return RedirectToAction("Add");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var unitList = await wbAppDbContext.TblUnits.ToListAsync();
        return View(unitList);
    }
        
    [HttpGet]
    public async Task<IActionResult> Edit(int UnitId)
    {
        var unitDetails = await wbAppDbContext.TblUnits.FirstOrDefaultAsync(x => x.UnitId == UnitId);
        if (unitDetails != null)
        {
            var fillUnitDetails = new UpdateUnitViewModel()
            {
                UnitName = unitDetails.UnitName,
                Location = unitDetails.Location,
                
            };
            return View(fillUnitDetails);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UpdateUnitViewModel updateUnitViewModel)
    {
        var unitInfo = await wbAppDbContext.TblUnits.FindAsync(updateUnitViewModel.UnitId);
        if (unitInfo != null)
        {
            unitInfo.UnitName = updateUnitViewModel.UnitName;
            unitInfo.Location = updateUnitViewModel.Location;
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
        
    }

    public async Task<IActionResult> Delete(UpdateUnitViewModel deleteUnitRequest)
    {
        var unitRecord = await wbAppDbContext.TblUnits.FindAsync(deleteUnitRequest.UnitId);
        if (unitRecord != null)
        {
            wbAppDbContext.TblUnits.Remove(unitRecord);
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }   
        return RedirectToAction("Index");
    }
}
