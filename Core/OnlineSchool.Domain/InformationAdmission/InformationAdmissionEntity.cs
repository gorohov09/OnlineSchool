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

    public int CountCompletedLessons { get; }

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
        var countJob = (double)Course.CountLessons + Course.CountLessons;
        var countCompletedJob = (double)CountCompletedLessons + CountCompletedTasks;
        return (countCompletedJob / countJob) * 100;
    }
}