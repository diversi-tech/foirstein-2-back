﻿using DAL.DalApi;
using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DalApi;
namespace DAL.IDal
{
    public interface IItem : IblCrud<Item>
    {
        Task<IEnumerable<Item>> ReadByString(String searchKey);
        Task<IEnumerable<Item>> ReadByCategory(String category);
        Task<IEnumerable<Item>> ReadByAttributes(Item searchItem);
        Task<IEnumerable<Item>> ReadTheRecommended();
        Task<IEnumerable<Item>> ReadByTag(int tagId);
        Task<IEnumerable<Item>> ReadMostRequested();
        Task<IEnumerable<Item>> ReadSavedItems(int userId);
        Task<List<Item>> ReadAllIncloud(Item item);
        Task<Item> ReadbyIdIncloud(int idItem);
        Task<IEnumerable<Item>> ItemSuggestions(Item selectedItem);
    }
}
