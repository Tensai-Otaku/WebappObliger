﻿using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gruppeoppgave1.Model;
using Microsoft.EntityFrameworkCore;

namespace Gruppeoppgave1.DAL
{
    public class AvgangRepository : IAvgangerRepository
    {
        private readonly BestillingContext _db;

        public AvgangRepository(BestillingContext db)
        {
            _db = db;
        }

        public async Task<List<Avgang>> HentAlle()
        {
            try
            {
                List<Avgang> alleAvganger = await _db.Avganger.Select(a => new Avgang
                {
                    Id = a.Id,
                    Fra = a.Fra.StasjonsNavn

                }).ToListAsync();
                return alleAvganger;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Avganger> HentEn(int id)
        {
            Avganger enAvgang = await _db.Avganger.FindAsync(id);
            var hentetAvgang = new Avganger()
            {
                Id = enAvgang.Id,

            };
            return hentetAvgang;
        }

    }
}
