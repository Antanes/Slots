using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Slots.DAL.Interfaces;
using Slots.Domain.Entity;
using Slots.Domain.Enum;
using Slots.Domain.Response;
using Slots.Domain.ViewModels.Drink;
using Slots.Service.Interfaces;
using System;
using System.Diagnostics;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Slots.Service.Implementations
{
    public class DrinkService : IDrinkService
    {
        private readonly IBaseRepository<Drink> _drinkRepository;

        public DrinkService(IBaseRepository<Drink> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task<IBaseResponse<DrinkViewModel>> GetDrink(long id)
        {
            try
            {
                var drink = await _drinkRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (drink == null)
                {
                    return new BaseResponse<DrinkViewModel>()
                    {
                        Description = "Напиток не найден",
                        StatusCode = StatusCode.DrinkNotFound
                    };
                }

                var data = new DrinkViewModel()
                {
                    Name = drink.Name,
                    Price = drink.Price,
                    Quantity = drink.Quantity,
                    Image = drink.Avatar,
                };

                return new BaseResponse<DrinkViewModel>()
                {
                    StatusCode = StatusCode.OK,
                    Data = data
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<DrinkViewModel>()
                {
                    Description = $"[GetDrink] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }




        public async Task<IBaseResponse<Drink>> Create(DrinkViewModel model, byte[] imageData)
{
    try
    {
        var drink = new Drink()
        {
            Name = model.Name,
            
            Quantity = model.Quantity,
            Price = model.Price,
            Avatar = imageData
        };
        await _drinkRepository.Create(drink);

        return new BaseResponse<Drink>()
        {
            StatusCode = StatusCode.OK,
            Data = drink
        };
    }
    catch (Exception ex)
    {
        return new BaseResponse<Drink>()
        {
            Description = $"[Create] : {ex.Message}",
            StatusCode = StatusCode.InternalServerError
        };
    }
}

public async Task<IBaseResponse<bool>> DeleteDrink(long id)
{
    try
    {
        var drink = await _drinkRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        if (drink == null)
        {
            return new BaseResponse<bool>()
            {
                Description = "User not found",
                StatusCode = StatusCode.DrinkNotFound,
                Data = false
            };
        }

        await _drinkRepository.Delete(drink);

        return new BaseResponse<bool>()
        {
            Data = true,
            StatusCode = StatusCode.OK
        };
    }
    catch (Exception ex)
    {
        return new BaseResponse<bool>()
        {
            Description = $"[DeleteDrink] : {ex.Message}",
            StatusCode = StatusCode.InternalServerError
        };
    }
}

public async Task<IBaseResponse<Drink>> Edit(long id, DrinkViewModel model)
{
    try
    {
        var drink = await _drinkRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        if (drink == null)
        {
            return new BaseResponse<Drink>()
            {
                Description = "Drink not found",
                StatusCode = StatusCode.DrinkNotFound
            };
        }

       
        drink.Price = model.Price;
        drink.Quantity = model.Quantity;
        drink.Name = model.Name;

        await _drinkRepository.Update(drink);


        return new BaseResponse<Drink>()
        {
            Data = drink,
            StatusCode = StatusCode.OK,
        };
        // TypeDrink
    }
    catch (Exception ex)
    {
        return new BaseResponse<Drink>()
        {
            Description = $"[Edit] : {ex.Message}",
            StatusCode = StatusCode.InternalServerError
        };
    }
}



        public async Task<IBaseResponse<Drink>> SBuyDrink(long id, DrinkViewModel model)
        {
            
            
            try
            {
                var drink = await _drinkRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (drink == null)
                {
                    return new BaseResponse<Drink>()
                    {
                        Description = "Drink not found",
                        StatusCode = StatusCode.DrinkNotFound
                    };
                }
                if (drink.Quantity > 0 && drink.Price <= Global.Sum)
                {
                    
                    drink.Quantity--;
                    Global.Sum -= drink.Price;
                    Global.Change = Global.Sum;
                    Global.ChangePrice = Global.Sum;
                    Global.Sum = 0;
                    Global.Coin10 = Global.ChangePrice / 10;
                    Global.ChangePrice -= Global.Coin10 * 10;
                    Global.Coin5 = Global.ChangePrice / 5;
                    Global.ChangePrice -= Global.Coin5 * 5;
                    Global.Coin2 = Global.ChangePrice / 2;
                    Global.ChangePrice -= Global.Coin2 * 2;
                    Global.Coin1 = Global.ChangePrice;


                }
                else
                    return new BaseResponse<Drink>()
                    {
                        Description = "Drinks are out",
                        StatusCode = StatusCode.DrinksAreOut
                    };

                await _drinkRepository.Update(drink);


                return new BaseResponse<Drink>()
                {
                    Data = drink,
                    StatusCode = StatusCode.OK,
                };
                // TypeDrink
            }
            catch (Exception ex)
            {
                return new BaseResponse<Drink>()
                {
                    Description = $"[GetDrinks] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }



       



        public IBaseResponse<List<Drink>> GetDrinks()
{
    try
    {
        var drinks = _drinkRepository.GetAll().ToList();
        if (!drinks.Any())
        {
            return new BaseResponse<List<Drink>>()
            {
                Description = "Найдено 0 элементов",
                StatusCode = StatusCode.OK
            };
        }

        return new BaseResponse<List<Drink>>()
        {
            Data = drinks,
            StatusCode = StatusCode.OK
        };
    }
    catch (Exception ex)
    {
        return new BaseResponse<List<Drink>>()
        {
            Description = $"[GetDrinks] : {ex.Message}",
            StatusCode = StatusCode.InternalServerError
        };
    }
}

        public IBaseResponse<List<Drink>> GetDrinksAdmin()
        {
            try
            {
                var drinks = _drinkRepository.GetAll().ToList();
                if (!drinks.Any())
                {
                    return new BaseResponse<List<Drink>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }

                return new BaseResponse<List<Drink>>()
                {
                    Data = drinks,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Drink>>()
                {
                    Description = $"[GetDrinksAdmin] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }   
}
