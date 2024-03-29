﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {

        private BowlerDbContext _context { get; set; }


        public EFBowlersRepository(BowlerDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;



        public void Add(Bowler bowler)
        {
            _context.Add(bowler);
            _context.SaveChanges();
        }
        public void Edit(Bowler bowler)
        {
            _context.Update(bowler);
            _context.SaveChanges();
        }
        public void Delete(Bowler bowler)
        {
            _context.Remove(bowler);
            _context.SaveChanges();
        }

        public List<Bowler> GetBowlersFiltered(int teamId)
        {
            if (teamId != 0)
            {
                return _context.Bowlers.Where(b => b.TeamID == teamId).ToList();
            }
            else
            {
                return _context.Bowlers.ToList();
            }
        }
    }
}