using ColorDataAccess.Model;
using System.Collections.Generic;

namespace ColorDataAccess.Facade
{
    public interface IColorFacade
    {
        void Delete(int id);
        Color Get(int id);
        IList<Color> GetAll();
        void Update(Color color);
        void Insert(Color color);
    }
}