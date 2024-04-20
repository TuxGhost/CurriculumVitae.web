using CurriculumVitae.Model;
using CurriculumVitae.pdfSharp;
using CurriculumVitae.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MigraDoc.Rendering;

namespace CurriculumVitae.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICvService cvService;
    [BindProperty()] 
    public CvModel cv { get; private set; } = null!;
    [BindProperty]
    public TaalModel Taal { get; private set; } = null!;
    [BindProperty]
    public ComputerVaardigheid ComputerVaardigheid { get; private set; } = null!;
    [BindProperty]
    public WerkErvaring WerkErvaring { get; private set; } = null!;
    [BindProperty]
    public PersonalSkill persoonlijkeVaardigheid { get; private set; } = null!;
    [BindProperty]
    public bool Editable { get; set; } = false;
    [BindProperty]
    public bool AddLanguage { get; set; } = false;
    [BindProperty]
    public bool AddComputerVaardigheid { get; set; } = false;
    [BindProperty(SupportsGet = true)]
    public string? Profiel { get; set; }
    
    public IndexModel(ILogger<IndexModel> logger, ICvService cvService)
    {
        _logger = logger;
        this.cvService = cvService;
        cv = cvService.GetCv();
    }

    public IActionResult OnGet()
    {
        try
        {
            cv = this.cv;
            this.Profiel = cv.Profiel;
        } catch(Exception ex)
        {
            _logger.LogError(ex.Message);            
        }
        return Page();
    }
    public void OnPost()
    {

    }
    public IActionResult OnPostEdit(string editable, string profiel)
    {
        //cv.Profiel = Request.Form["profiel"];
        this.Profiel = cv.Profiel;
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
            cvService.SetProfiel(Profiel!);            
        }
        return Page();
    }
    public IActionResult OnPostAddlanguage(TaalModel taal)
    {
        if (!AddLanguage && !taal.AddData)
        {
            AddLanguage = true;
            return Page();
        }
        if (taal.AddData)
        {
            cvService.AddLanguage(new CurriculumVitae.Data.Entities.TaalModel
            {
                Taal = taal.Taal,
                Niveau = taal.Niveau,
            });
        }        
        return Page();
    }
    /// <summary>
    /// Add new computer skill after posting
    /// </summary>
    /// <param name="computervaardigheid"></param>
    /// <returns></returns>
    public IActionResult OnPostAddcomputerskill(ComputerVaardigheid computervaardigheid)
    {
        if(!AddComputerVaardigheid && !computervaardigheid.AddData)
        {
            AddComputerVaardigheid = true;
            return Page();
        }
        if (computervaardigheid.AddData)
        {
            cvService.AddComputerServices(new CurriculumVitae.Data.Entities.ComputerVaardigheid
            {
                Category = " ",
                Niveau = computervaardigheid.Niveau,
                Omschrijving = computervaardigheid.Omschrijving
            });
        }        
        return Page();
    }
    /// <summary>
    /// Remove computer skill from list
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IActionResult OnPostDeletecomputerskill(int id)
    {        
        cvService.DeleteComputerSkill(id);                
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
    public IActionResult OnPostDownload()
    {
        /*PdfDocument doc = new PdfDocument();        
        PdfPage page = doc.AddPage();
        XSize size = PageSizeConverter.ToSize(PdfSharp.PageSize.A4);
        page.Width = size.Width;
        page.Height= size.Height;
        page.TrimMargins.Top = 5;
        page.TrimMargins.Bottom = 5;
        page.TrimMargins.Left = 5;
        page.TrimMargins.Right = 5;        
        var memoryStream = new MemoryStream();
        doc.Save(memoryStream, false);
        return File(memoryStream.ToArray(),"application/pdf","cvPeterKuda.pdf") ;        */
        //CVDocument cVDocument = new CVDocument(this.cvService.get)
        var document = CVDocument.CreateDocument(cvService.GetCv());
        //var ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
        //MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "migradoc.mdd1");
        var renderer = new PdfDocumentRenderer
        {
            Document = document
        };
        renderer.RenderDocument();
        var memoryStream = new MemoryStream();
        renderer.PdfDocument.Save(memoryStream);
        return File(memoryStream.ToArray(), "application/pdf", "cvPeterKuda.pdf");
    }

    public IActionResult OnPostAddSkill(PersonalSkill persoonlijkevaardigheid)
    {
        cvService.AddPersonalSkill(new CurriculumVitae.Data.Entities.PersoonlijkeVaardigheid
        {
            Name = persoonlijkevaardigheid.Name,
        });
        return Page();
    }
    public IActionResult OnPostUpdatePersonalSkill([FromBody] PersonalSkill personalSkill)
    {
        cvService.UpdatePersonalSkill(personalSkill);
        return new OkResult();
    }
    public IActionResult OnPostDeletePersonalSkill([FromBody] PersonalSkill personalSkill)
    {
        cvService.DeletePersonalSkill(personalSkill);
        return new OkResult();
    }
    public IActionResult OnPostRemoveItem(int id)
    {        
        cvService.DeleteLanguage(id);
        return Page();
    }
}