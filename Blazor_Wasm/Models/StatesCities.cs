namespace Blazor_Wasm.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string? StateName { get; set; }
    }

    public class States : List<State>
    {
        public States()
        {
            Add(new State() { StateId = 1, StateName = "Andhra Pradesh" });
            Add(new State() { StateId = 2, StateName = "Arunachal Pradesh" });
            Add(new State() { StateId = 3, StateName = "Assam" });
            Add(new State() { StateId = 4, StateName = "Bihar" });
            Add(new State() { StateId = 5, StateName = "Chhattisgarh" });
            Add(new State() { StateId = 6, StateName = "Goa" });
            Add(new State() { StateId = 7, StateName = "Gujarat" });
            Add(new State() { StateId = 8, StateName = "Haryana" });
            Add(new State() { StateId = 9, StateName = "Himachal Pradesh" });
            Add(new State() { StateId = 10, StateName = "Jharkhand" });
            Add(new State() { StateId = 11, StateName = "Karnataka" });
            Add(new State() { StateId = 12, StateName = "Kerala" });
            Add(new State() { StateId = 13, StateName = "Maharashtra" });
        }
    }


    public class City
    {
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int StateId { get; set; }
    }

    public class Cities : List<City>
    {
        public Cities()
        {
            Add(new City() { CityId = 101, CityName = "Vizianagaram", StateId = 1 });
            Add(new City() { CityId = 102, CityName = "Prakasam", StateId = 1 });
            Add(new City() { CityId = 103, CityName = "West Godavari", StateId = 1 });
            Add(new City() { CityId = 104, CityName = "Kurnool", StateId = 1 });
            
             

            Add(new City() { CityId = 201, CityName = "Tawang", StateId = 2 });
            Add(new City() { CityId = 202, CityName = "Itanagar", StateId = 2 });
            Add(new City() { CityId = 203, CityName = "Naharlagun", StateId = 2 });
            Add(new City() { CityId = 204, CityName = "Along", StateId = 2 });

            Add(new City() { CityId = 301, CityName = "Baksa", StateId = 3 });
            Add(new City() { CityId = 302, CityName = "Jorhat", StateId = 3 });
            Add(new City() { CityId = 303, CityName = "Sivasagar", StateId = 3 });
            Add(new City() { CityId = 304, CityName = "Barpeta", StateId = 3 });
            

            Add(new City() { CityId = 401, CityName = "Araria", StateId = 4 });
            Add(new City() { CityId = 402, CityName = "Aurangabad", StateId = 4 });
            Add(new City() { CityId = 403, CityName = "Begusarai", StateId = 4 });
            Add(new City() { CityId = 404, CityName = "Patna", StateId = 4 });

            Add(new City() { CityId = 501, CityName = "Balod", StateId = 5 });
            Add(new City() { CityId = 502, CityName = "Baloda Bazar", StateId = 5 });
            Add(new City() { CityId = 503, CityName = "Balrampur", StateId = 5 });
            Add(new City() { CityId = 504, CityName = "Bastar", StateId = 5 });

            Add(new City() { CityId = 601, CityName = "North Goa", StateId = 6 });
            Add(new City() { CityId = 602, CityName = "South Goa", StateId = 6 });

            Add(new City() { CityId = 701, CityName = "Ahmedabad", StateId = 7 });
            Add(new City() { CityId = 702, CityName = "Amreli", StateId = 7 });
            Add(new City() { CityId = 703, CityName = "Baroda", StateId = 7 });
            Add(new City() { CityId = 704, CityName = "Surat", StateId = 7 });

            Add(new City() { CityId = 801, CityName = "Ambala", StateId = 8 });
            Add(new City() { CityId = 802, CityName = "Bhiwani", StateId = 8 });
            Add(new City() { CityId = 803, CityName = "Charkhi Dadri", StateId = 8 });
            Add(new City() { CityId = 804, CityName = "Fatehabad", StateId = 8 });

            Add(new City() { CityId = 901, CityName = "Bilaspur", StateId = 9 });
            Add(new City() { CityId = 902, CityName = "Chamba", StateId = 9 });
            Add(new City() { CityId = 903, CityName = "Kangra", StateId = 9 });
            Add(new City() { CityId = 904, CityName = "Kullu", StateId = 9 });

            Add(new City() { CityId = 1001, CityName = "Bokaro", StateId = 10 });
            Add(new City() { CityId = 1002, CityName = "Chatra", StateId = 10 });
            Add(new City() { CityId = 1003, CityName = "Deoghar", StateId = 10 });
            Add(new City() { CityId = 1004, CityName = "Dhanbad", StateId = 10 });

            Add(new City() { CityId = 1101, CityName = "Bagalkot", StateId = 11 });
            Add(new City() { CityId = 1102, CityName = "Ballari ", StateId = 11 });
            Add(new City() { CityId = 1103, CityName = "Bengaluru ", StateId = 11 });
            Add(new City() { CityId = 1104, CityName = "Bidar", StateId = 11 });


            Add(new City() { CityId = 1201, CityName = "Kannur", StateId = 12 });
            Add(new City() { CityId = 1202, CityName = "Kollam ", StateId = 12 });
            Add(new City() { CityId = 1203, CityName = "Kottayam ", StateId = 12 });
            Add(new City() { CityId = 1204, CityName = "Palakkad", StateId = 12 });

            Add(new City() { CityId = 1301, CityName = "Pune", StateId = 13 });
            Add(new City() { CityId = 1302, CityName = "Thane ", StateId = 13 });
            Add(new City() { CityId = 1303, CityName = "Nashik ", StateId = 13 });
            Add(new City() { CityId = 1304, CityName = "Kolhapur", StateId = 13 });

        }
    }
}
