using ColorDataAccess.Model;
using System.Collections.Generic;

namespace ColorDataAccess.Facade
{
    public interface IColorFacade
    {
        void Delete(int id);
        IColor Get(int id);
        IList<IColor> GetAll();
        void Update(IColor color);
        void Insert(IColor color);
    }
}