using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.models
{
    public abstract class PageViewModel
    {

    }

    public abstract class PageEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Title { get; set; }

    }
}
