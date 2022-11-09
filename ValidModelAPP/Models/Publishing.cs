﻿namespace ValidModelAPP.Models
{
    public class Publishing
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string? Name { get; set; }
        public List<Book> Books { get; set; } = new();
    }
}
