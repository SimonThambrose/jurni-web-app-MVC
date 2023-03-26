namespace JurniWebApp.Data; 

/**
 * EntityValidations. Validation messages for entities.
 */
public static class EntityValidations {
    public const string RequiredMessage = "{0} is required.";
    public const string StringLengthBetweenMessage = "{0} must be between {2} and {1} characters long.";
    public const string StringLengthMinMessage = "{0} must be at least {1} characters.";
    public const string StringLengthMaxMessage = "{0} cannot be longer than {1} characters.";
}