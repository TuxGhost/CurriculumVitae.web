using CurriculumVitae.Model;
using CurriculumVitae.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumVitae.Areas.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumVitaeController : ControllerBase
    {
        private ICvService cvService;        
        public CurriculumVitaeController(ICvService cvService)
        {
            this.cvService = cvService;
        }
        [HttpGet("cv")]
        public IActionResult Index()
        {                        
            CvModel cv = cvService.GetCv();
            return Ok(cv);
        }
        public override OkResult Ok()
        {
            return base.Ok();
        }
        [HttpGet("personalskills")]
        public IActionResult PersonalSkills()
        {
            CvModel cv = cvService.GetCv();
            List<string> items = new();
            foreach(var item in cv.PersonalSkills)
            {
                items.Add(item.Name);
            }
            return base.Ok(items);
        }
    }
}
