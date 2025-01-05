using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoldierMgtSys.Data;
using SoldierMgtSys.Models;

namespace SoldierMgtSys.Controllers;

public class DeploymentController : Controller
{
    private readonly WebAppDbContext wbAppDbContext;
    
    public DeploymentController(WebAppDbContext wbAppDbContext)
    {
        this.wbAppDbContext = wbAppDbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Add(AddDeploymentViewModel addDeploymentRequest)
    {
        var deploymentModel = new Deployment()
        {
            DeploymentId = addDeploymentRequest.DeploymentId,
            DeploymentLocation = addDeploymentRequest.DeploymentLocation,
            DeploymentStartDate = addDeploymentRequest.DeploymentStartDate,
            DeploymentEndDate = addDeploymentRequest.DeploymentEndDate,
            SoldierId = addDeploymentRequest.SoldierId,
        };
        await wbAppDbContext.TblDeployments.AddAsync(deploymentModel);
        await wbAppDbContext.SaveChangesAsync();
        
        return RedirectToAction("Add");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var deploymentList = await wbAppDbContext.TblDeployments.ToListAsync();
        return View(deploymentList);
    }
        
    [HttpGet]
    public async Task<IActionResult> EditDeployment(int DeploymentID)
    {
        var deploymentDetails = await wbAppDbContext.TblDeployments.FirstOrDefaultAsync(x => x.DeploymentId == DeploymentID);
        if (deploymentDetails != null)
        {
            var fillDeploymentDetails = new UpdateDeploymentViewModel()
            {
                DeploymentId = deploymentDetails.DeploymentId, 
                DeploymentLocation = deploymentDetails.DeploymentLocation,
                DeploymentStartDate = deploymentDetails.DeploymentStartDate,
                DeploymentEndDate = deploymentDetails.DeploymentEndDate,
                SoldierId = deploymentDetails.SoldierId 
            };
            return View("EditDeployment",fillDeploymentDetails);
        }
        return RedirectToAction("Index", "Deployment");
    }

    [HttpPost]
    public async Task<IActionResult> EditDeployment(UpdateDeploymentViewModel updateDeploymentRequest)
    {
        if (!ModelState.IsValid) 
        {
            return View(updateDeploymentRequest);
        }

        var deploymentInfo = await wbAppDbContext.TblDeployments.FindAsync(updateDeploymentRequest.DeploymentId);
        if (deploymentInfo != null)
        {
            deploymentInfo.DeploymentLocation = updateDeploymentRequest.DeploymentLocation;
            deploymentInfo.DeploymentStartDate = updateDeploymentRequest.DeploymentStartDate;
            deploymentInfo.DeploymentEndDate = updateDeploymentRequest.DeploymentEndDate;
        
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Soldier"); 
        }
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> DeleteDeployment(UpdateDeploymentViewModel deleteDeploymentRequest)
    {
        var deploymentRecord = await wbAppDbContext.TblDeployments.FindAsync(deleteDeploymentRequest.DeploymentId);
        if (deploymentRecord != null)
        {
            wbAppDbContext.TblDeployments.Remove(deploymentRecord);
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }   
        return RedirectToAction("Index");
    }
}
