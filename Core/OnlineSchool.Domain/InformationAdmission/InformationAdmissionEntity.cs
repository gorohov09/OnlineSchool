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

    public int CountCompletedTasks { get; set; }

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
        var countTaskCourse = Course.GetCountTasks();
        if (countTaskCourse == 0) return 0;
        return ((double)CountCompletedTasks / (double)countTaskCourse) * 100;
    }
}