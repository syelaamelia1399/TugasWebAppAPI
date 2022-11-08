using API.Context;
using API.Handlers;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _configuration;
        private AccountRepository _repository;

        public AccountController(AccountRepository accountRepository, IConfiguration configuration)
        {
            _repository = accountRepository;
            _configuration = configuration;
        }



        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            try
            {
                var item = _repository.Login(email, password);
                if (item == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Data Tidak Ada, Email atau Password Anda Salah"
                    });
                }
                else
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", item[0]),
                        new Claim("FullName", item[1]),
                        new Claim("Email", item[2]),
                        new Claim("role", item[3])
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Data Ada",
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                /*
                return item switch
                {
                    resultData => Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Data Ada",

                    })
                }*/
                ;
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Messege = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(string fullName, string email, DateTime birthDate, string password)
        {
            try
            {
                var item = _repository.Register(fullName, email, birthDate, password);

                return item switch
                {
                    1 => Ok(new
                        {
                        StatusCode = 200,
                        Messege = "Gagal Untuk Register",
                        }),
                    2 => Ok(new
                        {
                        StatusCode = 200,
                        Messege = "Berhasil Untuk Register"
                        }),
                    3 => Ok(new
                        {
                        StatusCode = 200,
                        Messege = "Gagal Register"
                    })

                };
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Messege = ex.Message
                });
            }
        }
        
        [HttpPut]
        [Route("ChangePassword")]
        public ActionResult ChangePassword(string email, string password, string newPassword)
        {
            try
            {
                var item = _repository.ChangePassword(email, password, newPassword);

                return item switch
                {
                    1 => Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Berhasil Untuk Change Password",
                    }),
                    2 => Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Gagal Untuk Change Password"
                    }),
                    3 => Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Gagal Register"
                    })

                };
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Messege = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("ForgetPassword")]
        public ActionResult ForgetPassword(string email, string newPassword)
        {
            try
            {
                var item = _repository.ForgetPassword(email, newPassword);

                return item switch
                {
                    1 => Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Berhasil Untuk Forget Password",
                    }),
                    2 => Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Gagal Untuk Forget Password"
                    })
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Messege = ex.Message
                });
            }
        }



        // WEB APP YANG LAMA
        /*
                var data = _context.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));  //pake hash, langkah awal cek email ada apa gk

                var result = Hashing.ValidatePassword(password, data.Password);
                if (result)
                {
                    if (data != null)
                    {
                        HttpContext.Session.SetInt32("Id", data.Id);
                        HttpContext.Session.SetString("FullName", data.Employee.FullName);
                        HttpContext.Session.SetString("Email", data.Employee.Email);
                        HttpContext.Session.SetString("Role", data.Role.Name);

                        return Ok(new
                        {
                            StatusCode = 200,
                            Messege = "Data Ada",
                            Data = data.Employee.FullName, data.Employee.Email, data.Role.Name
                        });
                    }
                    return Ok(new
                    {
                        StatusCode = 200,
                        Messege = "Data Tidak Ada"
                    });
                }
                return Ok();
                */
    }
}
