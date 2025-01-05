using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoldierMgtSys.Data;
using SoldierMgtSys.Models;

namespace SoldierMgtSys.Controllers;

public class RankController : Controller
{
    private readonly WebAppDbContext wbAppDbContext;
    
    public RankController(WebAppDbContext wbAppDbContext)
    {
        this.wbAppDbContext = wbAppDbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddRankViewModel addRankRequest)
    {
        var rankModel = new Rank()
        {
            RankId = addRankRequest.RankId,
            RankName = addRankRequest.RankName,
            
        };
        await wbAppDbContext.TblRanks.AddAsync(rankModel);
        await wbAppDbContext.SaveChangesAsync();
        
        return RedirectToAction("Add");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var rankList = await wbAppDbContext.TblRanks.ToListAsync();
        return View(rankList);
    }
        
    [HttpGet]
    public async Task<IActionResult> Edit(int RankId)
    {
        var rankDetails = await wbAppDbContext.TblRanks.FirstOrDefaultAsync(x => x.RankId == RankId);
        if (rankDetails != null)
        {
            var fillRankDetails = new UpdateRankViewModel()
            {
                RankName = rankDetails.RankName,
            };
            return View(fillRankDetails);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateRankViewModel updateRankRequest)
    {
        var rankInfo = await wbAppDbContext.TblRanks.FindAsync(updateRankRequest.RankId);
        if (rankInfo != null)
        {
            rankInfo.RankName = updateRankRequest.RankName;
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
        
    }

    public async Task<IActionResult> Delete(UpdateRankViewModel deleteRankRequest)
    {
        var rankRecord = await wbAppDbContext.TblRanks.FindAsync(deleteRankRequest.RankId);
        if (rankRecord != null)
        {
            wbAppDbContext.TblRanks.Remove(rankRecord);
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }   
        return RedirectToAction("Index");
    }
}
