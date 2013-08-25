using BloggingSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace BloggingSystem.Services.DataTransferObjects
{
    [DataContract]
    public class UserRegisterDto
    {
        [DataMember(Name = "username")]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters long")]
        [MaxLength(30, ErrorMessage = "Username cannot be more then 30 characters long")]
        [RegularExpression("^([a-zA-Z0-9_\\.]+)$",
            ErrorMessage = "Username contains characters that are not allowed. Allowed characters are digits, letters in both registers '_'(underscore) and '.' (dot). ")]
        public string UserName { get; set; }

        [DataMember(Name = "displayName")]
        [MinLength(3, ErrorMessage = "Nickname must be at least 6 characters long")]
        [MaxLength(30, ErrorMessage = "Nickname cannot be more then 30 characters long")]
        [RegularExpression("^([a-zA-Z0-9_\\s\\.-]+)$",
            ErrorMessage = "Nickname contains characters that are not allowed. Allowed characters are digits, letters in both registers '_' (underscore), '-' (dash), ' ' (space) and '.' (dot).")]
        public string NickName { get; set; }

        [DataMember(Name="authCode")]
        [StringLength(40, ErrorMessage = "Sha1 encription expected. It must be exaclty 40 characters in length.")]
        public string AuthCode { get; set; }

        public static User CreateUser(UserRegisterDto registerDto)
        {
            var newUser = new User()
             {
                 UserName = registerDto.UserName.ToLower(),
                 NickName = registerDto.NickName,
                 AuthCode = registerDto.AuthCode
             };

            return newUser;
        }
    }
}