using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratorka_2.Task_1
{
    public class Firma
    {
        private string? name;
        private string? profile;
        private string? pid_derector;
        private int employeers;
        private string? adrees;
        public DateTime Date { get; set; }
        public Firma() { }
        public Firma(string name, string profile, string pid_derector, int employeers, string adrees, DateTime date)
        {
            this.name = name;
            this.profile = profile;
            this.pid_derector = pid_derector;
            this.employeers = employeers;
            this.adrees = adrees;
            Date = date;
        }
        public string Name
        {

            get { return name ?? "No name"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    name = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string Profile
        {
            get { return profile ?? "No profile"; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();
                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    profile = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public string Pid_derector
        {
            get { return pid_derector ?? "No pid_derector"; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();
                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    pid_derector = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public int Employeers
        {
            get { return employeers; }
            set
            {

                if (value > 0)
                    Employeers = value;
                else
                    throw new ArgumentOutOfRangeException();

            }
        }
        public string Adrees
        {

            get { return adrees ?? "No adrees"; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { return; }
                value = value.Trim();


                if (Regex.IsMatch(value, @"^[\p{L}\s'-]+$"))
                    adrees = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
        public override string ToString()
        {
            return $"{Name}, директор: {Pid_derector}, співробітників: {Employeers}, профіль: {Profile}, адреса: {Adrees}, засновано: {Date.ToShortDateString()}";
        }
    }
}
