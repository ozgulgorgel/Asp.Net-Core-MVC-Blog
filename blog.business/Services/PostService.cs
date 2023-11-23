using blog.business.Repositories;
using blog.data.Data;
using blog.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.business.Services
{
    public class PostService : Repository<Post>,IPostRepository
    {
        public PostService(blogcontext context) : base(context)
        {
        }
    }
}
