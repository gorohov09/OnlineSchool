using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Domain.InformationAdmission;

public class InformationAdmissionEntity
{
    /// <summary>
    /// Студент
    /// </summary>
    public StudentEntity Student { get; }

    /// <summary>
    /// Курс
    /// </summary>
    public CourseEntity Course { get; }

    /// <summary>
    /// Дата поступления
    /// </summary>
    public DateTime DateAdmission { get; }

    public InformationAdmissionEntity(StudentEntity student, CourseEntity course)
    {
        Student = student;
        Course = course;
        DateAdmission = DateTime.Now;
    }
}