using Blog.Core;
using Blog.Domain.ValueObjects;

namespace Blog.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }

        public Author()
        { }

        public Author(string name, Email email)
        {
            Name = name;
            Email = email;
        }
    }
}