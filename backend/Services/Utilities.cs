using Backend.Entities;

namespace Backend.Extensions
{
    public class Utilities
    {

        public Utilities()
        {
            
        }


        public void SendOTP()
        {
            Random random = new Random();
            int otpNumber = random.Next(1000, 10000);

            // hashOTP = hash(otpNumber)

            OTP otp = new OTP
            {
                UserId = "USERIDHERE",
                HashedOTP = "hashOTP",
                CreatedAt = DateTime.Now,
                ExpiredAt = DateTime.Now.AddMilliseconds(3600000),
            };




        }
    }
}



