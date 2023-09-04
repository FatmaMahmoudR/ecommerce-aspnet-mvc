using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Models
{
     public class User /*: IdentityUser*/
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
     
        public string? username { get; set; }
      
        public string? password { get; set; }

       
        public string? Phone { get; set; }
     
        public string? Email { get; set; }
        public string? ProfilePicture { get; set; }

      
        public DateTime? AccCreationDate { get; set; }
    }
}




//using Microsoft.AspNetCore.Identity;
//using System.ComponentModel.DataAnnotations;

//namespace E_commerce.Models
//{
//    public class User /*: IdentityUser*/
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required(ErrorMessage = "Name is required.")]
//        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
//        public string? Name { get; set; }
//        [Required(ErrorMessage = "Username is required.")]
//        [MaxLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
//        public string? username { get; set; }
//        [Required(ErrorMessage = "Password is required.")]
//        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters.")]
//        public string? password { get; set; }

//        [Required(ErrorMessage = "Phone number is required.")]
//        [Phone(ErrorMessage = "Invalid phone number.")]
//        public string? Phone { get; set; }
//        [Required(ErrorMessage = "Email address is required.")]
//        [EmailAddress(ErrorMessage = "Invalid email address.")]
//        public string? Email { get; set; }
//        public string? ProfilePicture { get; set; }

//        [DataType(DataType.DateTime)]
//        [Display(Name = "Account Creation Date")]
//        public DateTime? AccCreationDate { get; set; }
//    }
//}




