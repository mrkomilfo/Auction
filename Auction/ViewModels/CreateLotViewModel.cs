using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Auction.ViewModels
{
    public class CreateLotViewModel
    {
        [Display(Name = "Название")]
        [MaxLength(31, ErrorMessage = "Слишком длинное название")]
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [MaxLength(1023, ErrorMessage = "Максимальная длина: 1023 символа")]
        public string Desc { get; set; }

        [Display(Name = "Год выпуска")]
        [Range(1900, 2019, ErrorMessage = "Неверно указан год")]
        [Required(ErrorMessage = "Не указан год")]
        public ushort Year { get; set; }

        [Display(Name = "Коробка")]
        [Required]
        public string Transmission { get; set; }

        [Display(Name = "Объём двигателя")]
        [Required(ErrorMessage = "Не указан объем")]
        [RegularExpression(@"^(\d)+(,\d{1})?$", ErrorMessage = "Неверно указан объем")]
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
        [Required(ErrorMessage = "Не указана начальная стоимость")]
        [Range(0, 4294967295)]
        public uint Price { get; set; }

        [Display(Name = "Длительность аукциона")]
        [Required(ErrorMessage = "Не указана длительность")]
        [Range(1, 30, ErrorMessage = "Неверный диапазон")]
        public ushort Duration { get; set; }

        [Display(Name = "Изображение")]
        [Required(ErrorMessage = "Загрузите изображение")]
        public IFormFile Image { get; set; }
    }
}
