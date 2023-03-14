namespace University.Core.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserFullName { get; private set; }
        public string UserName { get; private set; }
        public string Password{ get; private set; }
        public string Mobile { get; private set; }
        public long RoleId{ get; private set; }

        public Teacher Teacher{ get; set; }
        public Student Student { get; set; }

        public User(string userFullName, string userName, string password, string mobile, 
            long roleId, string profilePhoto)
        {
            UserFullName = userFullName;
            UserName = userName;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;

        }

    }
}
