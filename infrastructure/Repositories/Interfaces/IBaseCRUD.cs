using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IBaseCRUD<T>
    {
        public Task<T> ReadOne(int id);
        public Task<bool> DeleteOne(int id);

        public Task<int> SetOne(T newObject);

        public Task<T> UpdateOne(int id);
    }
}
