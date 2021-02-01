using System;
using System.Collections.Generic;
using System.Text;


namespace ColorDataAccess
{
    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object Key = new object();
        private Singleton()
        {

        }
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                lock (Key)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }

        public Facade.IColorFacade GetFacade()
        {
            return new Facade.ColorFacade();
        }
    }
}
