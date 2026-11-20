using CurriculumVitae.common.Services;
using CurriculumVitae.common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
namespace CurriculumVitae.Web.Pages;

//[Authorize]
public partial class JobApplications : PageModel
{
    private readonly ICurriculumVitaeService curriculumVitaeService;
    private readonly IJobApplicationService jobApplicationService;
    [BindProperty]
    public bool IsAddingMode { get; set; } 
    [BindProperty]
    public bool Editable { get; set; } = false;
    [BindProperty]
    public uint IdChange { get; set; } 
    [BindProperty]
    public CvDto cv { get; private set; } = null!;
    [BindProperty]
    public List<JobApplicationDto>? JobApplicationList { get; private set; } 

    public JobApplications(IJobApplicationService jas)
    {
        //curriculumVitaeService = cv;
        //cv = curriculumVitaeService.;        
        jobApplicationService = jas;
        JobApplicationList = new List<JobApplicationDto>(); 
    }
    public async Task<IActionResult> OnGet()
    {
        JobApplicationList = jobApplicationService.GetAll();
        return Page();        
    }
    public IActionResult OnPostAddrequest()
    {        
        IsAddingMode = true;
        return Page();   
    }
    public async Task<IActionResult> OnPostAdd(JobApplicationDto jobApplication)
    {
        jobApplicationService.Add(jobApplication);
        return Page();
    }
    public async Task<IActionResult> OnPostDelete(uint id)
    {
        await jobApplicationService.Delete(id);
        JobApplicationList = jobApplicationService.GetAll();
        return Page();
    } 
    public IActionResult OnPostEdit(uint id)
    {       
        IdChange = id;
        JobApplicationList = jobApplicationService.GetAll();
        return Page();
    }
    public async Task<IActionResult> OnPostUpdate(JobApplicationDto jobApplication)
    {
        JobApplicationList = jobApplicationService.GetAll();
        await jobApplicationService.Update(jobApplication);
        return Page();
    }
}

