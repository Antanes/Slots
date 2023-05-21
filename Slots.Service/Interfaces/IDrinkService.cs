using Slots.Domain.Entity;
using Slots.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Slots.Domain.ViewModels.Drink;


namespace Slots.Service.Interfaces
{
    public interface IDrinkService
    {
        

        IBaseResponse<List<Drink>> GetDrinks();
        IBaseResponse<List<Drink>> GetDrinksAdmin();

        Task<IBaseResponse<DrinkViewModel>> GetDrink(long id);

        

        Task<IBaseResponse<Drink>> Create(DrinkViewModel drink, byte[] imageData);

        Task<IBaseResponse<bool>> DeleteDrink(long id);

        Task<IBaseResponse<Drink>> Edit(long id, DrinkViewModel model);

        Task<IBaseResponse<Drink>> SBuyDrink(long id, DrinkViewModel model);
    }
}
