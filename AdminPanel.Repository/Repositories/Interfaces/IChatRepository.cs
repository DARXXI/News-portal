using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminPanel.Domain.Entities;

namespace AdminPanel.Repository.Repositories.Interfaces
{
    public interface IChatRepository<T> where T : BaseEntity
    {
        Message Create();
        Message[] GetAllMessages();
        Task<T> UpdateAsync(string json,int id, CancellationToken cancellationToken);
    }
}
