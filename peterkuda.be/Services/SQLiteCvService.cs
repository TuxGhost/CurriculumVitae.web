using CurriculumVitae.Data;
using CurriculumVitae.Data.Entities;
using CurriculumVitae.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CurriculumVitae.Services;

public class SQLiteCvService : ICvService
{
    private CvModel cvModels = null!;
    private CurriculumVitaeDbContext dbContext = null!;
    public SQLiteCvService(CurriculumVitaeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public CvModel GetCv()
    {        
        if(cvModels == null)
        {
            cvModels = new CvModel();
            Profiel? profiel = dbContext.Profielen.FirstOrDefault();
            if(profiel != null)
            {
                cvModels.Profiel = profiel.Beschrijving;
            }
        }
        return cvModels;
    }

    public void SetProfiel(string profiel)
    {
        if(profiel  != null)
        {
            Profiel? profielObject = dbContext.Profielen.FirstOrDefault();
            if (profielObject == null)
            {
                profielObject = new Profiel();
                profielObject.Beschrijving = profiel;
                _ = dbContext.Profielen.Add(profielObject);
            }
            else
            {
                profielObject.Beschrijving = profiel;
                _ = dbContext.Profielen.Update(profielObject);
            }
            _ = dbContext.SaveChanges();
        }        
    }
}
