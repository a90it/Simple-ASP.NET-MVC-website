namespace MvcTemplate.Web.Areas.Administration.ViewModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        public string Id { get; set; }

        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Role { get; set; }
    }
}
