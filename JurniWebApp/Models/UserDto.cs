using System.ComponentModel.DataAnnotations;
using JurniWebApp.Data;

namespace JurniWebApp.Models;

/**
 * This class is used to transfer data of a user from the client to the server.
 * It has the following properties:
 * - FirstName: The first name of the user.
 * - LastName: The last name of the user.
 * - Email: The email of the user.
 * - Password: The password of the user.
 */
public class UserDto {
    [Required]
    [StringLength(45, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(45, MinimumLength = 1, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [StringLength(90, MinimumLength = 5, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    [EmailAddress(ErrorMessage = EntityValidations.EmailFormatMessage)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = EntityValidations.StringRequiredMessage)]
    [StringLength(90, MinimumLength = 8, ErrorMessage = EntityValidations.StringBetweenLengthMessage)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}