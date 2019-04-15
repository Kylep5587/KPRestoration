/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * PurchasedVehicle.cs - stores data related to vehicles *
 *  which have been purchased                            *
 *  Inherits from Vehicle                                *
 * ******************************************************/

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRestoration
{
    class PurchasedVehicle : Vehicle
    {
        DatabaseHelper db = new DatabaseHelper();

        // Members
        private string echeck;
        private DateTime purchaseDate;
        private DateTime listedDate;
        private DateTime saleDate;
        private decimal purchasePrice;
        private decimal salePrice;
        private int sellerID;
        private int buyerID;
        private int titleHolderID;

        public PurchasedVehicle(string Vin, int year, string make, string model, int mileage, string engine, string transmission, string color, string condition, decimal edmundsValue, decimal kbbValue, string echeck, string vehicleStatus, string notes, DateTime purchaseDate, decimal purchasePrice, int buyerID, int sellerID, int titleHolderID)
        {
            VIN = Vin;
            Year = year;
            Make = make;
            Model = model;
            Mileage = mileage;
            Engine = engine;
            Transmission = transmission;
            Color = color;
            Condition = condition;
            EdmundsValue = edmundsValue;
            KbbValue = kbbValue;
            Echeck = echeck;
            VehicleStatus = vehicleStatus;
            Notes = notes;
            PurchaseDate = purchaseDate;
            PurchasePrice = purchasePrice;
            BuyerID = buyerID;
            SellerID = sellerID;
            TitleHolderID = titleHolderID;
        }

        // Getters and setters
        public string Echeck { get => echeck; set => echeck = value; }
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
        public DateTime ListedDate { get => listedDate; set => listedDate = value; }
        public DateTime SaleDate { get => saleDate; set => saleDate = value; }
        public decimal PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
        public decimal SalePrice { get => salePrice; set => salePrice = value; }
        public int SellerID { get => sellerID; set => sellerID = value; }
        public int BuyerID { get => buyerID; set => buyerID = value; }
        public int TitleHolderID { get => titleHolderID; set => titleHolderID = value; }


        public bool AddVehicle(PurchasedVehicle newVehicle)
        {
            string query = "INSERT INTO Vehicles (VIN, modelYear, make, model, mileage, engineSize, transmission, color, vehicleCondition, edmundsValue, kbbValue, echeckStatus, purchaseDate, listedDate, saleDate, purchasePrice, salePrice, vehicleStatus, sellerID, buyerID, titleHolderID, notes) " +
                           "VALUES (@VIN, @ModelYear, @Make, @Model, @Mileage, @Engine, @Transmission, @Color, @Condition, @EdmundsValue, @KBBValue," +
                           " @EcheckStatus, @PurchaseDate, @ListedDate, @SaleDate, @PurchasePrice, @SalePrice, @Status, @SellerID, @BuyerID, @TitleHolderID, @Notes);";
            MySqlCommand cmd = new MySqlCommand(query, db.conn);

            cmd.Parameters.AddWithValue("@VIN", newVehicle.VIN);
            cmd.Parameters.AddWithValue("@ModelYear", newVehicle.Year);
            cmd.Parameters.AddWithValue("@Make", newVehicle.Make);
            cmd.Parameters.AddWithValue("@Model", newVehicle.Model);
            cmd.Parameters.AddWithValue("@Mileage", newVehicle.Mileage);
            cmd.Parameters.AddWithValue("@Engine", newVehicle.Engine);
            cmd.Parameters.AddWithValue("@Transmission", newVehicle.Transmission);
            cmd.Parameters.AddWithValue("@Color", newVehicle.Color);
            cmd.Parameters.AddWithValue("@Condition", newVehicle.Year);
            cmd.Parameters.AddWithValue("@EdmundsValue", newVehicle.EdmundsValue);
            cmd.Parameters.AddWithValue("@KBBValue", newVehicle.KbbValue);
            cmd.Parameters.AddWithValue("@EcheckStatus", newVehicle.echeck);
            cmd.Parameters.AddWithValue("@PurchaseDate", newVehicle.PurchaseDate); // Change to proper data format
            cmd.Parameters.AddWithValue("@ListedDate", newVehicle.ListedDate);
            cmd.Parameters.AddWithValue("@SaleDate", newVehicle.SaleDate);
            cmd.Parameters.AddWithValue("@PurchasePrice", newVehicle.PurchasePrice);
            cmd.Parameters.AddWithValue("@SalePrice", newVehicle.SalePrice);
            cmd.Parameters.AddWithValue("@Status", newVehicle.VehicleStatus);
            cmd.Parameters.AddWithValue("@SellerID", newVehicle.SellerID);
            cmd.Parameters.AddWithValue("@BuyerID", newVehicle.BuyerID);
            cmd.Parameters.AddWithValue("@TitleHolderID", newVehicle.TitleHolderID);
            cmd.Parameters.AddWithValue("@Notes", newVehicle.Notes);

            bool insertSuccess = db.ExecuteCommand(cmd);
            return insertSuccess;
        }
    }
}
