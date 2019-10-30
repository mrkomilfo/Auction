using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Auction.ViewModels
{
    public class CreateLotViewModel
    {
        [Display(Name = "Название")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required]
        public string Desc { get; set; }

        [Display(Name = "Год выпуска")]
        [Required]
        public ushort Year { get; set; }

        [Display(Name = "Коробка")]
        [Required]
        public string Transmission { get; set; }

        [Display(Name = "Объём двигателя")]
        [Required]
        public string EngineVolume { get; set; }

        [Display(Name = "Топливо")]
        [Required]
        public string Fuel { get; set; }

        [Display(Name = "Кузов")]
        [Required]
        public string Body { get; set; }

        [Display(Name = "Привод")]
        [Required]
        public string Drive { get; set; }

        [Display(Name = "Пробег")]
        [Required]
        public uint Mileage { get; set; }

        [Display(Name = "Начальная стоимость")]
        [Required]
        public uint Price { get; set; }

        [Display(Name = "Длительность аукциона")]
        [Required]
        public ushort Duration { get; set; }

        [Display(Name = "Изображение")]
        [Required]
        public IFormFile Image { get; set; }
    }
}
