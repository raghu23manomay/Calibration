using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calibration.Models
{
    public class CustomerList
    {
       public string Customer_Name { get; set; }
       public string Address        { get; set; }
       public string City           { get; set; }
       public decimal? Pincode        { get; set; }
       public string Salutation     { get; set; }
       public string Contact_Person { get; set; }
       public string Mobile_No      { get; set; }
       public decimal? STD_Code       { get; set; }
       public decimal? Telephone_No   { get; set; }
       public decimal? Fax            { get; set; }
       public string Email_ID       { get; set; }
       public string Vendor_Code    { get; set; }
       public string Remarks        { get; set; }
       [Key]
       public int? Customer_ID    { get; set; }
       public int? Customer_Code  { get; set; }
       public string GST_Number { get; set; }
       public int? TotalRows { get; set; }
        
    }
}