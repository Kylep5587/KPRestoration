/*********************************************************
 * KP Restoration VMS                                    *
 * Created 4/12/19 by Kyle Price                         *
 * PotentialVehicle.cs - stores data related to vehicles *
 *  which are being researched but haven't been purchased*
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
    class PotentialVehicle : Vehicle
    {
        DatabaseHelper db = new DatabaseHelper();

        // Members
        private int id;
        private decimal askingPrice;
        private string seller;

        public PotentialVehicle(string vIN, int year, string make, string model, int mileage, string engine, string transmission, string color, string condition, decimal edmundsValue, decimal kbbValue, string vehicleStatus, string notes, string seller, decimal askingPrice)
        {
            VIN = vIN;
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
            VehicleStatus = vehicleStatus;
            Notes = notes;
            Seller = seller;
            AskingPrice = askingPrice;
        }

        // Getters and setters
        public int Id { get => id; set => id = value; }
        public decimal AskingPrice { get => askingPrice; set => askingPrice = value; }
        public string Seller { get => seller; set => seller = value; }


        public bool AddVehicle(PotentialVehicle newVehicle)
        {
            string query = "INSERT INTO Potentials (VIN, modelYear, make, model, mileage, engineSize, transmission, color, vehicleCondition, edmundsValue, kbbValue, askingPrice, seller, vehicleStatus, notes) " +
                           "VALUES (@VIN, @ModelYear, @Make, @Model, @Mileage, @Engine, @Transmission, @Color, @Condition, @EdmundsValue, @KBBValue," +
                           " @EcheckStatus, @AskingPrice, @Seller, @VehicleStatus, @Notes);";
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
            cmd.Parameters.AddWithValue("@AskingPrice", newVehicle.AskingPrice);
            cmd.Parameters.AddWithValue("@Seller", newVehicle.AskingPrice);
            cmd.Parameters.AddWithValue("@VehicleStatus", newVehicle.AskingPrice);
            cmd.Parameters.AddWithValue("@Notes", newVehicle.Notes);

            bool insertSuccess = db.ExecuteCommand(cmd);
            return insertSuccess;
        }
    }
}
