using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uslygi.Databases
{
    partial class TourInfo
    {
        public string FormatDate
        {
            get
            {
                if (StartTourDate != null && EndTourDate != null)
                {
                    DateTime date = (DateTime)StartTourDate;
                    DateTime dateend = (DateTime)EndTourDate;
                    return "Даты: " + date.ToShortDateString() + " - " +  dateend.ToShortDateString();
                }
                return string.Empty;
            }
        }

        public string FormatId
        {
            get
            {
                return "Номер тура: " + TourId;
            }
        }

        public string FormatName
        {
            get
            {
                return "Название тура: " + TourName;
            }
        }

        public string FormatCountPeople
        {
            get
            {
                return "Кол-во людей: " + AmountOfPeople;
            }
        }

        public string FormatCountNights
        {
            get
            {
                return "Кол-во ночей: " + AmountOfNights;
            }
        }

        public string FormatHotel
        {
            get
            {
                return "Страна, город, отель: "+ CountryName + ", " + CityName + ", " + HotelName;
            }
        }

        public string FormatVid
        {
            get
            {
                return "Вид тура: " + VidTourName;
            }
        }

        public string FormatType
        {
            get
            {
                return "Тип тура: " + TypeTourName;
            }
        }
        public string FormatPrice
        {
            get
            {
                return "Цена: " + CountPrice;
            }
        }
    }
}
