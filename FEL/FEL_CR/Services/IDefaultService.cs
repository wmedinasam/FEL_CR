using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEL_CR.Services
{
    public interface IDefaultService<T>
    {
        DataSet GetAll();

        DataSet GetById(int Id);

        DataSet Create(T obj);

        DataSet Update(T obj);
    }
}
