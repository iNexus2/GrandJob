﻿using HireMe.Entities.Enums;
using HireMe.Entities.Models;
using HireMe.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace HireMe.Areas.Identity.Pages.Account.Manage
{
    [Authorize]
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        private readonly IBaseService _baseService;
        private readonly IJobsService _jobsService;
        private readonly ICompanyService _companyService;
        private readonly IContestantsService _contestantService;
        private readonly IResumeService _resumeService;

        public DeletePersonalDataModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IBaseService baseService,
            IJobsService jobsService,
            ICompanyService companyService,
            IContestantsService contestantService,
            IResumeService resumeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _baseService = baseService;
            _jobsService = jobsService;
            _companyService = companyService;
            _contestantService = contestantService;
            _resumeService = resumeService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public User user { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Моля въведете вашата парола.")]
            [Display(Name = "Парола")]
            [DataType(DataType.Password, ErrorMessage = "Грешна парола.")]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Errors/AccessDenied", new { Area = "Identity" });
            }
            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToPage("./SetPassword");
            }
            if (user.AccountType == 0)
            {
                return RedirectToPage("Pricing");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToPage("/Account/Errors/AccessDenied", new { Area = "Identity" });
            }

            if (!user.isExternal)
            {
                RequirePassword = await _userManager.HasPasswordAsync(user);

                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Грешна парола.");
                    return Page();
                }

                _baseService.Delete(user.PictureName);
            }

            await _jobsService.DeleteAllBy(0, user);
            await _companyService.DeleteAllBy(user);
            await _contestantService.DeleteAllBy(user);
            await _resumeService.DeleteAllBy(user);

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                _baseService.ToastNotifyLog(user, ToastMessageState.Error, "Грешка", "при изтриване на акаунта ви.", $"{user.UserName}, {user.Email} ,{user.Role}", 2000);
            }

            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

       
    }
}