﻿using DAL.DalApi;
using DAL.IDal;
using DAL.models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DalService
{
    public class ItemService : IItem
    {
        private LiberiansDbContext _context;

        public ItemService(LiberiansDbContext context)
        {
            _context = context;
        }

        public Task<bool> Create(Item item)
        {
            throw new NotImplementedException();
        }
      

        public async Task<bool> Delete(Item item)
        {
            try
            {
                Item item1 = _context.Items.ToList().Find(t => t.Id == item.Id);
                _context.Items.Remove(item1);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Item>> ReadByString(string searchKey)
        {
            return _context.Items
                .Where(item => item.Title.Contains(searchKey) ||
                               item.Description.Contains(searchKey) ||
                               item.Category.Contains(searchKey) ||
                               item.Author.Contains(searchKey))
                .ToList();
        }

        public async Task<List<Item>> Read(Func<Item, bool> filter)
        {
            return _context.Items.Where(filter).ToList();
        }

        public async Task<Item> ReadbyId(int idItem)
        {
            Item? item = _context.Items.ToList().Find(t => t.Id == idItem);
            return item;
        }

        public Task<bool> Update(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> ReadAll()
        {
            return _context.Items.ToList();
        }

        public async Task<IEnumerable<Item>> ReadByCategory(string category)
        {
            return _context.Items.Where(item => item.Category == category).ToList();
        }


        public async Task<IEnumerable<Item>> ReadByAttributes(Item searchItem)
        {
            return _context.Items.Where(item =>
                (string.IsNullOrEmpty(searchItem.Title) || item.Title.Contains(searchItem.Title)) &&
                (string.IsNullOrEmpty(searchItem.Author) || item.Author.Contains(searchItem.Author)) &&
                (string.IsNullOrEmpty(searchItem.Description) || item.Description.Contains(searchItem.Description)) &&
                (string.IsNullOrEmpty(searchItem.Category) || item.Category.Contains(searchItem.Category)) &&
                (searchItem.CreatedAt.Equals(default(DateTime)) || item.CreatedAt == searchItem.CreatedAt));

        }


        public async Task<IEnumerable<Item>> ReadByTag(int tagId)

        {
            return _context.Items.Where(item => _context.ItemTags.Any(i => i.TagId == tagId && i.ItemId == item.Id)).ToList();
        }

        public async Task<IEnumerable<Item>> ReadMostRequested()
        {
            DateTime lastYearDate = new DateTime(DateTime.Now.Year - 1, DateTime.Now.Month, DateTime.Now.Day);

            var top50Ids = _context.BorrowRequests
                .Where(br => br.RequestDate >= lastYearDate)
                .GroupBy(br => br.ItemId)
                .OrderByDescending(group => group.Sum(br => 1))
                .Take(50)
                .Select(group => group.Key)
                .ToList();

            var items = _context.Items.Where(item => top50Ids.Contains(item.Id)).ToList();

            var sortedItems = top50Ids.Select(id => items.FirstOrDefault(item => item.Id == id)).ToList();

            return sortedItems;
        }

        public async Task<IEnumerable<Item>> ReadTheRecommended()
        {
            return await _context.Items
                                 .Where(item => item.Recommended == true && item.Author != null)
                                 .ToListAsync();
        }


        public async Task<IEnumerable<Item>> ReadSavedItems(int userId)
        {
            var items = _context.Items
                .Where(item => _context.RatingNotes.Any(rn => rn.ItemId == item.Id && rn.SavedItem && rn.UserId == userId))
                .ToList();

            return items;
        }

        public async Task<Item> ReadbyIdIncloud(int idItem)
        {
            return await _context.Items.Include(x => x.ItemTags).FirstOrDefaultAsync(t => t.Id == idItem);
        }

        public async Task<List<Item>> ReadAllIncloud(Item item)
        {
            Item? itemWithTags = await ReadbyIdIncloud(item.Id);
            if (itemWithTags == null)
            {
                return new List<Item>();
            }
            var tagIds = itemWithTags.ItemTags.Select(tag => tag.Id).ToList();
            return await _context.Items
                .Include(x => x.ItemTags)
                .Where(i => i.ItemTags.Any(tag => tagIds.Contains(tag.Id)))
                .ToListAsync();
        }

        public async Task<IEnumerable<Item>> ItemSuggestions(Item selectedItem)
        {
            return _context.Items.Where(item =>
                ((item.Author == selectedItem.Author) ||
                (item.Category == selectedItem.Category) ||
                (item.Series == selectedItem.Series)) &&
                item.Id != selectedItem.Id);
        }
    }
}
