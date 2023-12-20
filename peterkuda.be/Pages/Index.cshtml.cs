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
    public void OnPostEdit(string editable, string profiel)
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
    }
    public void OnPostProfiel(CvModel cv)
    {
        if (cv != null)
        {
            cvService.SetProfiel(cv.Profiel!);
        }
    }
    public void OnPostAddlanguage(TaalModel taal)
    {
        cvService.AddLanguage(new CurriculumVitae.Data.Entities.TaalModel
        {
            Taal = taal.Taal,
            Niveau = taal.Niveau,   
        });
    }
    public void OnPostAddcomputerskill(ComputerVaardigheid computervaardigheid)
    {
        cvService.AddComputerServices(new CurriculumVitae.Data.Entities.ComputerVaardigheid
        {
            Category =" ",
            Niveau = computervaardigheid.Niveau,
            Omschrijving = computervaardigheid.Omschrijving
        });
    }
    public void OnPostAddWorkExperience(WerkErvaring werkervaring)
    {
        cvService.AddWorkExperience(new CurriculumVitae.Data.Entities.WerkErvaring
        {
             Bedrijf = werkervaring.Bedrijf,
             Functie = werkervaring.Functie,
             DatumVan = werkervaring.DatumVan,
             DatumTot = werkervaring.DatumTot             
        });
    }
    public void OnPostAddWorkExperienceTask(int id,string taak)
    {
        cvService.AddWorkExperienceTask(id, taak);
    }
    public void OnPostDeleteWorkExperience(int id)
    {
        cvService.DeleteWorkExpercience(id);
    }
    public void OnPostDeleteWorkExperienceTask(int workexperienceId, string taak)
    {
        cvService.DeleteWorkExperienceTask(workexperienceId, taak);
    }
}