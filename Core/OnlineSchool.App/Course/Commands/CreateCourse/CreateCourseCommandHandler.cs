using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using OnlineSchool.App.Common.Interfaces.Persistence;
using OnlineSchool.App.Common.Interfaces.Services;
using OnlineSchool.Domain.Course;
using static OnlineSchool.Domain.Common.Errors.Errors;

namespace OnlineSchool.App.Course.Commands.CreateCourse;

public class CreateCourseCommandHandler
    : IRequestHandler<CreateCourseCommand, ErrorOr<bool>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateCourseCommandHandler> _logger;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork, IEmailService emailService, ILogger<CreateCourseCommandHandler> logger)
    {
        _unitOfWork = unitOfWork; 
        _emailService = emailService;
        _logger = logger;
    }

    public async Task<ErrorOr<bool>> Handle(
        CreateCourseCommand request, 
        CancellationToken cancellationToken)
    {
        //1. Создаем курс
        var course = new CourseEntity(request.Name, request.Description);

        //2. Добавляем курс в хранилище
        if (await _unitOfWork.Courses.Add(course))
			return await _unitOfWork.CompleteAsync();

		return false;
    }
}
