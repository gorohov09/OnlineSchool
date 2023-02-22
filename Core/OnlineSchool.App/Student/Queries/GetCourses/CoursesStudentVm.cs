using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.App.Student.Queries.GetCourses
{
    public record CoursesStudentVm(
        string Id,
        string LastName,
        string FirstName,
        List<CourseVm> Courses);

    public record CourseVm(
        Guid Id,
        string Name,
        string Description,
        double PersentPassing);
}
