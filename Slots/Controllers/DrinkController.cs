using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Slots.DAL.Interfaces;
using Slots.Domain.ViewModels.Drink;
using Slots.Domain.Entity;
using Slots.Service.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Slots.Controllers
{
    public class DrinkController : Controller
    {
        
       
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }



        
        public async Task<int> PlusOne(int Sum)
        {
            var sum = Global.Sum + 1;         
            Global.Sum = sum;
            await Task.Delay(0);


            return Global.Sum;
        }

        public async Task<int> PlusTwo(int Sum)
        {
            var sum = Global.Sum + 2;
            Global.Sum = sum;
            await Task.Delay(0);


            return Global.Sum;
        }

        public async Task<int> PlusFive(int Sum)
        {
            var sum = Global.Sum + 5;
            Global.Sum = sum;
            await Task.Delay(0);


            return Global.Sum;
        }

        public async Task<int> PlusTen(int Sum)
        {
            var sum = Global.Sum + 10;
            Global.Sum = sum;
            await Task.Delay(0);


            return Global.Sum;
        }

       
        [HttpGet]
        public IActionResult GetDrinks()
        {
            
            var response = _drinkService.GetDrinks();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
                
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public IActionResult GetDrinksAdmin(int Password)
        {
            
            if (Password == 123456)
            {
                Global.Login = true;
            }
            
            var response = _drinkService.GetDrinksAdmin();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return View("Error", $"{response.Description}");
        }

        public void BlockOne(bool BlockOne)
        {
            if (Global.BlockOne == true) { Global.BlockOne = false; } else { Global.BlockOne = true; }  


        }

        public void BlockTwo(bool BlockTwo)
        {
            if (Global.BlockTwo == true) { Global.BlockTwo = false; } else { Global.BlockTwo = true; }
        }

        public void BlockFive(bool BlockFive)
        {
            if (Global.BlockFive == true) { Global.BlockFive = false; } else { Global.BlockFive = true; }
        }

        public void BlockTen(bool BlockTen)
        {
            if (Global.BlockTen == true) { Global.BlockTen = false; } else { Global.BlockTen = true; }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _drinkService.DeleteDrink(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetDrinksAdmin");
            }
            return View("Error", $"{response.Description}");
        }

       

        [HttpGet]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
                return PartialView();

            var response = await _drinkService.GetDrink(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return PartialView(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> Save(DrinkViewModel viewModel)
        {
            ModelState.Remove("Id");
            
            if (ModelState.IsValid)
            {
                if (viewModel.Id == 0)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(viewModel.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)viewModel.Avatar.Length);
                    }
                    await _drinkService.Create(viewModel, imageData);
                }
                else
                {
                    await _drinkService.Edit(viewModel.Id, viewModel);
                }
            }
            return RedirectToAction("GetDrinksAdmin");
        }


        
        public async Task<IActionResult> BuyDrink(DrinkViewModel viewModel)
        {
            
            ModelState.Remove("Id");

               
                    await _drinkService.SBuyDrink(viewModel.Id, viewModel);
                
            
            return RedirectToAction("GetDrinks");
        }




        [HttpGet]
        public async Task<ActionResult> GetDrink(int id, bool isJson)
        {
            var response = await _drinkService.GetDrink(id);
            if (isJson)
            {
                return Json(response.Data);
            }
            return PartialView("GetDrink", response.Data);
        }

       

       
    }
}