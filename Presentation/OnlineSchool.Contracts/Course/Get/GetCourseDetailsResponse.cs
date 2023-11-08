
namespace OnlineSchool.Contracts.Course.Get
{
	public record GetCourseDetailsResponse(
		string CourseId,
		string Name,
		string Description,
		double? PersentPassing,
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
