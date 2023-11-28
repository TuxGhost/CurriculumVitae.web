using CurriculumVitae.Model;

namespace CurriculumVitae.Services;

public class SQLiteCvService : ICvService
{
    private CvModel cvModels = null!;
    public CvModel GetCv()
    {
        return cvModels;
    }
}
