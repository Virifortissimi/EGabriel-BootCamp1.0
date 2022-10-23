using HttpClientTest.DataContext;
using HttpClientTest.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpClientTest.Repository
{
    public class DataRepo : IDataRepo
    {
        private readonly DataBaseContext _context;

        public DataRepo(DataBaseContext context)
        {
            _context = context;
        }

        public async Task CreateDrinks(DrinkData model)
        {   
            foreach (var item in model.drinks)
            {
                var isAvailable = await _context.Drinks.FirstOrDefaultAsync(x => x.Name == item.strDrink);

                if (isAvailable != null) continue;

                _context.Drinks.Add(new DrinkModel()
                {
                    Name = item.strDrink,
                    Category = item.strCategory,
                    Instructions = item.strInstructions
                }); //Add new Drink;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DrinkModel>> GetDrinks()
        {
            return await _context.Drinks.ToListAsync();
        }
    }
}