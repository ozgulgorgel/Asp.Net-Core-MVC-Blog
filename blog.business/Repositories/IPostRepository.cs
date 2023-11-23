using blog.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.business.Repositories
{
    public interface IPostRepository:IRepository<Post>
    {
    }
}
