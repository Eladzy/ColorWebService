using System;
using System.Collections.Generic;
using System.Text;
using ColorDataAccess.DataAccess;
using ColorDataAccess.Model;
using System.Reflection;

namespace ColorDataAccess.Facade
{
    class ColorFacade : IColorFacade//wraps the dao functions and ajusting them
    {
        private InventoryDAO Inventory = new InventoryDAO();

        public Color Get(int id)
        {

            return Inventory.GetColor(id);
        }
        
        public void Insert(Color color)
        {
            Inventory.InsertColor(color);
        }

        public IList<Color> GetAll()
        {
            return Inventory.GetColors();
        }

        public void Update(Color color)
        {
            if (color.Id == 0)
            {
                return;
            }
            Color comparer = Get(color.Id);
            foreach (PropertyInfo property in color.GetType().GetProperties())
            {
                if (property.GetValue(color) is string)
                {
                    if (!string.IsNullOrWhiteSpace((string)property.GetValue(color)))
                    {
                        property.SetValue(comparer, property.GetValue(color));
                    }
                }
            }
            comparer.IsAvailable = color.IsAvailable;
            Inventory.UpdateColor(comparer);
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                return;
            }
            Inventory.DeleteColor(id);
        }
    }
}
