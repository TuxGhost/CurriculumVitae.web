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
    public bool Editable { get; set; } = false;

    public IndexModel(ILogger<IndexModel> logger,ICvService cvService)  
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
    public void OnPostEdit(string editable,string profiel)
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
        cv.Editable=true;        
    }               
    public void OnPostProfiel(CvModel cv)
    {
        
    }
}