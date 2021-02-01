using ColorDataAccess.Model;
using System.Collections.Generic;

namespace ColorDataAccess.DataAccess
{
    interface IInventoryDAO
    {
        void DeleteColor(int id);
        Color GetColor(int id);
        IList<Color> GetColors();
        void UpdateColor(Color color);
        void InsertColor(Color color);
    }
}