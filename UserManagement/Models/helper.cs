using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Web.Models;

namespace UserManagement.Models
{
    public class WebHelper
    {

        public static IList<SelectListItem> CountryList
        {
            get
            {
                return new List<SelectListItem>()
            {
                new SelectListItem{ Selected=true,Text="-Select Country-",Value="0" },
                new SelectListItem{ Text="India",Value="1" },
                new SelectListItem{ Text="Sri Lanka",Value="2" }
            };
            }
        }
        public static IList<StateModel> StateList
        {
            get
            {
                return new List<StateModel>()
            {
                new StateModel{ Selected=true,Text="-Select State-",Value="0" },
                new StateModel{ Text="Himachal Pradesh",Value="1",CountryID=1 },
                new StateModel{ Text="Punjab",Value="2",CountryID=1 },
                new StateModel{ Text="Haryana",Value="3",CountryID=1 },

                new StateModel{ Text="Eastern",Value="4",CountryID=2 },
                new StateModel{ Text="Western",Value="5",CountryID=2 },
                new StateModel{ Text="Southern",Value="6",CountryID=2 }

            };
            }
        }

        public static IList<CityModel> CityList
        {
            get
            {
                return new List<CityModel>()
            {
                new CityModel{ Selected=true,Text="-Select City-",Value="0" },
                new CityModel{ Text="Una",Value="1",StateID=1 },
                new CityModel{ Text="Mandi",Value="2",StateID=1 },
                new CityModel{ Text="Shimla",Value="3",StateID=1 },

                new CityModel{ Text="Chandigarh",Value="4",StateID=2 },
                new CityModel{ Text="Mohali",Value="5",StateID=2 },
                new CityModel{ Text="Patiala",Value="6",StateID=2}

            };
            }
        }
        public static void LoadUserViewModel(UserViewModel UserViewModel)
        {
            UserViewModel.Countries = CountryList;
            UserViewModel.States = new List<SelectListItem>();
            UserViewModel.Cities = new List<SelectListItem>();
        }
    }
}