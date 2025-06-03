using FUNewsManagementSystem.Core.DTOs;
using FUNewsManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Application.Services
{
    public interface INewsArticleService
    {
        IEnumerable<NewsArticleDTO> GetAll();
        NewsArticleDTO GetById(int id);
        int Add(NewsArticleDTO newsDTO);
        bool Update(NewsArticleDTO newsDTO);
        bool Delete(int id);
        IEnumerable<NewsArticleDTO> Search(string keyword);
    }

}
