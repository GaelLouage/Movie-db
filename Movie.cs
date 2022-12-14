//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieDatabase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public System.DateTime ReleaseDate { get; set; }
        public string Img { get; set; }
        public string Genre { get; set; }
        public string About { get; set; }
        public string ShortAbout => About.Split('.')[0];
        public string ShortDate => ReleaseDate.ToShortDateString();
    }
}
