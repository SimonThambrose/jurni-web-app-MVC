using System.ComponentModel.DataAnnotations;

namespace JurniWebApp.Data.Entities;

/**
 * This class represents a plan, which a user is able to subscribe to.
 * A plan has the following properties:
 * - Id: The unique identifier of the plan.
 * - Name: The name of the plan.
 * - Price: The price of the plan.
 * - Description: The description of the plan.
 * - PlanUsers: The users subscribed to the plan.
 */
public class Plan {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Description { get; set; }
    public ICollection<UserPlan> PlanUsers { get; set; }
}