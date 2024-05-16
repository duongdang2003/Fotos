using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DangNhapModel
    {
        private FotosDbContext context = null;
        public DangNhapModel() {
            context = new FotosDbContext();
        }
        public bool Login(String username, String password)
        {
<<<<<<< HEAD
            


=======
>>>>>>> 850bf8397263b2c5f80af6f77015b321ff303f60
            object[] sqlParams =
            {
                new SqlParameter("@username", username),
                new SqlParameter("@hashed_pass", password),
            };
            var res = context.Database.SqlQuery<bool>("Dang_nhap @username,@hashed_pass", sqlParams).SingleOrDefault();
            return res;
        }
    }
}
