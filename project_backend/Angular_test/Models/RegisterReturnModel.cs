namespace Angular_test.Models
{
    public class RegisterReturnModel
    {
        public string Name { get; set; } //FirsName ve LastName
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsRegistered { get; set; } = false;

    }
}
