using CurriculumVitae.Model;
using CurriculumVitae.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace peterkuda.be.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICvService cvService;
    [BindProperty]
    public CvModel cv { get; private set; } = null!;
    [BindProperty]
    public TaalModel Taal { get; private set; } = null!;
    [BindProperty]
    public ComputerVaardigheid ComputerVaardigheid { get; private set; } = null!;
    [BindProperty]
    public WerkErvaring WerkErvaring { get; private set; } = null!;
    [BindProperty]
    public bool Editable { get; set; } = false;

    public IndexModel(ILogger<IndexModel> logger, ICvService cvService)
    {
        _logger = logger;
        this.cvService = cvService;
        cv = cvService.GetCv();
    }

    public void OnGet()
    {
        cv = this.cv;
    }
    public void OnPost()
    {

    }
    public IActionResult OnPostEdit(string editable, string profiel)
    {
        //cv.Profiel = Request.Form["profiel"];

        if (Editable)
        {
            Editable = false;
        }
        else
        {
            Editable = true;
        }
        cv.Editable = true;
        return Page();
    }
    public IActionResult OnPostProfiel(CvModel cv)
    {
        if (cv != null)
        {
            cvService.SetProfiel(cv.Profiel!);
        }
        return Page();
    }
    public IActionResult OnPostAddlanguage(TaalModel taal)
    {        
        cvService.AddLanguage(new CurriculumVitae.Data.Entities.TaalModel
        {
            Taal = taal.Taal,
            Niveau = taal.Niveau,
        });
        return Page();
    }
    public IActionResult OnPostAddcomputerskill(ComputerVaardigheid computervaardigheid)
    {
        cvService.AddComputerServices(new CurriculumVitae.Data.Entities.ComputerVaardigheid
        {
            Category = " ",
            Niveau = computervaardigheid.Niveau,
            Omschrijving = computervaardigheid.Omschrijving
        });
        return Page();
    }
    public IActionResult OnPostAddWorkExperience(WerkErvaring werkervaring)
    {
        cvService.AddWorkExperience(new CurriculumVitae.Data.Entities.WerkErvaring
        {
            Bedrijf = werkervaring.Bedrijf,
            Functie = werkervaring.Functie,
            DatumVan = werkervaring.DatumVan,
            DatumTot = werkervaring.DatumTot
        });
        return Page();
    }
    public IActionResult OnPostAddWorkExperienceTask(int id, string taak)
    {
        cvService.AddWorkExperienceTask(id, taak);
        return Page();
    }
    public IActionResult OnPostDeleteWorkExperience(int id)
    {
        cvService.DeleteWorkExpercience(id);
        return Page();
    }
    public IActionResult OnPostDeleteWorkExperienceTask(int workexperienceId, string taak)
    {
        cvService.DeleteWorkExperienceTask(workexperienceId, taak);
        return Page();
    }
}