using OnlineSchool.Domain.Course;
using OnlineSchool.Domain.Student;

namespace OnlineSchool.Domain.InformationAdmission;

public class InformationAdmissionEntity
{
    public Guid Id { get; set; }

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

    public int CountCompletedTasks { get; }

    public InformationAdmissionEntity(StudentEntity student, CourseEntity course)
    {
        Id = Guid.NewGuid();
        Student = student;
        Course = course;
        DateAdmission = DateTime.Now;
    }

    public InformationAdmissionEntity()
    {

    }

    public double GetPercentPassing()
    {
        if (Course.CountTasks == 0) return 0;
        return ((double)CountCompletedTasks / (double)Course.CountTasks) * 100;
    }
}