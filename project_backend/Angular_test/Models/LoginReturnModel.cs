using System;

namespace Angular_test.Models
{
    public class LoginReturnModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsLogin { get; set; }
        public DateTime LoginDate { get; set; }
    }
}
