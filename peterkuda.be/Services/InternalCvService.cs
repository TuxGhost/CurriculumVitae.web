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
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Microsoft Windows",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Bartender Designer",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "ABAP",
                    Niveau = "Basis"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Adobe LiveCycle Designer",
                    Niveau = "Basis"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Adobe LiveCycle Designer",
                    Niveau = "Basis"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Smartforms",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "VB Script",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "Visual Basis voor Applications",
                    Niveau = "Zeer goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "VB.NET",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "C#",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "HTML",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "CSS",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "SQL",
                    Niveau = "Goed"
                },
                new ComputerVaardigheid {
                    Omschrijving = "RPG 400",
                    Niveau = "Zeer goed"
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
                    Functie = "Software tester",
                    Bedrijf = "Phiips FT",
                    DatumVan = new DateTime(1995,03,01),
                    DatumTot = new DateTime(1995,06,30),
                    Taken = new List<string>
                    {
                        "Ondersteuning Verkoop en verdeling, Materiaal beheer en EDI"
                    }
                },
            }
        };
    }

    public CvModel GetCv()
    {
        return cvModels;
    }
}
