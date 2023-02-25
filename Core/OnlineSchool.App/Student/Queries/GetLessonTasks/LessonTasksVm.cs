using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.App.Student.Queries.GetLessonTasks;

public record LessonTasksVm(
    List<TaskVm> Tasks);

public record TaskVm(
    Guid Id,
    bool IsSolve);