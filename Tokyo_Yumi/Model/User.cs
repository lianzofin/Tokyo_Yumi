namespace Tokyo_Yumi.Model
{
    /// מחלקה המייצגת משתמש במערכת Tokyo Yumi.
    /// מכילה פרטים אישיים ופרטי התחברות.
    public class User
    {
        // --- שדות ותכונות (Fields & Properties) ---
        public string Id;               // מזהה ייחודי של המשתמש
        public string Name;             // השם המלא של המשתמש
        public string UserName;         // שם המשתמש לצורך התחברות (Login)
        public string Password;         // סיסמת המשתמש
        public string Role;
        public string? CurrentUserName { get; set; }

        // --- בנאים (Constructors) ---

        /// בנאי ברירת מחדל (ריק).
        public User()
        {
        }

        /// בנאי המאפשר יצירת משתמש עם ערכים ראשוניים.
        public User(string id, string name, string userName, string password, string role)
        {
            Id = id;
            Name = name;
            UserName = userName;
            Password = password;
            Role = role;
        }

        // --- פונקציות גישה (Getters) ---

        public string GetId()
        {
            return Id;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetUserName()
        {
            return UserName;
        }

        public string GetPassword()
        {
            return Password;
        }

        public string GetRole()
        {
            return Role;
        }

        // --- פונקציות עדכון (Setters) ---

        public void SetId(string id)
        {
            Id = id;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetUserName(string userName)
        {
            UserName = userName;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetRole(string role)
        {
            Role = role;
        }
    }
}