// <copyright file="IEntity.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace DemoSc
{
    using System;

    /// <summary>
    /// Интерфейс базовой сущности.
    /// </summary>
    /// <typeparam name="TEntity"> Тип конкретной сущности. </typeparam>
    public interface IEntity<TEntity> : IEquatable<TEntity>
        where TEntity : class, IEntity<TEntity>
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        Guid Id { get; }
    }
}
