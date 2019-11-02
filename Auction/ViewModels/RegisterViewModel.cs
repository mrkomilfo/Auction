using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Auction.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указано имя пользователя")]
        [Display(Name = "Имя пользователя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email")]
        [Remote(action: "CheckEmail", controller: "Users", ErrorMessage = "Email уже используется")]
        public string Email { get; set; }

        [Display(Name = "Телефон")]
        [Phone(ErrorMessage = "Телефон указан неверно")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
