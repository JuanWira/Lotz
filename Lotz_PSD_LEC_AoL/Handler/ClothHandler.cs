using Lotz_PSD_LEC_AoL.Model;
using Lotz_PSD_LEC_AoL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Handler
{
    public class ClothHandler
    {
        public static List<Cloth> GetCloth()
        {
            return ClothRepository.GetCloth();
        }

        // insert, delete, update
        public static void CreateCloth(String name, String desc, int price, int stock, String image, int size, int gender)
        {
            ClothRepository.CreateCloth(name, desc, price, stock, image, size, gender);
        }

        public static List<Cloth> GetHomeCloth()
        {
            return ClothRepository.GetHomeCloth();
        }

        public static List<Cloth> GetClothWomen()
        {
            return ClothRepository.GetClothWomen();
        }

        public static List<Cloth> GetClothMen()
        {
            return ClothRepository.GetClothMen();
        }

        public static bool UpdateClothStock(int clothId, int qtyBought)
        {
            return ClothRepository.UpdateClothStock(clothId, qtyBought);
        }

            public static List<Cloth> GetClothByIdList(int clothId)
        {
            return ClothRepository.GetClothByIdList(clothId);
        }

        public static Cloth GetClothById(int clothId)
        {
            return ClothRepository.GetClothById(clothId);
        }

        public static List<Cloth> GetClothByName(String s)
        {
            return ClothRepository.GetClothByName(s);
        }

        public static int GetPriceById(int clothId)
        {
            return ClothRepository.GetPriceByID(clothId);
        }

        public static bool UpdateCloth(int clothId, String name, String desc, int price, int stock, String image, int size, int gender)
        {
            return ClothRepository.UpdateCloth(clothId, name, desc, price, stock, image, size, gender);
        }

        public static bool RemoveCloth(int clothId)
        {
            return ClothRepository.RemoveCloth(clothId);
        }
    }
}