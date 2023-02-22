﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Contracts.Student;

public record CoursesStudentResponse(
    string Id,
    string LastName,
    string FirstName,
    List<CourseResponse> Courses);

public record CourseResponse(
    Guid Id,
    string Name,
    string Description,
    double PersentPassing);
