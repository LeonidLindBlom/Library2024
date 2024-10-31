// <copyright file="Employee.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DemoSc;

using Exeptions;
public sealed class Employee : Human
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Employee"/> class.
    /// </summary>
    /// <param name="firstName">Имя.</param>
    /// <param name="lastName">Фамилия.</param>
    /// <param name="patronicName">Отчество.</param>
    /// <param name="dateBirth">День рождения.</param>
    /// <param name="post">Должность.</param>
    /// <param name="postID">Идентификатор должности.</param>
    public Employee(string firstName, string lastName, string patronicName, DateOnly dateBirth, Gender gender, Post post, Guid postID)
        : base(firstName, lastName, patronicName, dateBirth, gender)
    {
        this.Post = post;
        this.PostID = post.ID;
    }

    /// <summary>
    /// Идентификатор должности.
    /// </summary>
    public Guid PostID { get; }

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
