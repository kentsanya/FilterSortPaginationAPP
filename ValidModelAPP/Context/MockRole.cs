using ValidModelAPP.Models.Authentiction;

namespace ValidModelAPP.Context
{
    public class MockRole
    {
        public List<User> Users { get; }
        public MockRole() 
        { 
            Role adminRole = new Role("Admin");
            Role userRole = new Role("User");
            Users = new List<User>
            {
              new User { Login="petro" ,Password="12345", Role=adminRole},
              new User { Login ="Ivan", Password="98765", Role=userRole}
            };
        }
    }
}
