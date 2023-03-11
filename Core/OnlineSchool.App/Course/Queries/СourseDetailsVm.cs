
namespace OnlineSchool.App.Course.Queries
{
	public record CourseDetailsVm(
		string CourseId,
		string Name,
		string Description,
		DateTime Create,
		DateTime Update,
		List<ModuleVm> Modules);

	public record ModuleVm(
		string ModuleId,
		string Name,
		int Order,
		List<LessonVm> Lessons);

	public record LessonVm(
		string LessonId,
		int Order,
		string Name);
}
