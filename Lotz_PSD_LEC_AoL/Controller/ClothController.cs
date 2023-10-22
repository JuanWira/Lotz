using Lotz_PSD_LEC_AoL.Handler;
using Lotz_PSD_LEC_AoL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lotz_PSD_LEC_AoL.Controller
{
    public class ClothController
    {
        public static String validateCloth(String name, String desc, int price, int stock, String imagePath, bool fileExists, int fileSize, String fileExt, int size, int gender)
        {
            String response = "";
            // validasi name, desc, price, stock, img
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(desc) || price == 0 || stock == 0 || fileExists == false || size.ToString() == "" || gender.ToString() == "")
            {
                response = "All data must be filled";
            }
            else if (name.Length >= 50)
            {
                response = "Name length must be shorter than 50 characters";
            }
            else if (desc.Length >= 255)
            {
                response = "Description length must be shorter than 255 characters";
            }
            else if (price < 100000 || price > 1000000)
            {
                response = "Price must be between 100000 and 1000000";
            }
            else if (stock <= 0)
            {
                response = "Stock must be more than 0";
            }
            else if (fileExists == false)
            {
                response = "File must be chosen";
            }
            else
            {
                bool isValid = false;
                String[] validExt = { ".png", ".jpg", ".jpeg", ".jfif", ".PNG", ".JPG", ".JPEG", ".JFIF" };
                for (int i = 0; i < fileExt.Length; i++)
                {
                    if (fileExt.Equals(validExt[i]))
                    {
                        isValid = true;
                    }
                }

                if (isValid == false)
                {
                    response = "File extention must be .png, .jpg, .jpeg, .jfif";
                }
                else if (fileSize > 2048000)
                {
                    response = "File size must be lower than 2MB";
                }
            }
            return response;
        }

        public static void doInsertCloth(String name, String desc, int price, int stock, String image, int size, int gender)
        {
            ClothHandler.CreateCloth(name, desc, price, stock, image, size, gender);
        }

        public static void doUpdateCloth(int clothId, String name, String desc, int price, int stock, String image, int size, int gender)
        {
            ClothHandler.UpdateCloth(clothId, name, desc, price, stock, image, size, gender);
        }

        public static List<Cloth> GetHomeCloth()
        {
            return ClothHandler.GetHomeCloth();
        }

        public static List<Cloth> GetClothByIdList(int clothId)
        {
            return ClothHandler.GetClothByIdList(clothId);
        }

        public static Cloth GetClothById(int clothId)
        {
            return ClothHandler.GetClothById(clothId);
        }

        public static bool UpdateClothStock(int clothId, int qtyBought)
        {
            return ClothHandler.UpdateClothStock(clothId, qtyBought);
        }

        public static List<Cloth> GetClothByName(String s)
        {
            return ClothHandler.GetClothByName(s);
        }

        public static List<Cloth> GetCloth()
        {
            return ClothHandler.GetCloth();
        }

        public static List<Cloth> GetClothWomen()
        {
            return ClothHandler.GetClothWomen();
        }

        public static List<Cloth> GetClothMen()
        {
            return ClothHandler.GetClothMen();
        }

        public static bool RemoveCloth(int clothId)
        {
            return ClothHandler.RemoveCloth(clothId);
        }
    }
}