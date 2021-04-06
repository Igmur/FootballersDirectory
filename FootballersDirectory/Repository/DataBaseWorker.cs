using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using FootballersDirectory.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballersDirectory.Repository
{
    public class DataBaseWorker : IDataBaseWorker
    {
        private ApplicationContext db;

        public DataBaseWorker(ApplicationContext context)
        {
            db = context;
        }

        public async Task CreateFootballer(FootballerEntity footballer)
        {
            var gender = db.Genders.Where(x => x.GenderName == footballer.Gender.GenderName).FirstOrDefault();
            if (gender != null)
            {

                footballer.Gender = gender;
            }

            var command = db.Commands.Where(x => x.CommandName == footballer.Command.CommandName).FirstOrDefault();
            if (command != null)
            {

                footballer.Command = command;
            }

            db.Footballers.Add(footballer);
            await db.SaveChangesAsync();
        }

        public async Task<List<FootballerEntity>> GetAllFootballers()
        {
            var footballers = await db.Footballers.Include(x => x.Command).Include(x => x.Gender).ToListAsync();
            return footballers;
        }


        public List<string> GetAllCommands()
        {
            var commands = (from c in db.Commands
                            select c.CommandName).ToList();
            return commands;
        }

        public List<string> GetAllGenders()
        {
            var genders = (from g in db.Genders
                           select g.GenderName).ToList();
            return genders;
        }

        public async Task<FootballerEntity> EditFootballer(int? id)
        {
            FootballerEntity footballer = await db.Footballers
                .Include(x => x.Command)
                .Include(x => x.Gender)
                .FirstOrDefaultAsync(f => f.Id == id);
            return footballer;
        }

        public async Task EditConfirm(FootballerEntity footballer)
        {
            var gender = db.Genders.Where(x => x.GenderName == footballer.Gender.GenderName).FirstOrDefault();
            if (gender != null)
            {

                footballer.Gender = gender;
            }

            var command = db.Commands.Where(x => x.CommandName == footballer.Command.CommandName).FirstOrDefault();
            if (command != null)
            {

                footballer.Command = command;
            }

            db.Footballers.Add(footballer);

            db.Footballers.Update(footballer);
            await db.SaveChangesAsync();
        }

        public async Task DeleteFootballerById(int? id)
        {
            FootballerEntity footballer = await db.Footballers
                .Include(x => x.Command)
                .Include(x => x.Gender)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (footballer != null)
            {
                db.Footballers.Remove(footballer);
                await db.SaveChangesAsync();
            }
        }
    }
}
