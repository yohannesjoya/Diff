using Backend.Contracts;
using Backend.Data;
using Backend.Entities;
using Backend.Repository;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IEmailSender _emailSender;
        private readonly ILogger<AuthController> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IEmailSender emailSender, ILogger<AuthController> logger, IUnitOfWork unitOfWork)
        {
            _emailSender = emailSender;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }





        // GET: api/<AuthController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var receiver = "yohannesdestagebru10@gmail.com";
            var subject = "test email";
            var message = "<h1>Hello Joya</h1>";

            await _emailSender.SendEmailAsync(receiver, subject, message);

            return Ok();
        }



        [Route("[Action]/", Name = "CreateOpt")]
        [HttpPost]
        public async Task<IActionResult> create_otp(User user)
        {


            var userAlreadyExist = await _unitOfWork.UserRepository.GetUserByEmail(user.Email);

            if (userAlreadyExist == null) {

                var newUser = await _unitOfWork.UserRepository.Add(user);

                if (newUser == null) return Conflict(new { error = "InternalServerError", message = "Failed to add the user", statusCode = 500 });

            }


            // check the opt with the userId - if exist and not expired, tell him try later or check your mail
            //                               - if not create and send him new

            Random random = new Random();
            string otpNumber = random.Next(1000, 10000).ToString();
            string otpHash = BCrypt.Net.BCrypt.HashString(otpNumber);


            OTP otp = new OTP()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                UserId = user.Id,
                HashedOTP = otpHash,
                CreatedAt = DateTime.Now,
                ExpiredAt = DateTime.Now.AddMilliseconds(3600000),
            };

            var newOtp = await _unitOfWork.OtpRepository.Add(otp);

            if (newOtp is null) return Conflict(new { error = "InternalServerError", message = "Failed to add your otp", statusCode = 500 });


            var receiver = user.Email;
            var subject = @"<h1>Otp Verifications</h1>";
            var message = EmailTemplateGenerator.GenerateEmailTemplate("Diff",otpNumber);

            await _emailSender.SendEmailAsync(receiver, subject, message);


            _unitOfWork.Save();

            return Ok("yes");
            //return Redirect("http://localhost:3000/new-location");

         
        }


    }
}


/*
 
 
 
  [Route("[Action]/users", Name = "GetAllUsers")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            var users = await _userRepository.GetAll();
            return Ok(users);

        }

 
        [HttpGet("{email}",Name = "GetUserByEmail")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {

            var user = await _userRepository.GetUserByEmail(email);
            return Ok(user);

        }

        [Route("[Action]/users/{id}", Name = "GetUserById")]
        [HttpGet]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<User>> GetUserById(string id)
        {

            var user = await _userRepository.Get(id);
            return Ok(user);

        }



 
 
 
 */