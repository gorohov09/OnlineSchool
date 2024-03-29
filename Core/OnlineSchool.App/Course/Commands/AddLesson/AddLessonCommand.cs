﻿using ErrorOr;
using MediatR;

namespace OnlineSchool.App.Course.Commands.AddLesson;

public record AddLessonCommand(
    string Name,
    string LinkVideo,
    string ModuleId) : IRequest<ErrorOr<string>>;