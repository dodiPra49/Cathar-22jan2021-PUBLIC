using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using New.Models;
using New.Utility;
using New.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using Microsoft.AspNetCore.Mvc.Rendering;
using New.Repositories;
using System.Windows.Forms;
using System.Linq;


namespace New.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly IAllRepo<UnitKerja> _repoUnitKerja;
        private readonly IAllRepo<Pegawai> _repoPegawai;
        private readonly ServiceUser _varServiceUser;

        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        //private readonly RoleManager<IdentityRole> _RoleManager;
        //private readonly ApplicationDbContext _context;

        //public RegisterModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public RegisterModel(
            //IPegawaiRepository pegawaiRepo,
            IAllRepo<UnitKerja> repoUnitKerja,
            IAllRepo<Pegawai> repoPegawai,
            ServiceUser varServiceUser,
            UserManager<IdentityUser> userManager)

        //,
        //SignInManager<IdentityUser> signInManager,
        //ILogger<RegisterModel> logger,
        //IEmailSender emailSender,
        //RoleManager<IdentityRole> RoleManager)
        {
            //_pegawaiRepo = pegawaiRepo;
            _repoUnitKerja = repoUnitKerja;
            _repoPegawai = repoPegawai;
            //_unitOfWork = unitofwork;
            _userManager = userManager;
            _varServiceUser = varServiceUser;
            //_signInManager = signInManager;
            //_logger = logger;
            //_emailSender = emailSender;
            //_RoleManager = RoleManager;


        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string NIP { get; set; }
            public Int16 UnitKerja { get; set; }


        }

        public void OnGet(string returnUrl = null)
        {
            var _cutoff = _varServiceUser.GetToday();
            //var x = _unitOfWork.UnitKerjaRepository.GetByID(1) ;
            //ViewData["IdUnitKerja"] = new SelectList(_repoUnitKerja.GetAll(), "Id", "Uraian");
            ViewData["IdUnitKerja"] = new SelectList(
                 _repoUnitKerja.GetAll()
                 .Where(u => u.ValidTill > _cutoff || u.ValidTill == null)
                 .OrderBy(u => u.Uraian)
                 , "Id", "Uraian");

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            string role = Request.Form["rdUserRole"].ToString();

            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string nama2 = "";
                var peg = _repoPegawai.GetById(Input.NIP);
                if (peg != null)
                {
                    nama2 = peg.Nama;
                }
                //string nama2 = _repoPegawai.GetById(Input.NIP).Nama;
                if (nama2 == "")
                {
                   
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Insert is successfull')", true);
                    return Page();
                }
                //string nama2 = "";

                var user = new ApplicationUser
                {
                    UserName = Input.NIP,
                    NIP = Input.NIP,
                    Nama = nama2,
                    UnitKerja = Input.UnitKerja,

                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {

                    if (role == SD.User)
                    {
                        await _userManager.AddToRoleAsync(user, SD.User);
                    }
                    else
                    {
                        if (role == SD.Admin)
                        {
                            await _userManager.AddToRoleAsync(user, SD.Admin);
                        }

                        else
                         if (role == SD.AdminBKPSDM)
                        {
                            await _userManager.AddToRoleAsync(user, SD.AdminBKPSDM);
                        }
                        else
                        {
                            await _userManager.AddToRoleAsync(user, SD.User);

                            //await _signInManager.SignInAsync(user, isPersistent: false);

                          //  await _userManager.AddToRoleAsync(user, SD.SuperAdmin);
                            return LocalRedirect(returnUrl);




                        }
                    }

                    return RedirectToAction("Index", "User", new { area = "SuperAdmin" });
                    //ViewData["NIP"] = new SelectList(_context.Pegawai, "NIP", "NIP");
                    //_logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");


                    //return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
