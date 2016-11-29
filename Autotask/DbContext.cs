using Autotask.Models;
using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotask
{
    public class DbContext
    {
        public IObjectContainer GetDb()
        {
            return Db4oFactory.OpenFile("local.db");
        }

        public List<T> List<T>() where T : IDbModel
        {
            var db = GetDb();
            try
            {
                var result = db.Query<T>().ToList();
                return result;
            }
            finally
            {
                db.Close();
            }
        }

        public void Store<T>(T obj) where T : IDbModel
        {
            var db = GetDb();
            try
            {
                var temp = db.Query<T>(t => t.Id == obj.Id).FirstOrDefault();
                if (temp != null)
                {
                    obj.CopyTo(temp);

                    db.Store(temp);
                }
            }
            finally
            {
                db.Close();
            }
        }

        public void Remove<T>(T obj) where T : IDbModel
        {
            var db = GetDb();
            try
            {
                var temp = db.Query<T>(t => t.Id == obj.Id).FirstOrDefault();
                if (temp != null)
                {
                    db.Delete(temp);
                }
            }
            finally
            {
                db.Close();
            }
        }
    }
}
