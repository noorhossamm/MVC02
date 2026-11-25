using MVC02.Entities.Enums;

namespace MVC02.Entities
{
    public abstract class GymUser :BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; } 

        public Address Address { get; set; }

    }
}
