using System.ComponentModel.DataAnnotations;

namespace JurniWebApp.Data.Entities;
/**
 * This class represents a user plan, which is a many-to-many relationship between a user and a plan.
 * A user plan has the following properties:
 * - Id: The unique identifier of the user plan.
 * - UserId: The unique identifier of the user.
 * - User: The user.
 * - PlanId: The unique identifier of the plan.
 * - Plan: The plan.
 */
public class UserPlan {
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int PlanId { get; set; }
    public Plan Plan { get; set; }
}