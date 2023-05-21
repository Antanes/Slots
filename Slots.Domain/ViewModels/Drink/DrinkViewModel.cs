using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Slots.Domain.ViewModels.Drink
{
    public class DrinkViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Введите имя")]
        [MinLength(2, ErrorMessage = "Минимальная длина должна быть больше двух символов")]
        public string Name { get; set; }

        [Display(Name = "Стоимость")]
        [Required(ErrorMessage = "Укажите стоимость")]
        public int Price { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Укажите количество")]
        public int Quantity { get; set; }

        public IFormFile? Avatar { get; set; }

        public byte[]? Image { get; set; }
        


    }
}
