using AdminPanel.Domain.Entities;

namespace AdminPanel.Domain.Models
{
    public class BaseModel<T>
    {
        public int LastRowIndex { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}