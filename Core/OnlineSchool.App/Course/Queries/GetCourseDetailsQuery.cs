using ErrorOr;
using MediatR;
using OnlineSchool.App.Student.Queries.GetCourses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.App.Course.Queries
{
	public record GetCourseDetailsQuery(
		string CourseId) : IRequest<ErrorOr<CourseDetailsVm>>;
	
}
