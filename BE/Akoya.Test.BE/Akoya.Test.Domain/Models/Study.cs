using System.Collections.Generic;

namespace Akoya.Test.Domain.Models
{
    public class Study
    {
        public int Id { get; set; }
        public List<User> Users { get; set; }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        public string Name { get; set; }
    }
}
