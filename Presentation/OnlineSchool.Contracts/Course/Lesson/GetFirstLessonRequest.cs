using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Contracts.Course.Lesson;

public record GetFirstLessonRequest(
    string Id,
    string Name,
    string EmbedHtmlVideo);
