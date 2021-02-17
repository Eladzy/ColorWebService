using ColorDataAccess.Model;
using System.Collections.Generic;

namespace ColorDataAccess.DataAccess
{
    interface IInventoryDAO
    {
        void DeleteColor(int id);
        IColor GetColor(int id);
        IList<IColor> GetColors();
        void UpdateColor(IColor color);
        void InsertColor(IColor color);
    }
}