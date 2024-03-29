﻿using System;
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

        public string? VideoEmbedCode { get; }

        public ModuleEntity Module { get; }

        public IReadOnlyList<TaskEntity> Tasks => _tasks.AsReadOnly();

        public LessonEntity(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public LessonEntity(string name, string videoEmbedCode)
        {
            Id = Guid.NewGuid();
            Name = name;
            VideoEmbedCode = videoEmbedCode;
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
            if (_tasks.Any())
            {
                var maxOrder = _tasks.Max(m => m.Order);
                task.SetOrder(maxOrder + 1);
            }
            else
                task.SetOrder(1);

            _tasks.Add(task);
        }

        public int CountTask => _tasks.Count;
    }
}
