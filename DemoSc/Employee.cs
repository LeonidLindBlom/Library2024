// <copyright file="Employee.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc;
using Exeptions;

/// <summary>
/// Класс работник.
/// </summary>
public sealed class Employee : Human
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Employee"/>.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronicName">Отчество.</param>
    /// <param name="dateBirth">День рождения.</param>
    /// <param name="post">Должность.</param>
    /// <param name="postID">Идентификатор должности.</param>
    public Employee(string firstName, string lastName, string patronicName, DateOnly dateBirth, Gender gender, Post post)
        : base(firstName, lastName, patronicName, dateBirth, gender)
    {
        this.Post = post;
    }

    /// <summary>
    /// Должность.
    /// </summary>
    public Post Post { get; }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        var temp = obj as Employee;
        Post post = temp.Post;
        return base.Equals((Human?)temp) && this.Post == post;
    }
}
