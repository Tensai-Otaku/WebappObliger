﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppeoppgave1.DAL;
using Gruppeoppgave1.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Gruppeoppgave1.DAL
{
    public class BestillingRepository : IBestillingRepository
    {
        private readonly BestillingContext _db;

        public BestillingRepository(BestillingContext db)
        {
            _db = db;
        }


        public async Task<bool> Lagre(Bestilling innBestilling)
        {
            try
            {
                var nyBestillingRad = new Bestillinger();
                nyBestillingRad.Pris = innBestilling.pris;
                nyBestillingRad.Fra = innBestilling.Fra;
                nyBestillingRad.Til = innBestilling.Til;
                nyBestillingRad.Dato = innBestilling.Dato;
                nyBestillingRad.Tid = innBestilling.Tid;
                _db.Bestillinger.Add(nyBestillingRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Bestilling>> HentAlle()
        {
            try
            {
                List<Bestilling> alleBestillinger = await _db.Bestillinger.Select(b => new Bestilling
                {
                    Id = b.Id,
                    pris = b.Pris,
                    Fra = b.Fra,
                    Til = b.Til,
                    Dato = b.Dato,
                    Tid = b.Tid
                }).ToListAsync();
                
                return alleBestillinger;
            }
            catch
            {
                return null;
            }  
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Bestillinger enDBBestilling = await _db.Bestillinger.FindAsync(id);
                _db.Bestillinger.Remove(enDBBestilling);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Bestilling> HentEn(int id)
        {
            try
            {
                Bestillinger enBestilling = await _db.Bestillinger.FindAsync(id);
                var hentetBestilling = new Bestilling()
                {
                    Id = enBestilling.Id,
                    pris = enBestilling.Pris,
                    Fra = enBestilling.Fra,
                    Til = enBestilling.Til,
                    Dato = enBestilling.Dato,
                    Tid = enBestilling.Tid
                };
                return hentetBestilling;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Endre(Bestilling endreBestilling)
        {
            try
            {
                var endreObjekt = await _db.Bestillinger.FindAsync(endreBestilling.Id);
                endreObjekt.Pris = endreBestilling.pris;
                endreObjekt.Fra = endreBestilling.Fra;
                endreObjekt.Til = endreBestilling.Til;
                endreObjekt.Dato = endreBestilling.Dato;
                endreObjekt.Tid = endreBestilling.Tid;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
            
        }
    }
}
