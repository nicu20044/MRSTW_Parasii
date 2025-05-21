using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using MusicStore.BusinessLogic.Data;
using MusicStore.BusinessLogic.Services;
using MusicStore2.Domain.Entities.Product;
using MusicStore2.Domain.Entities.User;

namespace MusicStore.BusinessLogic.Core
{
    public class AdminApi
    {
        private readonly AppDbContext _context = new AppDbContext();

        internal async Task<AppUser> GetByIdAsync(int id)
        {
            var model = await _context.Users.FirstOrDefaultAsync(p => p.Id == id);

            if (model != null)
            {
                return model;
            }

            return model;
        }


        internal IEnumerable<AppUser> GetAll()
        {
            return _context.Users.AsNoTracking().ToList();
        }

        internal async Task UpdateUserAsync(AppUser user)
        {
            if (user == null)
                throw new ArgumentException("Utilizatorul nu poate fi null.");

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (existingUser == null)
                throw new InvalidOperationException("Utilizatorul nu a fost găsit.");

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.UserRole = user.UserRole;
            

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        internal Task CreateAsync(AppUser userData)
        {
            if (userData == null)
            {
                throw new ArgumentException("Product cannot be null");
            }


            _context.Users.Add(userData);
            _context.SaveChanges();
            return Task.CompletedTask;
        }
        
        internal async Task DeleteAsync(int userid)
        {
            var entity = await  _context.Users.FirstOrDefaultAsync(p => p.Id == userid);;
            if (entity == null)
            {
                throw new ArgumentException("User not found");
            }
        
            _context.Users.Remove(entity);
        }

        internal async Task Save()
        { 
            _context.SaveChanges();
        }
        
        public async Task UpdateUserRoleAsync(string email, string newRole)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email-ul nu poate fi gol.");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                throw new InvalidOperationException("Utilizatorul nu a fost găsit.");

            user.UserRole = newRole;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}