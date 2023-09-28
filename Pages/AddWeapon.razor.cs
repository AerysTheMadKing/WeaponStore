using AuthSystem.Areas.Identity.Data;
using AuthSystem.Data;

namespace AuthSystem.Pages
{
    public partial class AddWeapon
    {
        public bool ShowCreate { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
        }
        private AuthDbContext? _context;

        public Weapon? NewWeapon { get; set; }

        public void ShowCreateForm()
        {
            NewWeapon = new Weapon();
            ShowCreate = true;
        }
        public async Task CreateNewWeapon()
        {
            _context ??= await AuthDbContextFactory.CreateDbContextAsync();
            if (NewWeapon is not null)
            {

                Console.WriteLine($"{_context?.Weapons.Add(NewWeapon)}, esskeetit");
                _context?.SaveChangesAsync();

            }
            ShowCreate = false;

        }

    }
}
