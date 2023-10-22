using Lotz_PSD_LEC_AoL.Factory;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Repository
{
    public class ClothRepository
    {
        private static LotzDatabaseEntities db = DatabaseSingleton.GetInstance();
        // view cloth
        public static List<Cloth> GetCloth()
        {
            return (from c in db.Clothes select c).ToList();
        }

        // insert, delete, update
        public static void CreateCloth(String name, String desc, int price, int stock, String image, int size, int gender)
        {
            Cloth c = ClothFactory.CreateCloth(name, image, price, stock, desc, size, gender);
            db.Clothes.Add(c);
            db.SaveChanges();
        }

        public static List<Cloth> GetHomeCloth()
        {
            List<Cloth> cl = (from c in db.Clothes orderby c.ClothID descending select c).ToList();
            List<Cloth> clothHome = new List<Cloth>();
            for (int i = 0; i < 3; i++)
            {
                clothHome.Add(cl.ElementAt(i));
            }
            return clothHome;
        }

        public static List<Cloth> GetClothMen()
        {
            return (from c in db.Clothes where c.GenderID == 2 select c).ToList();
        }

        public static List<Cloth> GetClothWomen()
        {
            return (from c in db.Clothes where c.GenderID == 1 select c).ToList();
        }

        public static List<Cloth> GetClothByIdList(int clothID)
        {
            return (from c in db.Clothes where c.ClothID == clothID select c).ToList();
        }

        public static Cloth GetClothById(int clothID)
        {
            return (from c in db.Clothes where c.ClothID == clothID select c).FirstOrDefault();
        }

        public static List<Cloth> GetClothByName(String clothName)
        {
            return (from c in db.Clothes where c.ClothName.Contains(clothName) select c).ToList();
        }

        public static bool UpdateCloth(int clothID, String name, String desc, int price, int stock, String image, int size, int gender)
        {
            Cloth c = GetClothById(clothID);
            if (c != null)
            {
                c.ClothName = name;
                c.ClothDescription = desc;
                c.ClothPrice = price;
                c.ClothStock = stock;
                c.ClothImage = image;
                c.Size.SizeId = size;
                c.Gender.GenderId = gender;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool UpdateClothStock(int clothId, int qtyBought)
        {
            Cloth c = GetClothById(clothId);
            if (c != null)
            {
                c.ClothStock = c.ClothStock - qtyBought;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool RemoveCloth(int clothId)
        {
            Cloth c = GetClothById(clothId);
            if (c != null)
            {
                db.Clothes.Remove(c);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool RemoveClothByArtist(List<Cloth> c)
        {
            if (c != null)
            {
                db.Clothes.RemoveRange(c);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static int GetPriceByID(int clothID)
        {
            return (from c in db.Clothes where c.ClothID == clothID select c.ClothPrice).FirstOrDefault();
        }
    }
}