using CurriculumVitae.Data;
using CurriculumVitae.Model;
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
        }
        return cvModels;
    }

    public void SetProfiel(string profiel)
    {
        throw new NotImplementedException();
    }
}
