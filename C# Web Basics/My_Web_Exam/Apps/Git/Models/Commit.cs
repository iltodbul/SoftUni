﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Git.Models
{
    public class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public string RepositoryId { get; set; }
        public virtual Repository Repository { get; set; }
    }
}
