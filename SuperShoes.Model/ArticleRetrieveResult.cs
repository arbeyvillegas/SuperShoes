using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Model
{
    public class ArticleRetrieveResult : RetrieveResult
    {
        public ICollection<Article> Articles { get; set; }
    }
}
