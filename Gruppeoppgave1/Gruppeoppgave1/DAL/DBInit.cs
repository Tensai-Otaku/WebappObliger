using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppeoppgave1.Model
{
    [ExcludeFromCodeCoverage]
    public static class DBInit
    {
        public static void Initialize(IServiceScope serviceScope)
        {
            var context = serviceScope.ServiceProvider.GetService<BestillingContext>();

            // m� slette og opprette databasen hver gang n?r den skalinitieres (seed`es)
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();




            var stasjonerList = new List<Stasjoner>
            {
                new Stasjoner { StasjonsNavn = "Oslo", NummerPaaStopp = int.Parse("1") },
                new Stasjoner { StasjonsNavn = "Sandvika", NummerPaaStopp = int.Parse("2") },
                new Stasjoner { StasjonsNavn = "Asker", NummerPaaStopp = int.Parse("3") },
                new Stasjoner { StasjonsNavn = "Drammen", NummerPaaStopp = int.Parse("4") },
                new Stasjoner { StasjonsNavn = "Skoger", NummerPaaStopp = int.Parse("5") },
                new Stasjoner { StasjonsNavn = "Sande", NummerPaaStopp = int.Parse("6") },
                new Stasjoner { StasjonsNavn = "Holmestrand", NummerPaaStopp = int.Parse("7") },
                new Stasjoner { StasjonsNavn = "Kopstadkrysset", NummerPaaStopp = int.Parse("8") },
                new Stasjoner { StasjonsNavn = "Horten", NummerPaaStopp = int.Parse("9") }
            };

            var avgang1 = new Avganger
            {
                Fra = stasjonerList[0].StasjonsNavn,
                Til = stasjonerList[1].StasjonsNavn,
                Tid = "07:00"
            };
            var avgang2 = new Avganger
            {
                Fra = stasjonerList[3].StasjonsNavn,
                Til = stasjonerList[4].StasjonsNavn,
                Tid = "08:00"
            };

            var bestilling1 = new Bestillinger { Fra = "Oslo", Til = "Drammen", Tid = "07:00", Pris = double.Parse("50"), Dato = "01.01.2021" };
            var bestilling2 = new Bestillinger { Fra = "Drammen", Til = "Horten", Tid = "08:00", Pris = double.Parse("50"), Dato = "02.01.2021" };

            foreach (Stasjoner s in stasjonerList)
            {
                context.Stasjoner.Add(s);
            }
            /*
            context.Stasjoner.Add(stasjon1);
            context.Stasjoner.Add(stasjon2);
            context.Stasjoner.Add(stasjon3);
            */
            context.Avganger.Add(avgang1);
            context.Avganger.Add(avgang2);
            context.Bestillinger.Add(bestilling1);
            context.Bestillinger.Add(bestilling2);

            context.SaveChanges();

        }
    }

}
