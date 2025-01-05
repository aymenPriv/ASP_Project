using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoldierMgtSys.Data;
using SoldierMgtSys.Models;

namespace SoldierMgtSys.Controllers;

public class AssignmentController : Controller
{
    private readonly WebAppDbContext wbAppDbContext;
    
    public AssignmentController(WebAppDbContext wbAppDbContext)
    {
        this.wbAppDbContext = wbAppDbContext;
    }
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(AddAssignmentViewModel addAssignmentRequest)
    {
        var assignmentModel = new Assignment()
        {
            AssignmentId = addAssignmentRequest.AssignmentId,
            AssignmentDetails = addAssignmentRequest.AssignmentDetails,
            StartDate = addAssignmentRequest.StartDate,
            EndDate = addAssignmentRequest.EndDate,
            SoldierId = addAssignmentRequest.SoldierId
        };
        await wbAppDbContext.TblAssignments.AddAsync(assignmentModel);
        await wbAppDbContext.SaveChangesAsync();
        
        return RedirectToAction("Add");
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var assignmentList = await wbAppDbContext.TblAssignments.ToListAsync();
        return View(assignmentList);
    }
    
    [HttpGet]
    public async Task<IActionResult> Edit(int AssignmentId)
    {
        var assignmentDetails = await wbAppDbContext.TblAssignments.FirstOrDefaultAsync(x => x.AssignmentId == AssignmentId);
        if (assignmentDetails != null)
        {
            var fillAssignmentDetails = new UpdateAssignmentViewModel()
            {
                AssignmentDetails = assignmentDetails.AssignmentDetails,
                StartDate = assignmentDetails.StartDate,
                EndDate = assignmentDetails.EndDate,
            };
            return View(fillAssignmentDetails);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateAssignmentViewModel updateAssignmentRequest)
    {
        var assignmentInfo = await wbAppDbContext.TblAssignments.FindAsync(updateAssignmentRequest.AssignmentId);
        if (assignmentInfo != null)
        {
            assignmentInfo.AssignmentDetails = updateAssignmentRequest.AssignmentDetails;
            assignmentInfo.StartDate = updateAssignmentRequest.StartDate;
            assignmentInfo.EndDate = updateAssignmentRequest.EndDate;
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
        
    }

    public async Task<IActionResult> Delete(UpdateAssignmentViewModel deleteAssignmentRequest)
    {
        var assignmentRecord = await wbAppDbContext.TblAssignments.FindAsync(deleteAssignmentRequest.AssignmentId);
        if (assignmentRecord != null)
        {
            wbAppDbContext.TblAssignments.Remove(assignmentRecord);
            await wbAppDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }   
        return RedirectToAction("Index");
    }
}
