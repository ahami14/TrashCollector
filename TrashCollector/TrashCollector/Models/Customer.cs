using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]

        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Street Address")]
        public string streetAddress { get; set; }

        [DisplayName("City")]
        public string cityName { get; set; }

        [DisplayName("State")]
        public string stateName { get; set; }

        [DisplayName("Zip code")]
        public int zipCode { get; set; }

        [DisplayName("Balance due")]
        public double balanceDue { get; set; }

        [DisplayName("Start date")]
        public string startDate { get; set; }

        [DisplayName("End date")]
        public string endDate { get; set; }
        //Add a column for the weeky pick up date and extra date for pickup
        //then do a migration and fix changes

        [DisplayName("Weekly Pickup")]
        public string WeeklyPickup { get; set; }

        [DisplayName("Extra Pickup")]
        public string ExtraDate { get; set; }
        
        [DisplayName("Confirmed Pickup")]
        public bool? confirmedPickup { get; set; }



        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}