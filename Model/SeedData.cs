using Microsoft.EntityFrameworkCore;
using CIS169IntroToNET.Data;

namespace CIS169IntroToNET.Model;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CIS169IntroToNETContext(
                   serviceProvider.GetRequiredService<
                       DbContextOptions<CIS169IntroToNETContext>>()))
        {
            if (context == null || context.Course == null)
            {
                throw new ArgumentNullException("Null CIS169IntroToNETContext");
            }

            if (context.Course.Any())
            {
                return; // DB has been seeded
            }

            context.Course.AddRange(
                new Course
                {
                    Id = 185,
                    CourseDescription = "This course will introduce the concepts of design and development of websites.",
                    CourseName = "Beginning Webpage Development",
                    RoomNumber = 180
                },
                new Course
                {
                    Id = 121,
                    CourseDescription = "This course covers an introduction to programming logic.",
                    CourseName = "Intro to Programming Logic",
                    RoomNumber = 200
                },
                new Course
                {
                    Id = 598,
                    CourseDescription = "This course will focus on developing applications using the Python programming language.",
                    CourseName = "Python",
                    RoomNumber = 212
                },
                new Course
                {
                    Id = 110,
                    CourseDescription = "This course is an introduction to business computer software and hardware.",
                    CourseName = "Introduction to Computers",
                    RoomNumber = 220
                },
                new Course
                {
                    Id = 115,
                    CourseDescription = "This course is designed to assist students in illustrating the skills " +
                                        "necessary to obtain employment by aligning career goals with education plans and " +
                                        "practice the skills and attitudes required for job success.",
                    CourseName = "Employability Skills",
                    RoomNumber = 200
                }
            );
            context.SaveChanges();
        }
    }
}