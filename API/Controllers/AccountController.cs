using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Dto;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;
        private readonly IMapper mapper;

        public AccountController(DataContext _context, ITokenService _tokenService, IMapper _mapper)
        {
            context = _context;
            tokenService = _tokenService;
            mapper = _mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await IsUserExists(registerDto.Username!)) return BadRequest("Username is taken");
            var user = mapper.Map<User>(registerDto);
            using var hmac = new HMACSHA512();

            user.Username = registerDto.Username;
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password!));
            user.PasswordSalt = hmac.Key;

            await context.Users!.AddAsync(user);
            await context.SaveChangesAsync();
            return new UserDto
            {
                Username = user.Username,
                FirstName= user.FirstName,
                LastName= user.LastName,    
                Token = tokenService.CreateToken(user),
                Gender = user.Gender,
                Organization = user.Organization,
                Role = user.Role,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country
            };
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users!
            .Include(u => u.Exams)
            .FirstOrDefaultAsync(user => user.Username == loginDto.Username);
            if(user == null) return Unauthorized("Invalid Username");
            using var hmac = new HMACSHA512(user.PasswordSalt!);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password!));
            for(int i = 0; i < computeHash.Length; i++)
            {
                if(computeHash[i] != user.PasswordHash![i]) return Unauthorized("Invalid User");
            }
            return new UserDto
            {
                Username = user.Username,
                Token = tokenService.CreateToken(user),
                Gender = user.Gender,
                Organization = user.Organization,
                Role = user.Role,
                DateOfBirth = user.DateOfBirth,
                Country = user.Country
            };
        }
        private async Task<bool> IsUserExists(string Username)
        {
            return await context.Users!.AnyAsync(User => User.Username!.ToLower() == Username.ToLower());
        }
    }
}