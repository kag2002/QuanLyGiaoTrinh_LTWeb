namespace BTL.Models
{
    public class User
    {
        string username;
        string password;
        int quyen;

        public User(string username, string password, int quyen)
        {
            this.Username = username;
            this.Password = password;
            this.Quyen = quyen;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Quyen { get => quyen; set => quyen = value; }
    }
}
