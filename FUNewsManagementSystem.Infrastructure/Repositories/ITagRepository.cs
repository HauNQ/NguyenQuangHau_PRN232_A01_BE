using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Infrastructure.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll();
        Tag? GetById(int id);
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(int id);

        void Save();
    }
}
