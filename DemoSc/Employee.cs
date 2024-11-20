// <copyright file="Employee.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc;
using Exeptions;
using System.Linq.Expressions;

/// <summary>
/// Класс работник.
/// </summary>
public sealed class Employee : Human
{
    [Obsolete("For ORM only")]
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
    private Employee()
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Employee"/>.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronicName">Отчество.</param>
    /// <param name="dateBirth">День рождения.</param>
    /// <param name="gender">Пол.</param>
    /// <param name="kids">Дети.</param>
    /// <param name="post">Должность.</param>
    public Employee(string firstName, string lastName, string patronicName, DateOnly dateBirth, ISet<Kid> kids, Gender gender, Post post)
        : base(firstName, lastName, patronicName, dateBirth, gender)
    {
        foreach (var kid in kids)
        {
            kid.AddEmployee(this);
        }

        if (this.Post is not null)
        {
            _ = this.Post.AddEmployee(this);
        }
    }

    public Employee(string firstName, string lastName, string patronicName, DateOnly dateBirth, Gender gender, Post post, params Kid[] kids) 
        : this(firstName, lastName, patronicName, dateBirth, new HashSet<Kid>(kids), gender, post)
    {

    }

    /// <summary>
    /// Работники с детьми.
    /// </summary>
    public ISet<Kid> Kids { get; set; } = new HashSet<Kid>();


    /// <summary>
    /// Добавление ребенка.
    /// </summary>
    /// <param name="kid">Ребенок.</param>
    /// <returns>Ребенок добавлен.</returns>
    public bool AddKid(Kid kid)
    {
        if (kid is null)
        {
            return false;
        }

        if (this.Kids.Add(kid))
        {
            _ = kid.Employees.Add(this);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Удаление рребенка.
    /// </summary>
    /// <param name="kid">Ребенок.</param>
    /// <returns>Ребенок удален.</returns>
    public bool RemoveKid(Kid kid)
    {
        if (kid is null)
        {
            return false;
        }

        if (!this.Kids.Remove(kid)) 
        {
            kid.Employees.Remove(this);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Должность.
    /// </summary>
    public Post Post { get; set;  }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        var temp = obj as Employee;
        Post post = temp.Post;
        return base.Equals((Human?)temp) && this.Post == post;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return 0;
    }
}
