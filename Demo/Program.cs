// <copyright file="Program.cs" company="Гылыба Л.Д.">
// Copyright (c) Гылыба Л.Д.. All rights reserved.
// </copyright>

namespace Demo
{
    using System;
    using System.Linq;
    using DataAccessLayer;
    using DemoSc;
    using Repository;

    /// <summary>
    /// Точка входа.
    /// </summary>
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var dataContext = new DataContext();

            try
            {
                var postRepository = new PostRepository(dataContext);
                _ = postRepository.Create(new Post("Уборщик", 10000000));

                foreach (var post in postRepository.GetAll())
                {
                    Console.WriteLine($"{post.Id} --> {post.Name}");
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception.Message);
            }
        }
    }
}