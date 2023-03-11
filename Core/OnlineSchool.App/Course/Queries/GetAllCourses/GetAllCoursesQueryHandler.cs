using ErrorOr;
using MediatR;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Course.Queries.GetCourseDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.App.Course.Queries.GetAllCourses
{
	public class GetAllCoursesQueryHandler
		: IRequestHandler<GetAllCoursesQuery, ErrorOr<AllCoursesVm>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public GetAllCoursesQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public Task<ErrorOr<AllCoursesVm>> Handle
			(GetAllCoursesQuery request, 
			CancellationToken cancellationToken)
		{
			
		}
	}
}
