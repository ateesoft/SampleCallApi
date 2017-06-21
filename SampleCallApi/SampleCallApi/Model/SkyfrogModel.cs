using System.Collections.Generic;

namespace SampleCallApi.Model
{
    public class CreateJobSimple
    {
        public string CompanyID { get; set; }
        public string JobNo { get; set; }
        public int JobType => 8;
        public string JobStatus { get; set; }
        public string Ref1 { get; set; }
        public string Ref2 { get; set; }
        public string Ref3 { get; set; }
        public string Ref4 { get; set; }
        public string Remark { get; set; }
        public string LoadID { get; set; }
        public string HHID { get; set; }
        public string GroupID => "1000";
        public Customers Customer { get; set; }
        public Point Pickup { get; set; }
        public Point Shipping { get; set; }
        public List<Item> Items { get; set; }

        public CreateJobSimple()
        {
            Customer = new Customers();
            Pickup = new Point();
            Shipping = new Point();
            Items = new List<Item>();
        }
    }

    public class Customers
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string CustomerType => "D";
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int RadiusError => 100;
        public bool UpSert { get; set; }
    }

    public class Point
    {
        public string PointCode { get; set; }
        public string PointName { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ContactName { get; set; }
        public string ContactFullName { get; set; }
        public string Tel { get; set; }
        //public string Email { get; set; }
        public bool Notification => false;
        //public string DueDate { get; set; }
        //public string DueDateTime { get; set; }
        public int RadiusError => 100;
        public bool UpSert { get; set; }
    }

    public class Item
    {
        public int ItemNo { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public double Quantity { get; set; }
        public double ReceiveQuantity { get; set; }
        public string Unit { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Reference { get; set; }
    }


    public class ValidateModel
    {
        public string Coulums { get; set; }
        public string Description { get; set; }
    }

    public class ActionStatus
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }

    public class ResultWithModels
    {
        public ResultWithModels()
        {
            this.success = false;
            this.refcode = "200";
        }

        public bool success { get; set; }
        public string message { get; set; }
        public string refcode { get; set; }
        public int total { get; set; }
        public object datas { get; set; }
    }
}