using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModel
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }


        public IEnumerable<Genre> Genres { get; set; }
        //String was not recognized as a valid DateTime
        //public DateTime DateTime
        //{
        //    get
        //    {

        //       return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        //    }
        //}

        public DateTime GetDateTime()
        {

            return DateTime.Parse(string.Format("{0} {1}", Date, Time));

        }

    }
}