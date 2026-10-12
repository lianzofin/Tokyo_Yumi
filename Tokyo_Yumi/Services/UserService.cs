using Tokyo_Yumi.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Tokyo_Yumi.Services
{
    public class UserService
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private User _currentUser;

        public UserService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
            // ברירת מחדל כשהדף עולה
            _currentUser = new User("0", "אורח", "", "אורח", "guest");
        }

        public async Task SetUserAsync(User user)
        {
            _currentUser = user;
            await Task.CompletedTask;
        }

        public async Task<User> GetUserAsync()
        {
            // אם כבר יש לנו משתמש מזוהה בזיכרון, נחזיר אותו מיד
            if (_currentUser != null && _currentUser.Role != "guest")
                return _currentUser;

            try
            {
                var result = await _sessionStorage.GetAsync<User>("UserSession");
                if (result.Success && result.Value != null)
                {
                    _currentUser = result.Value;
                }
            }
            catch
            {
                // כאן נמנעת השגיאה שראית בתמונה - בזמן טעינה ראשונית פשוט נחזיר אורח
            }

            return _currentUser;
        }

        // בתוך UserService.cs
        public User GetCurrentUser()
        {
            return _currentUser;
        }

        // פונקציה שאתה בטח קורא לה בזמן ה-Login
        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }
        public User GetUser() => _currentUser;
    }
}