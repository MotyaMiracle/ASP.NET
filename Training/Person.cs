namespace Training
{
    public class Person
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        //public Role? Role { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public Person(string email, string password, string city, string company /*Role role*/)
        {
            Email = email;
            Password = password;
            //Role = role;
            City = city;
            Company = company;
        }
    }
}
