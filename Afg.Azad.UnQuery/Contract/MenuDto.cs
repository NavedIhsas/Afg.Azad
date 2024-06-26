using Shop.Management.Application.Contract.CourseGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Afg.Azad.UnQuery.Contract.ArticleCategory;

namespace Afg.Azad.UnQuery.Contract
{
    public class MenuDot
    {
        public List<CourseGroupViewModel> Courses { get; set; }
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
    }
}
