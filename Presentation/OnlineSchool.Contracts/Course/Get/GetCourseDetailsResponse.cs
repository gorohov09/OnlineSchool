using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Contracts.Course.Get
{
	public record GetCourseDetailsResponse(
		string CourseId,
		string Name,
		string Description,
		DateTime Create,
		DateTime Update,
		List<ModuleResponse> Modules);

	public record ModuleResponse(
		string ModuleId,
		string Name,
		int Order,
		List<LessonResponse> Lessons);

	public record LessonResponse(
		string LessonId,
		int Order,
		string Name);
		








}
