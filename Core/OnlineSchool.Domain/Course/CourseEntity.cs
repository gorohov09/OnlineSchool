﻿using OnlineSchool.Domain.Course.Entities;
using OnlineSchool.Domain.Student;
using OnlineSchool.Domain.StudentCourseInformation;
using OnlineSchool.Domain.Teacher;

namespace OnlineSchool.Domain.Course;

/// <summary>
/// Курс
/// </summary>
public class CourseEntity
{
    private List<StudentCourseInformationEntity> _informationAdmissions = new();
    private List<ModuleEntity> _modules = new();

    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime Created { get; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime Updated { get; }

    public bool IsAvailable { get; }

    public double Rating { get; }

    public decimal Price { get; }

    public TeacherEntity Teacher { get; }

    public IReadOnlyList<StudentCourseInformationEntity> InformationAdmissions => _informationAdmissions.AsReadOnly();
    public IReadOnlyList<ModuleEntity> Modules => _modules.AsReadOnly();

    public CourseEntity(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;  
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    public CourseEntity()
    {

    }

    /// <summary>
    /// Добавление модуля
    /// </summary>
    /// <param name="module"></param>
    public void AddModule(ModuleEntity module)
    {
        //Логика по установке номера курса по порядку. Подумать над вставкой курса в середину.
        //Следовательно, другие номера должны измениться
        if (_modules.Any())
        {
            var maxOrder = _modules.Max(m => m.Order);
            module.SetOrder(maxOrder + 1);
        }
        else
            module.SetOrder(1);

        _modules.Add(module);
    }

    public bool IsEnrollStudent(Guid studentId)
    {
        return _informationAdmissions.Any(course => course.Student.Id == studentId);
    }

    public int GetCountTasks()
    {
        return _modules
            .SelectMany(m => m.Lessons)
            .SelectMany(l => l.Tasks)
            .Count();
    }

    public int GetCountLessons()
    {
        return _modules
            .SelectMany(m => m.Lessons)
            .Count();
    }

    public int GetCountModules()
    {
        return _modules.Count();
    }

    public int GetCountStudents()
    {
        return _informationAdmissions.Count();
    }

    /// <summary>
    /// Получить всех студентов курса
    /// </summary>
    /// <returns></returns>
    public List<StudentEntity> GetAllStudent()
    {
        try
        {
            if (_informationAdmissions is not null)
                return _informationAdmissions.Select(course => course.Student).ToList();
        }
        catch
        {
            throw new Exception("Вы пытаетесь получить студентов, но не подгрузили по ним данные");
        }

        throw new Exception("Вы пытаетесь получить студентов, но не подгрузили по ним данные");
    }
}
