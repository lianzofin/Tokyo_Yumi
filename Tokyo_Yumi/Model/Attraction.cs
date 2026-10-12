namespace Tokyo_Yumi.Model
{
    // מחלקת המודל המייצגת אטרקציה בודדת במערכת
    public class Attraction
    {
        // מזהה ייחודי עבור כל אטרקציה (בדרך כלל מפתח ראשי במסד הנתונים)
        public int Id { get; set; }

        // שם האטרקציה (למשל: "מגדל טוקיו")
        public string Name { get; set; } = "";

        // תיאור מורחב על המקום, ההיסטוריה שלו או מה ניתן לעשות בו
        public string Description { get; set; } = "";

        // סיווג האטרקציה (למשל: בילוי, טבע, מוזיאון) - משמש לסינון בגלריה
        public string Category { get; set; } = "";

        // נתיב לקובץ התמונה או קישור URL להצגה בכרטיס האטרקציה
        public string ImageUrl { get; set; } = "";

        // הכתובת הפיזית של המקום (יכול לשמש לחיפוש או תצוגה)
        public string Address { get; set; } = "";
    }
}