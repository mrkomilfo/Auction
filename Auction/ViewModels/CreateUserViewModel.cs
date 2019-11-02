using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Auction.ViewModels
{
    public class CreateUserViewModel
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
    }
}
