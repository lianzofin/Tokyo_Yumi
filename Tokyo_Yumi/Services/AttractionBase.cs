using Tokyo_Yumi.Model;
using System.Collections.Generic;

namespace Tokyo_Yumi.Data
{
    // מחלקה זו אחראית על ניהול בסיס הנתונים הסטטי של האטרקציות בטוקיו
    public class AttractionBase
    {
        private readonly DatabaseService _dbService;

        // וודא שהבנאי מקבל את ה-DatabaseService
        public AttractionBase(DatabaseService dbService)
        {
            _dbService = dbService;
        }


        // הוסף את שלוש הפונקציות האלו כדי שהקווים האדומים ייעלמו:

        public void ToggleFavorite(string userId, int attractionId)
        {
            _dbService.ToggleFavorite(userId, attractionId);
        }

        public List<int> GetUserFavoriteIds(string userId)
        {
            return _dbService.GetUserFavoriteIds(userId);
        }

        public List<Attraction> GetUserFavorites(string userId)
        {
            return _dbService.GetUserFavorites(userId);
        }

        // פונקציה המחזירה רשימה של כל האטרקציות הזמינות
        public List<Attraction> GetAttractions()
        {
            // יצירה והחזרה של רשימה חדשה המכילה אובייקטים מסוג Attraction
            return new List<Attraction>
            {
                new Attraction {
        Id = 1,
        Name = "צומת שיבויה (Shibuya Crossing)",
        Description = "צומת שיבויה הוא אחד הסמלים המפורסמים ביותר של טוקיו, מול תחנת שיבויה. מתאים למי שרוצה לחוות את קצב החיים הסואן בעיר ולצלם את מעבר ההמונים. פתוח 24/7, מומלץ להגיע בשעות השיא.",
        Category = "בילוי",
        ImageUrl = "images/shibuya_cross.jpg",
        Address = "Shibuya Crossing, Tokyo"
    },
    new Attraction {
        Id = 2,
        Name = "מקדש סנסו-ג'י (Senso-ji)",
        Description = "מקדש סנסו-ג'י הוא מקדש בודהיסטי עתיק ומרשים ברובע אסאקוסה. מתאים למי שמתעניין בהיסטוריה, תרבות יפנית ורוחניות. שעות פתיחה: 06:00–17:00, המתחם החיצוני פתוח 24/7.",
        Category = "בילוי",
        ImageUrl = "images/1_asakusa_sensoji-a.jpg",
        Address = "Sensō-ji, Tokyo"
    },
    new Attraction {
        Id = 3,
        Name = "פארק אואנו (Ueno Park)",
        Description = "פארק אואנו הוא פארק רחב ידיים במרכז טוקיו עם אגמים, מוזיאונים וגן חיות. מתאים למשפחות, זוגות ואוהבי טבע ואמנות. שעות פתיחה: 05:00–23:00.",
        Category = "פארק",
        ImageUrl = "images/park_tokyo.webp",
        Address = "Ueno Park, Tokyo"
    },
    new Attraction {
        Id = 4,
        Name = "גני שינג'וקו גיאואן",
        Description = "גני שינג'וקו גיאואן מציעים גנים בסגנונות יפני, צרפתי ואנגלי בלב העיר. מתאים למי שמחפש שלווה, טבע וגינון יפני מסורתי. שעות פתיחה: 09:00–16:30, סגור בימי שני.",
        Category = "פארק",
        ImageUrl = "images/caption-80.jpg",
        Address = "Shinjuku Gyoen, Tokyo"
    },
    new Attraction {
        Id = 5,
        Name = "רובע גינזה (Ginza)",
        Description = "גינזה הוא רובע קניות יוקרתי ומפורסם בטוקיו עם חנויות מותגים ומסעדות גורמה. מתאים לחובבי שופינג, אופנה וחיי לילה. שעות פתיחה משתנות לפי החנות, בדרך כלל 10:00–20:00.",
        Category = "קניות",
        ImageUrl = "images/gizna.png",
        Address = "Ginza, Tokyo"
    },
    new Attraction {
        Id = 6,
        Name = "מוזיאון מורי ארט",
        Description = "מוזיאון מורי ארט מציג אמנות מודרנית ובינלאומית במתחם רופונגי הילס. מתאים לאוהבי אמנות עכשווית ותערוכות מיוחדות. שעות פתיחה: 10:00–22:00, שלישי עד 17:00.",
        Category = "מוזיאון",
        ImageUrl = "images/mori_building.jpg",
        Address = "Mori Art Museum, Tokyo"
    },
    new Attraction {
        Id = 7,
        Name = "מגדל טוקיו (Tokyo Tower)",
        Description = "מגדל טוקיו הוא מגדל תצפית איקוני בלב העיר ומציע נופים מרהיבים של טוקיו. מתאים לחובבי צילום ונוף עירוני. שעות פתיחה: 09:00–22:30.",
        Category = "בילוי",
        ImageUrl = "images/tokyo_tower.jpg",
        Address = "Tokyo Tower, Tokyo"
    },
    new Attraction {
        Id = 8,
        Name = "TeamLab Borderless",
        Description = "TeamLab Borderless הוא מוזיאון דיגיטלי אינטראקטיבי עם חוויות אור, קול ותנועה ייחודיות. מתאים למבוגרים וילדים, במיוחד חובבי טכנולוגיה ואמנות חדשנית. שעות פתיחה: 09:00–21:00.",
        Category = "מוזיאון",
        ImageUrl = "images/teamLAB.webp",
        Address = "Azabudai Hills, Tokyo"
    },
    new Attraction {
        Id = 9,
        Name = "שוק הדגים טויוסו",
        Description = "שוק טויוסו הוא שוק דגים מודרני עם מגוון דגים טריים ומסעדות סושי. מתאים לחובבי אוכל יפני, תרבות שווקים וצילום. שעות פתיחה: 05:00–15:00, סגור ראשון.",
        Category = "קניות",
        ImageUrl = "images/fish.jpg",
        Address = "Toyosu Market, Tokyo"
    },
    new Attraction {
        Id = 10,
        Name = "מגדל סקייטרי (Tokyo Skytree)",
        Description = "מגדל סקייטרי הוא מגדל גבוה עם תצפית פנורמית של טוקיו והסביבה. מתאים לצלמים ומי שרוצה חוויה של נוף עירוני מרהיב. שעות פתיחה: 10:00–21:00.",
        Category = "פארק",
        ImageUrl = "images/skytree.jpg",
        Address = "Tokyo Skytree, Tokyo"
    },
    new Attraction {
        Id = 11,
        Name = "סאנשיין סיטי",
        Description = "מתחם סאנשיין סיטי הוא קומפלקס קניות, בילוי ואטרקציות מרכזיות. מתאים למשפחות ולחובבי קניות, כולל אקווריום ומרכז בידור. שעות פתיחה: 10:00–20:00, האקווריום פתוח עד 21:00.",
        Category = "בילוי",
        ImageUrl = "images/sunshine_city.jpg",
        Address = "Sunshine City, Tokyo"
    },
    new Attraction {
        Id = 12,
        Name = "דיסנילנד טוקיו",
        Description = "דיסנילנד טוקיו הוא פארק שעשועים ענק עם מתקנים לכל הגילאים. מתאים למשפחות עם ילדים, אוהבי דיסני וחובבי הרפתקאות. שעות פתיחה משתנות לפי יום, בדרך כלל 09:00–21:00.",
        Category = "פארק",
        ImageUrl = "images/disneyland.jpg",
        Address = "Tokyo Disneyland"
    },
    new Attraction {
        Id = 13,
        Name = "מוזיאון אדו-טוקיו",
        Description = "מוזיאון אדו-טוקיו מציג את ההיסטוריה של העיר טוקיו מאז ימי אדו ועד היום. מתאים לאוהבי היסטוריה ותרבות יפנית. שעות פתיחה: 09:30–17:30, סגור בימי שני.",
        Category = "מוזיאון",
        ImageUrl = "images/edo_tokyo_museum.jpg",
        Address = "Edo-Tokyo Museum, Tokyo"
    },
    new Attraction {
        Id = 14,
        Name = "אקיהברה (Akihabara)",
        Description = "אקיהברה הוא רובע טכנולוגיה ואנימה פופולרי עם חנויות גאדג'טים ותרבות פופ יפנית. מתאים לחובבי אלקטרוניקה, אנימה ומשחקים. שעות פתיחה: 10:00–20:00.",
        Category = "בילוי",
        ImageUrl = "images/akihabaraPIC.jpg",
        Address = "Akihabara, Tokyo"
    },
    new Attraction {
        Id = 15,
        Name = "גן החיות אואנו",
        Description = "גן החיות אואנו נמצא בתוך פארק אואנו ומציג מגוון חיות מרחבי העולם. מתאים למשפחות עם ילדים וחובבי טבע. שעות פתיחה: 09:30–17:00, סגור בימי שני.",
        Category = "טבע",
        ImageUrl = "images/ueno_zoo.jpg",
        Address = "Ueno Zoo, Tokyo"
    },

    new Attraction {
        Id = 16,
        Name = "אודייבה (Odaiba)",
        Description = "אודייבה הוא אי מלאכותי עם קניונים, מוזיאונים ואטרקציות שונות. מתאים למשפחות, זוגות ומי שמחפש בילוי מלא באקשן. שעות פתיחה: הקניונים 11:00–20:00, אזור פתוח 24/7.",
        Category = "בילוי",
        ImageUrl = "images/odaiba.jpg",
        Address = "Odaiba, Tokyo"
    },
    new Attraction {
        Id = 17,
        Name = "מקדש מייג'י (Meiji Jingu)",
        Description = "מקדש מייג'י נמצא בתוך יער טבעי במרכז טוקיו והוא מוקד רוחני חשוב. מתאים למי שמחפש שלווה, טיול בטבע והיכרות עם תרבות יפנית מסורתית. שעות פתיחה: 06:00–16:30, משתנה לפי עונה.",
        Category = "בילוי",
        ImageUrl = "images/meiji_shrine.jpg",
        Address = "Meiji Jingu, Tokyo"
    },
    new Attraction {
        Id = 18,
        Name = "רחוב טאקשיטה (Takeshita Street)",
        Description = "רחוב טאקשיטה הוא רחוב אופנה צעיר ופופולרי בהריג'וקו, מלא חנויות ייחודיות וקיוסקים. מתאים לנערים, חובבי אופנה ואוהבי סצנת הקולקטיב הצעיר. שעות פתיחה: 10:00–19:00.",
        Category = "קניות",
        ImageUrl = "images/street1.jpg",
        Address = "Takeshita Street, Tokyo"
    },
    new Attraction {
        Id = 19,
        Name = "שוק אמייוקו (Ameyoko)",
        Description = "שוק אמייוקו הוא שוק רחוב סואן ליד תחנת אואנו עם חנויות אוכל, בגדים ומזכרות. מתאים לחובבי שווקים, אוכל רחוב וקניות בזול. שעות פתיחה: 10:00–20:00.",
        Category = "קניות",
        ImageUrl = "images/amaya_market.jpg",
        Address = "Ueno, Tokyo"
    },
    new Attraction {
        Id = 20,
        Name = "קבוקיצ'ו (Kabukicho)",
        Description = "קבוקיצ'ו הוא רובע חיי לילה תוסס עם מסעדות, ברים וקולנועים. מתאים למבוגרים, חובבי בילוי לילי ואטרקציות עירוניות. שעות פתיחה: 18:00–05:00.",
        Category = "בילוי",
        ImageUrl = "images/kabukicho.jpg",
        Address = "Kabukicho, Tokyo"
    },
    new Attraction {
        Id = 21,
        Name = "גשר ריינבואו (Rainbow Bridge)",
        Description = "גשר ריינבואו הוא גשר תלוי מפורסם עם נוף מרהיב על מפרץ טוקיו. מתאים לחובבי צילום ונופים עירוניים. שעות פתיחה: 09:00–21:00, בחורף עד 18:00.",
        Category = "בילוי",
        ImageUrl = "images/rainbow_bridge.jpg",
        Address = "Rainbow Bridge, Tokyo"
    },
    new Attraction {
        Id = 22,
        Name = "שיבויה סקיי (Shibuya Sky)",
        Description = "שיבויה סקיי הוא גג תצפית מודרני במגדל Shibuya Scramble Square עם נופים פנורמיים. מתאים לצלמים ומי שרוצה חוויית תצפית ייחודית. שעות פתיחה: 10:00–22:30.",
        Category = "בילוי",
        ImageUrl = "images/shibuya_sky.jpg",
        Address = "Shibuya Scramble Square, Tokyo"
    },
    new Attraction {
        Id = 23,
        Name = "פארק יויוגי (Yoyogi Park)",
        Description = "פארק יויוגי הוא פארק פתוח עם מדשאות, שבילים וגנים במרכז טוקיו. מתאים לפיקניקים, ריצה, יוגה וטיולים עם חברים או משפחה. שעות פתיחה: 24/7.",
        Category = "פארק",
        ImageUrl = "images/yoyogi_park.jpg",
        Address = "Yoyogi Park, Tokyo"
    },
    new Attraction {
        Id = 24,
        Name = "מוזיאון גיבלי (Ghibli Museum)",
        Description = "מוזיאון גיבלי הוא מוזיאון אנימציה שמוקדש לסרטי סטודיו גיבלי המפורסמים. מתאים למשפחות, חובבי אנימציה ותרבות יפנית. שעות פתיחה: 10:00–18:00, סגור שלישי.",
        Category = "מוזיאון",
        ImageUrl = "images/ghibli_museum.jpg",
        Address = "Mitaka, Tokyo"
    },
    new Attraction {
        Id = 25,
        Name = "רופונגי הילס (Roppongi Hills)",
        Description = "רופונגי הילס הוא מתחם קניות ובילוי יוקרתי עם מסעדות, גלריות ותצפית עירונית. מתאים לחובבי קניות, מסעדות ואמנות מודרנית. שעות פתיחה: 11:00–21:00.",
        Category = "בילוי",
        ImageUrl = "images/roppongi_hills.jpg",
        Address = "Roppongi Hills, Tokyo"
    },
    new Attraction {
        Id = 26,
        Name = "נהר המגורו (Nakameguro)",
        Description = "נהר המגורו הוא אזור ציורי לאורך נהר עם עצי סאקורה, בתי קפה וחנויות בוטיק. מתאים לטיול רומנטי, צילום וטיול ביפן המסורתית והמודרנית יחד. שעות פתיחה: 24/7.",
        Category = "טבע",
        ImageUrl = "images/nakameguro.jpg",
        Address = "Nakameguro, Tokyo"
    },
    new Attraction {
        Id = 27,
        Name = "הראג'וקו (Harajuku)",
        Description = "הראג'וקו הוא רובע אופנה צעיר עם חנויות טרנדיות ואווירה צבעונית. מתאים לנוער, חובבי אופנה ותרבות רחוב. שעות פתיחה: 10:00–20:00.",
        Category = "בילוי",
        ImageUrl = "images/harajuku.jpeg",
        Address = "Harajuku, Tokyo"
    },
    new Attraction {
        Id = 28,
        Name = "פוקימון סנטר (Pokemon Center)",
        Description = "פוקימון סנטר הוא חנות רשמית עם מוצרי פוקימון נדירים ומשחקים. מתאים לילדים, חובבי פוקימון ואספני מרצ'נדייז. שעות פתיחה: 10:00–21:00.",
        Category = "קניות",
        ImageUrl = "images/pokemon_center.jpeg",
        Address = "Tokyo"
    },
    new Attraction {
        Id = 29,
        Name = "מייד קפה (Maid Cafe)",
        Description = "מייד קפה הוא חוויה יפנית ייחודית עם מלצריות בלבוש מייד שמבצעות הופעות קטנות. מתאים למבוגרים, חובבי תרבות פופ יפנית ואווירה יוצאת דופן. שעות פתיחה: 11:00–23:00.",
        Category = "בילוי",
        ImageUrl = "images/maid_cafe.jpg",
        Address = "Akihabara, Tokyo"
    },
    new Attraction {
        Id = 30,
        Name = "Shibuya PARCO",
        Description = "Shibuya PARCO הוא קניון מודרני עם חנויות אופנה, מסעדות ואומנות עכשווית. מתאים לנוער ומבוגרים שאוהבים אופנה, קניות וחוויות תרבותיות. שעות פתיחה: 11:00–21:00.",
        Category = "קניות",
        ImageUrl = "images/shibuya_parco.png",
        Address = "Shibuya PARCO, Tokyo"
    },
    new Attraction {
        Id = 31,
        Name = "ארמון הקיסר (Imperial Palace)",
        Description = "ארמון הקיסר הוא מקום מגוריו הרשמי של קיסר יפן, מוקף גנים ומבנים היסטוריים. מתאים לאוהבי היסטוריה, טבע וטיולים בעיר. שעות פתיחה: אזורים חיצוניים פתוחים 24/7, סיורים מודרכים בשעות מוגבלות.",
        Category = "טבע",
        ImageUrl = "images/imperial_palace.jpg",
        Address = "Imperial Palace, Tokyo"
    },
    new Attraction {
        Id = 32,
        Name = "גן ריקוגיאן (Rikugien Garden)",
        Description = "גן ריקוגיאן הוא גן יפני מסורתי יפהפה עם בריכות, גשרים וצמחייה מסודרת. מתאים לחובבי טבע, תרבות יפנית ורגיעה. שעות פתיחה: 09:00–17:00, כניסה אחרונה 16:30.",
        Category = "פארק",
        ImageUrl = "images/rikugien.jpeg",
        Address = "Rikugien, Tokyo"
    },
    new Attraction {
        Id = 33,
        Name = "Tokyo Dome City",
        Description = "Tokyo Dome City הוא מתחם בילוי גדול עם פארק שעשועים, קניונים ואטרקציות ספורט. מתאים למשפחות, חובבי ספורט ובילוי עירוני. שעות פתיחה: 10:00–21:00, משתנה לפי אזור.",
        Category = "בילוי",
        ImageUrl = "images/tokyo_dome.webp",
        Address = "Tokyo Dome City"
    },
    new Attraction {
        Id = 34,
        Name = "מוזיאון המדע הלאומי (National Museum of Nature and Science)",
        Description = "מוזיאון המדע הלאומי מציג תערוכות מדע, טבע וחלל. מתאים למשפחות, תלמידים וחובבי מדע. שעות פתיחה: 09:00–17:00, סגור בימי שני.",
        Category = "מוזיאון",
        ImageUrl = "images/science_museum.jpeg",
        Address = "National Museum of Nature and Science, Tokyo"
    },
    new Attraction {
        Id = 35,
        Name = "Nezu Museum",
        Description = "Nezu Museum מציע אוספי אמנות יפנית וגן מסורתי יפהפה. מתאים לחובבי אמנות, תרבות ונוף מרגיע. שעות פתיחה: 10:00–17:00, כניסה אחרונה 16:30.",
        Category = "מוזיאון",
        ImageUrl = "images/nezu.jpg",
        Address = "Nezu Museum, Tokyo"
    },
    new Attraction {
        Id = 36,
        Name = "רחוב אומוטסנדו (Omotesando)",
        Description = "שדרת אומוטסנדו היא שדרת קניות יוקרתית עם מותגים עולמיים וארכיטקטורה מרשימה. מתאים לחובבי אופנה, קניות ואסתטיקה עירונית. שעות פתיחה: 10:00–20:00, משתנה לפי חנות.",
        Category = "קניות",
        ImageUrl = "images/omotesando.png",
        Address = "Omotesando, Tokyo"
    },
    new Attraction {
        Id = 37,
        Name = "Daikanyama",
        Description = "Daikanyama הוא אזור רגוע עם חנויות בוטיק, בתי קפה וגנים קטנים. מתאים לטיול רגוע, קניות ייחודיות ולחובבי תרבות אורבנית. שעות פתיחה: 10:00–20:00, משתנה לפי עסקים.",
        Category = "בילוי",
        ImageUrl = "images/daikanyama.jpeg",
        Address = "Daikanyama, Tokyo"
    },
    new Attraction {
        Id = 38,
        Name = "Oedo Onsen Monogatari",
        Description = "קומפלקס אונסן עם בריכות חמות וחוויות מסורתיות יפניות. מתאים למבוגרים ולזוגות שמחפשים רגיעה ותרבות יפנית. שעות פתיחה: 11:00–23:00, שעות משתנות לפי אזורים.",
        Category = "בילוי",
        ImageUrl = "images/onsen.jpeg",
        Address = "Tokyo"
    },
    new Attraction {
        Id = 39,
        Name = "Hamarikyu Gardens",
        Description = "Hamarikyu Gardens הוא גן יפני מסורתי על רקע גורדי שחקים. מתאים למי שמחפש שלווה, טבע ואסתטיקה יפנית. שעות פתיחה: 09:00–17:00, כניסה אחרונה 16:30.",
        Category = "פארק",
        ImageUrl = "images/hamarikyu.jpeg",
        Address = "Hamarikyu Gardens, Tokyo"
    },
    new Attraction {
        Id = 40,
        Name = "Asakusa Culture Tourist Center",
        Description = "מרכז מידע ותצפית ליד מקדש סנסו-ג'י, עם מבט פנורמי על הרובע. מתאים למבקרים המעוניינים במידע מקיף ותצפית על אסאקוסה. שעות פתיחה: 09:00–20:00.",
        Category = "בילוי",
        ImageUrl = "images/asakusa_center.webp",
        Address = "Asakusa, Tokyo"
    },
    new Attraction {
        Id = 41,
        Name = "Sumida Aquarium",
        Description = "Sumida Aquarium הוא אקווריום מודרני במגדל סקייטרי עם מגוון דגים ויצורים ימיים. מתאים למשפחות, ילדים וחובבי טבע. שעות פתיחה: 10:00–20:00.",
        Category = "בילוי",
        ImageUrl = "images/aquarium.jpg",
        Address = "Tokyo Skytree Town"
    },
    new Attraction {
        Id = 42,
        Name = "Kappabashi Street",
        Description = "רחוב Kappabashi הוא רחוב כלי מטבח עם חנויות רבות למכשירי בישול מקצועיים ואומנות מזון. מתאים לשפים, חובבי בישול ואספנים של כלי מטבח יפניים. שעות פתיחה: 10:00–17:00, משתנה לפי חנות.",
        Category = "קניות",
        ImageUrl = "images/kappabashi.jpeg",
        Address = "Kappabashi, Tokyo"
    },
    new Attraction {
        Id = 43,
        Name = "Tokyo International Forum",
        Description = "מרכז כנסים ואירועים מודרני עם עיצוב אדריכלי מרהיב. מתאים לאירועים, כנסים ותערוכות, וגם למבקרים הרוצים לראות מבנה ייחודי. שעות פתיחה: 07:00–23:30.",
        Category = "בילוי",
        ImageUrl = "images/forum.jpeg",
        Address = "Tokyo International Forum"
    },
    new Attraction {
        Id = 44,
        Name = "Meguro Parasitological Museum",
        Description = "מוזיאון ייחודי שמוקדש למחקר טפילים ומציג אוספים מיוחדים. מתאים למי שמתעניין במדע, ביולוגיה ומוזיאונים יוצאי דופן. שעות פתיחה: 10:00–17:00, סגור בימי שני.",
        Category = "מוזיאון",
        ImageUrl = "images/parasite.jpg",
        Address = "Meguro, Tokyo"
    },
    new Attraction {
        Id = 45,
        Name = "Tokyo Opera City",
        Description = "Tokyo Opera City הוא מרכז תרבות עם מופעי אופרה, קונצרטים ואירועים אמנותיים. מתאים לחובבי מוזיקה, תרבות והופעות חיות. שעות פתיחה: 11:00–19:00.",
        Category = "בילוי",
        ImageUrl = "images/opera.jpeg",
        Address = "Tokyo Opera City"
    },
    new Attraction {
        Id = 46,
        Name = "Odaiba Seaside Park",
        Description = "פארק חוף מרהיב על אודייבה עם מסלולי הליכה ונוף לים. מתאים לפיקניקים, ספורט ואוהבי טבע וחופים. שעות פתיחה: 24/7.",
        Category = "פארק",
        ImageUrl = "images/odaiba_park.jpg",
        Address = "Odaiba, Tokyo"
    },
    new Attraction {
        Id = 47,
        Name = "Tokyo Joypolis",
        Description = "Tokyo Joypolis הוא פארק משחקים מקורה עם רכבות הרים וטרקיות אינטראקטיביות. מתאים לילדים, בני נוער ומבוגרים שאוהבים אקשן ומשחקים. שעות פתיחה: 10:00–22:00.",
        Category = "בילוי",
        ImageUrl = "images/joypolis.jpeg",
        Address = "Odaiba, Tokyo"
    },
    new Attraction {
        Id = 48,
        Name = "Edo-Tokyo Open Air Architectural Museum",
        Description = "מוזיאון פתוח המציג מבנים היסטוריים מהעיר טוקיו של תקופת אדו. מתאים לחובבי היסטוריה, אדריכלות וטיולים חווייתיים. שעות פתיחה: 09:30–17:30, סגור בימי שני.",
        Category = "מוזיאון",
        ImageUrl = "images/open_air.jpeg",
        Address = "Koganei, Tokyo"
    },
    new Attraction {
        Id = 49,
        Name = "Gotokuji Temple",
        Description = "מקדש Gotokuji מפורסם בשל חתולי המזל המצוירים והפסלים. מתאים לחובבי תרבות יפנית, צילום ומיתוסים. שעות פתיחה: 09:00–17:00.",
        Category = "בילוי",
        ImageUrl = "images/gotokuji.jpg",
        Address = "Gotokuji, Tokyo"
    },
    new Attraction {
        Id = 50,
        Name = "Ikebukuro Sunshine Aquarium",
        Description = "אקווריום מודרני בתוך קומפלקס סאנשיין עם מגוון בעלי חיים ימיים. מתאים למשפחות, ילדים וחובבי טבע. שעות פתיחה: 10:00–20:00.",
        Category = "בילוי",
        ImageUrl = "images/sunshine_aquarium.jpg",
        Address = "Sunshine City, Tokyo"
    },
    new Attraction {
        Id = 51,
        Name = "Tokyo Metropolitan Government Building",
        Description = "בניין הממשל של טוקיו מציע תצפית חינם על העיר מלמעלה. מתאים לצלמים, מטיילים וחובבי נוף עירוני. שעות פתיחה: 09:30–23:00, סגור שני.",
        Category = "בילוי",
        ImageUrl = "images/tokyo_government.jpeg",
        Address = "Shinjuku, Tokyo"
    }
        }; 
        }
    }
}

