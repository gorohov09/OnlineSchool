using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Domain.Course.Entities
{
    public class LessonEntity
    {
        private readonly List<TaskEntity> _tasks = new();

        public Guid Id { get; }

        public string Name { get; }

        public int Order { get; private set; }

        public ModuleEntity Module { get; }

        public IReadOnlyList<TaskEntity> Tasks => _tasks.AsReadOnly();

        public LessonEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public LessonEntity()
        {

        }

        public void SetOrder(int order) => Order = order;

        /// <summary>
        /// Добавление задания
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(TaskEntity task)
        {
            //Логика по установке номера курса по порядку. Подумать над вставкой курса в середину.
            //Следовательно, другие номера должны измениться
            var maxOrder = _tasks.Max(m => m.Order);
            task.SetOrder(maxOrder + 1);
            _tasks.Add(task);
        }

        public int CountTask => _tasks.Count;
    }
}
