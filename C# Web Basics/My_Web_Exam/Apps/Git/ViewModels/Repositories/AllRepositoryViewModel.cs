using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Repositories
{
    public class AllRepositoryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; } // is UserName

        public DateTime CreatedOn { get; set; } // or string??

        public int CommitsCount { get; set; }
    }
}
