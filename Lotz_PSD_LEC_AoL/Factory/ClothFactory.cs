using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Factory
{
    public class ClothFactory
    {
        public static Cloth CreateCloth(String clothName, String clothImage, int clothPrice, int clothStock, String clothDescription, int sizeID, int genderID)
        {
            Cloth c = new Cloth();
            c.ClothName = clothName;
            c.ClothImage = clothImage;
            c.ClothPrice = clothPrice;
            c.ClothStock = clothStock;
            c.ClothDescription = clothDescription;
            c.SizeID = sizeID;
            c.GenderID = genderID;
            return c;
        }
    }
}