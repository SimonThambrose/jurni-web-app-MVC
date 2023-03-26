using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JurniWebApp.Data.Entities;

/**
 * This class represents a user of the application.
 * An user has the following properties:
 * - Id: The unique identifier of the user.
 * - FirstName: The first name of the user.
 * - LastName: The last name of the user.
 * - Email: The email of the user.
 * - Password: The password of the user.
 * - IsAdmin: A boolean value indicating whether the user is an administrator.
 * - CreatedOn: The date and time when the user was created.
 * - UpdatedOn: The date and time when the user was last updated.
 * - UserPlans: The plans subscribed by the user.
 */
public class User {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [MaxLength(45, ErrorMessage = EntityValidations.StringMaxLengthMessage)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [MaxLength(45, ErrorMessage = EntityValidations.StringMaxLengthMessage)]
    public string LastName { get; set; }

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [MaxLength(90, ErrorMessage = EntityValidations.StringMaxLengthMessage)]
    [EmailAddress(ErrorMessage = EntityValidations.EmailFormatMessage)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [MaxLength(90, ErrorMessage = EntityValidations.StringMaxLengthMessage)]
    public string Password { get; set; }
    
    public bool IsAdmin { get; set; }
    
    [DefaultValue("CURRENT_TIMESTAMP")]
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    public ICollection<UserPlan> UserPlans { get; set; }
}