﻿using _2rpnet.rpa.webAPI.Contexts;
using _2rpnet.rpa.webAPI.Domains;
using _2rpnet.rpa.webAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace _2rpnet.rpa.webAPI.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DoisRPnetContext ctx;

        public PlayerRepository(DoisRPnetContext appContext)
        {
            ctx = appContext;
        }

        public Player Create(Player player)
        {
            ctx.Players.Add(player);
            ctx.SaveChangesAsync();

            return player;
        }

        public void Delete(Player player)
        {
            ctx.Players.Remove(player);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Player> ReadAll()
        {
            return ctx.Players.ToList();
        }

        public Player SearchByID(int id)
        {
            return ctx.Players.AsNoTracking().ToList().FirstOrDefault(p => p.IdPlayer == id);
        }

        public Player Update(Player player)
        {
            ctx.Entry(player).State = EntityState.Modified;
            ctx.SaveChangesAsync();

            return player;
        }
    }
}
