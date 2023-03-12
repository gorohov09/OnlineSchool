using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.App.Course.Queries.GetAllCourses;

public record AllCoursesVm(
List<CourseVm> Courses);

public record CourseVm(
	string CourseId,
	string Name,
	string Description,
	int CountStudents,
	int CountModules,
	int CountLessons,
	int CountTasks,
	DateTime Create,
	DateTime Update);
