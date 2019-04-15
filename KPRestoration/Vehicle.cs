/******************************************
 * KP Restoration VMS                     *
 * Created 4/12/19 by Kyle Price          *
 * Vehicle.cs - used to create objects    *
 *  related to vehicles. Parent class for *
 *  PurchasedVehicle and PotetialVehicle  *
 *  classes                               *
 * ***************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPRestoration
{
    class Vehicle
    {
        // Members
        private string vin;
        private int year;
        private string make;
        private string model;
        private int mileage;
        private string engine;
        private string transmission;
        private string color;
        private string condition;
        private decimal edmundsValue;
        private decimal kbbValue;
        private string vehicleStatus;
        private string notes;


        // Getters and setters
        public string VIN { get => vin; set => vin = value; }
        public int Year { get => year; set => year = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Mileage { get => mileage; set => mileage = value; }
        public string Engine { get => engine; set => engine = value; }
        public string Transmission { get => transmission; set => transmission = value; }
        public string Color { get => color; set => color = value; }
        public string Condition { get => condition; set => condition = value; }
        public decimal EdmundsValue { get => edmundsValue; set => edmundsValue = value; }
        public decimal KbbValue { get => kbbValue; set => kbbValue = value; }
        public string VehicleStatus { get => vehicleStatus; set => vehicleStatus = value; }
        public string Notes { get => notes; set => notes = value; }
    }
}
