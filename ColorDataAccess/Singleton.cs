using System;
using System.Collections.Generic;
using System.Text;


namespace ColorDataAccess
{
    public class Singleton
    {
        private static Singleton _instance;//dependency injection verifies one access at a time
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

        public Facade.IColorFacade GetFacade()//retrieves facade class
        {
            return new Facade.ColorFacade();
        }
    }
}
