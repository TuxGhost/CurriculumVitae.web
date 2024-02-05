using CurriculumVitae.Model;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;

namespace CurriculumVitae.Services;

public class InternalCvService : ICvService
{
    private CvModel cvModels = null!;
    public InternalCvService()
    {
        cvModels = new CvModel
        {
            Profiel = "Profiel",
            Lijnen = new List<string> {
                "Ik ben een ervaren IT-er met een interesse  voor applicatie ontwikkeling en nieuwe technolgien",
                "Momenteel op zoek naar een nieuwe uitdaging waarbij ik mij momenteel concentreer op software ontwikkeling binnen de Microsoft Net omgeving"
            },
            Talen = new List<TaalModel> {
                new TaalModel {
                    Taal = "Nederlands",
                    Niveau = "Moedertaal"
                },
                new TaalModel {
                    Taal = "Engels",
                    Niveau = "Zeer goed"
                },
                new TaalModel {
                    Taal = "Frans",
                    Niveau = "Basis"
                },
                new TaalModel {
                    Taal = "Duits",
                    Niveau = "Basis"
                },
                new TaalModel {
                    Taal = "Kroatisch",
                    Niveau = "Basis"
                },
            },
            PersoonlijkeVaardigheden = new List<string>
            {
                "Analytisch", "Klantgereicht", "Leervermogen", "Onafhankelijk"
            },
            ComputerVaardigheden = new List<ComputerVaardigheid>
            {
                new ComputerVaardigheid {
                    Omschrijving = "Microsoft Office",
                    Niveau = "Goed",
                    Category = "Toepassingen"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Microsoft Windows",
                    Niveau = "Goed",
                    Category = "Toepassingen"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Bartender Designer",
                    Niveau = "Goed",
                    Category = "Toepassingen"
                },
                new ComputerVaardigheid {
                    Omschrijving = "ABAP",
                    Niveau = "Basis",
                    Category = "Backend Software ontwikkeling"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Adobe LiveCycle Designer",
                    Niveau = "Basis",
                    Category = "Font-end development"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Smartforms",
                    Niveau = "Goed",
                    Category = "Font-end development"
                },
                new ComputerVaardigheid {
                    Omschrijving = "VB Script",
                    Niveau = "Goed",
                    Category = "Backend Software ontwikkeling"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Visual Basis voor Applications",
                    Niveau = "Zeer goed",
                    Category = "Backend Software ontwikkeling"
                },
                new ComputerVaardigheid {
                    Omschrijving = "VB.NET",
                    Niveau = "Goed",
                    Category = "Backend Software ontwikkeling"
                },
                new ComputerVaardigheid {
                    Omschrijving = "C#",
                    Niveau = "Goed",
                    Category = "Backend Software ontwikkeling"
                },
                new ComputerVaardigheid {
                    Omschrijving = "HTML",
                    Niveau = "Goed",
                    Category = "Font-end development"
                },
                new ComputerVaardigheid {
                    Omschrijving = "CSS",
                    Niveau = "Goed",
                    Category = "Font-end development"
                },
                new ComputerVaardigheid {
                    Omschrijving = "SQL",
                    Niveau = "Goed",
                    Category = "Backend Software ontwikkeling"
                },
                new ComputerVaardigheid {
                    Omschrijving = "RPG 400",
                    Niveau = "Zeer goed",
                    Category = "Backend Software ontwikkeling"
                },
            },
            WerkErvaringen = new List<WerkErvaring>
            {
                new WerkErvaring
                {
                    Functie = "Functioneel SAP Consultant",
                    Bedrijf = "Delaware Belux",
                    DatumVan = new DateTime(2021,09,01),
                    DatumTot = new DateTime(2022,09,30),
                    Taken = new List<string>
                    {
                        "Ondersteuning Verkoop en verdeling, Materiaal beheer en EDI"
                    }
                },
                new WerkErvaring
                {
                    Functie = "Technisch Analist",
                    Bedrijf = "Nitto Belgie",
                    DatumVan = new DateTime(1997,10,01),
                    DatumTot = new DateTime(2021,03,17),
                    Taken = new List<string>
                    {
                        "SAP Support",
                        "SAP Authorisatie",
                        "SAP ABAP",
                        "SAP Smartforms",
                        "Adobe LiveCycle Designer",
                        "SAP PI",
                        "SAP RPG/400",
                        "Lotus Notes (Administratie en software ontwikkeling",
                        "Visual Basic.NET",
                        "Visual Basic 6"
                    }
                },
                new WerkErvaring
                {
                    Functie = "Software partner",
                    Bedrijf = "CODEAS",
                    DatumVan = new DateTime(2007,05,01),
                    DatumTot = new DateTime(2012,05,30),
                    Taken = new List<string>
                    {
                        "Microsoft Access applications voor verscheidene klanten",
                        "Excel templates onderhouden"
                    }
                },
                new WerkErvaring
                {
                    Functie = "IT Support Specialist",
                    Bedrijf = "IDE / Fabriekswinkel",
                    DatumVan = new DateTime(1997,01,01),
                    DatumTot = new DateTime(1997,02,28),
                    Taken = new List<string>
                    {
                        "Installatie van software in de verschillende vestigingen"
                    }
                },
                new WerkErvaring
                {
                    Functie = "IT Specialist",
                    Bedrijf = "V.M.W. (De Watergroep)",
                    DatumVan = new DateTime(1995,12,01),
                    DatumTot = new DateTime(1996,11,30),
                    Taken = new List<string>
                    {
                        "Software development in Filemaker Pro",
                        "Installatie en onderhoud computers"
                    }
                },
                new WerkErvaring
                {
                    Functie = "Software tester",
                    Bedrijf = "Philips FT",
                    DatumVan = new DateTime(1995,03,01),
                    DatumTot = new DateTime(1995,06,30),
                    Taken = new List<string>
                    {
                        "Testen van verschillende soorten toepassen geschreven voor CD-I"
                    }
                },
            }
        };
    }

    public void AddComputerServices(Data.Entities.ComputerVaardigheid computerVaardigheid)
    {
        throw new NotImplementedException();
    }

    public void AddLanguage(Data.Entities.TaalModel taal)
    {
        throw new NotImplementedException();
    }
  
    public void AddPersonalSkill(Data.Entities.PersoonlijkeVaardigheid vaardigheid)
    {
        throw new NotImplementedException();
    }

    public void AddWorkExperience(Data.Entities.WerkErvaring werkervaring)
    {
        throw new NotImplementedException();
    }
    public void AddWorkExperienceTask(int id, string taak)
    {
        throw new NotImplementedException();
    }

    public void DeleteComputerServices(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteLanguage(int id)
    {
        throw new NotImplementedException();
    }

    public void DeletePersonalSkillTask(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteWorkExpercience(int id)
    {
        throw new NotImplementedException();
    }

    public void DeleteWorkExperienceTask(int workexperienceId, string taak)
    {
        throw new NotImplementedException();
    }

    public CvModel GetCv()
    {
        return cvModels;
    }

    public void SetProfiel(string profiel)
    {
        throw new NotImplementedException();
    }
}
