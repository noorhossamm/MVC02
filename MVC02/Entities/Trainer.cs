using MVC02.Entities.Enums;

namespace MVC02.Entities
{
    public class Trainer :GymUser
    {
        public DateTime HireDate { get; set; }

        public Specialities Specialities { get; set; }

        public ICollection<Session> Sessions = default!;
    }
}
