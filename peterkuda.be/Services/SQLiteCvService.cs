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
            foreach(var taal in dbContext.Talen)
            {
                cvModels.Talen.Add(new Model.TaalModel { Taal = taal.Taal , Niveau = taal.Niveau });
            }
            foreach(var computervaardigheid in dbContext.computerVaardigheiden)
            {
                cvModels.ComputerVaardigheden.Add(new Model.ComputerVaardigheid
                {
                    Category = computervaardigheid.Category,
                    Niveau = computervaardigheid.Niveau,
                    Omschrijving = computervaardigheid.Omschrijving
                });
            }
            foreach(var werkervaring in dbContext.WerkErvaringen)
            {
                cvModels.WerkErvaringen.Add(new Model.WerkErvaring
                {
                     Bedrijf = werkervaring.Bedrijf,
                     DatumVan = werkervaring.DatumVan,
                     DatumTot = werkervaring.DatumTot,
                     Functie = werkervaring.Functie,                     
                });
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
    public void AddLanguage(Data.Entities.TaalModel taal) 
    {
        dbContext.Talen.Add(taal);
        dbContext.SaveChanges();
    }

    public void AddWorkExperience(Data.Entities.WerkErvaring werkervaring)
    {
        dbContext.WerkErvaringen.Add(werkervaring);
        dbContext.SaveChanges();
    }

    public void AddComputerServices(Data.Entities.ComputerVaardigheid computerVaardigheid)
    {
        dbContext.computerVaardigheiden.Add(computerVaardigheid); 
        dbContext.SaveChanges();
    }
}
