using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Auction.ViewModels
{
    public class EditMyProfileViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 20 символов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action: "CheckEmail", controller: "Users", AdditionalFields = nameof(Id), ErrorMessage = "Email уже используется")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Телефон указан неверно")]
        public string PhoneNumber { get; set; }
    }
}
