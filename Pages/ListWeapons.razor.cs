using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Pages
{
    public partial class ListWeapons
    {

        public bool ShowCreate { get; set; }
        public bool EditRecord { get; set; }

        private AuthDbContext? _context;


        public Weapon? WeaponToUpdate { get; set; }

        private List<Weapon> OurWeapons;
        public async Task ShowWeapon()
        {
            _context ??= await AuthDbContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                OurWeapons = await _context.Weapons.ToListAsync();
            }

        }
        protected override async void OnInitialized()
        {
            await ShowWeapon();
        }

        public async Task ShowEditForm(Weapon OurWeapon)
        {
            _context ??= await AuthDbContextFactory.CreateDbContextAsync();
            WeaponToUpdate = _context.Weapons.FirstOrDefault(x => x.Id == OurWeapon.Id);
            EditRecord = true;
        }

        public async Task UpdateWeapon()
        {
            EditRecord = false;
            _context ??= await AuthDbContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                if (WeaponToUpdate is not null) _context.Weapons.Update(WeaponToUpdate);
                await _context.SaveChangesAsync();
            }
        }

        //Delete
        public async Task DeleteWeapon(Weapon OurWeapons)
        {
            _context ??= await AuthDbContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                if (OurWeapons is not null) _context.Weapons.Remove(OurWeapons);
                await _context.SaveChangesAsync();
            }
            await ShowWeapon();

        }
    }
}
