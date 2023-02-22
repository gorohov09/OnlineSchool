using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Domain.Course.Entities
{
    public class ModuleEntity
    {
        private readonly List<LessonEntity> _lessons;

        public Guid Id { get; }

        public string Name { get; }

        public int Order { get; private set; }

        public CourseEntity Course { get; }

        public IReadOnlyList<LessonEntity> Lessons => _lessons.AsReadOnly();

        public ModuleEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public ModuleEntity()
        {

        }

        /// <summary>
        /// Добавление урока
        /// </summary>
        /// <param name="lesson"></param>
        public void AddLesson(LessonEntity lesson)
        {
            //Логика по установке номера курса по порядку. Подумать над вставкой курса в середину.
            //Следовательно, другие номера должны измениться
            var maxOrder = _lessons.Max(m => m.Order);
            lesson.SetOrder(maxOrder + 1);
            _lessons.Add(lesson);
        }

        public void SetOrder(int order) => Order = order;

        public int TotalCountTask() => _lessons.Sum(lesson => lesson.CountTask);
    }
}
