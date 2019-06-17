using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace laba6.Models
{
    static class DbInitializer
    {
        public static void Initialize(ApplicationContext db)
        {
            if (db.Classes.Any())
            {
                return;   // База данных инициализирована
            }

            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            Random rand = new Random();
            string[] classTypes = new string[4];

            for (int i = 0; i < classTypes.Length; i++)
            {
                string word = "";
                for (int j = 1; j <= rand.Next(2, 5); j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);

                    word += letters[letter_num];
                }
                classTypes[i] = word;
            }
            string[] subjects = new string[4];

            for (int i = 0; i < subjects.Length; i++)
            {
                string word = "";
                for (int j = 1; j <= rand.Next(2, 5); j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);

                    word += letters[letter_num];
                }
                subjects[i] = word;
            }

            for (int i = 0; i < classTypes.Length; i++)
            {
                db.ClassTypes.Add(new ClassType { Name = Char.ConvertFromUtf32(Char.ConvertToUtf32("А", 0) + i), Description = classTypes[i] });
            }

            db.SaveChanges();

            for (int i = 0; i < subjects.Length; i++)
            {
                db.Subjects.Add(new Subject { Name = subjects[i], Description = subjects[i] });
            }

            db.SaveChanges();

            for (int i = 0; i < classTypes.Length; i++)
            {
                string word = "";
                for (int j = 1; j <= rand.Next(2, 5); j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);

                    word += letters[letter_num];
                }
                db.Classes.Add(new Class { ClassLead = word, ClassTypeId = i + 1, Count = 10 + 2 * i, Date = DateTime.Now });
            }

            db.SaveChanges();

            for (int i = 0; i < classTypes.Length; i++)
            {
                string word = "";
                for (int j = 1; j <= rand.Next(2, 5); j++)
                {
                    int letter_num = rand.Next(0, letters.Length - 1);

                    word += letters[letter_num];
                }
                db.Students.Add(new Student { FIO = word, Birthday = DateTime.Now, Gender = "муж", ClassId = i + 1 });
            }

            db.SaveChanges();

            for (int i = 0; i < classTypes.Length; i++)
            {
                db.Schedules.Add(
                    new Schedule { Date = DateTime.Now, ClassId = i + 1, SubjectId = i + 1 }
                    );
            }

            db.SaveChanges();
        }
    }
}

