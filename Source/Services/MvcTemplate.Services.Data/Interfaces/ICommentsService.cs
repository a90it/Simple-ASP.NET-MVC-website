namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Models;

    public interface ICommentsService
    {
        void Create(Comment comment);
    }
}
