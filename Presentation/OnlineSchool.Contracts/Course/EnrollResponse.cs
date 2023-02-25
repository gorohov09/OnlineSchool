using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Contracts.Course;

public record EnrollResponse(
    string CourseId,
    bool IsSuccess);