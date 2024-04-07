﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(LocalApi.PolicyName)]
	[AllowAnonymous]
	public class RegistersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;

		public RegistersController(UserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
		{
			var values = new ApplicationUser
			{
				Email = userRegisterDto.Email,
				UserName = userRegisterDto.Username,
				Name = userRegisterDto.Name,
				Surname = userRegisterDto.Surname,
			};

			var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
			if (result.Succeeded)
			{
				return Ok("Kullanıcı Başarıyla Oluştu");
			}
			return Ok("Bir hata oluştu");
		}
		[HttpGet]
		public IActionResult GetUserData()
		{
			var userId = User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
			return Ok(userId);
		}
	}
}
