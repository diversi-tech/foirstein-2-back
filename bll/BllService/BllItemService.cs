using AutoMapper;
using BLL.BllModels;
using BLL.IBll;

using DAL;
using DAL.IDal;
using DAL.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.BllService
{
    public class BllItemService : IbllItem
    {
        private DalManager _dalManager;
        private IMapper _mapper;
        public BllItemService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            _mapper = new Mapper(config);
            _dalManager = new DalManager();
        }

        public BllItemService(IMapper mapper, DalManager dalManager)
        {
            _mapper = mapper;
            _dalManager = dalManager;
        }

        public void MapItem()
        {
            BllItem bllRequest = new BllItem
            {
            };
            Item dalRequest = _mapper.Map<Item>(bllRequest);
        }

        public Task<bool> Create(BllItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(BllItem item)
        {
            throw new NotImplementedException();
        }

        public Task<List<BllItem>> Read(Func<BllItem, bool> filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BllItem>> ReadAll()
        {
            try
            {
                var dalItem = await _dalManager.items.ReadAll();

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to find all Items", ex);
            }
        }

        public async Task<BllItem> ReadbyId(int item)
        {
            var dalItem = await _dalManager.items.ReadbyId(item);
            var bllItem = _mapper.Map<BllItem>(dalItem);
            return bllItem;
        }

        public async Task<IEnumerable<BllItem>> ReadByString(string searchKey)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadByString(searchKey);

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch Items", ex);
            }
        }
        public async Task<IEnumerable<BllItem>> ReadByAttributes(BllItem searchItem)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadByAttributes(_mapper.Map<Item>(searchItem));

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch Items by attributes", ex);
            }
        }
        public Task<bool> Update(BllItem item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BllItem>> ReadByCategory(string category)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadByCategory(category);

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch items by category ", ex);
            }
        }

        public async Task<IEnumerable<BllItem>> ReadTheRecommended()
        {
            try
            {
                var dalItem = await _dalManager.items.ReadTheRecommended();

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to find recommendations", ex);
            }
        }

        public async Task<IEnumerable<BllItem>> ReadByTag(int tagId)

        {

            try

            {
                var dalItems = await _dalManager.items.ReadByTag(tagId);

                var bllItems = dalItems.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItems;

            }

            catch (Exception ex)

            {

                throw new Exception("Failed to fetch items by tag", ex);

            }

        }

        public async Task<IEnumerable<BllItem>> ReadMostRequested()
        {
            try
            {
                var dalItem = await _dalManager.items.ReadMostRequested();

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch MostRequested", ex);
            }
        }

        public async Task<IEnumerable<BllItem>> ReadSavedItems(int userId)
        {
            try
            {
                var dalItem = await _dalManager.items.ReadSavedItems(userId);

                var bllItem = dalItem.Select(item => _mapper.Map<BllItem>(item)).ToList();

                return bllItem;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to fetch ReadSavedItems", ex);
            }
        }

        public async Task<IEnumerable<BllItem>> ItemSuggestions(BllItem selectedItem)
        {
            try
            {
                var dalItems = await _dalManager.items.ItemSuggestions(_mapper.Map<Item>(selectedItem));
                var cta = dalItems.Select(item => _mapper.Map<BllItem>(item)).ToList();
                var dalItem = await _dalManager.items.ReadAllIncloud(_mapper.Map<Item>(selectedItem));
                var itemsInclude = dalItem.Select(item => _mapper.Map<BllItem>(item));
                cta = cta.Concat(itemsInclude).Distinct().Where(i => i.Id != selectedItem.Id).ToList();
                int[,] mat = new int[cta.Count(), 11];
                for (int i = 0; i < cta.Count(); i++)
                {
                    if (cta[i].Author == selectedItem.Author)
                        mat[i, 0] = 1;
                    if (cta[i].Category == selectedItem.Category)
                        mat[i, 1] = 1;
                    if (cta[i].Series == selectedItem.Series)
                        mat[i, 2] = 1;
                    if (itemsInclude.Contains(cta[i]))
                        mat[i, 3] = 1;
                    mat[i, 4] = mat[i, 0] + mat[i, 1] + mat[i, 2] + mat[i, 3];
                    for (int j = 0, j1 = 2; j < 4; j++, j1 *= 2)
                    {
                        mat[i, j + 5] = mat[i, j] * j1;
                    }
                    mat[i, 9] = mat[i, 5] + mat[i, 6] + mat[i, 7] + mat[i, 8];
                    mat[i, 10] = cta[i].Id;
                }
                var topRows = new PriorityQueue<(int[] row, int id), (int col1, int col2)>(Comparer<(int col1, int col2)>.Create((a, b) =>
                {
                    int result = b.col1.CompareTo(a.col1);
                    if (result == 0)
                        result = b.col2.CompareTo(a.col2);
                    return result;
                }));

                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    topRows.Enqueue((GetRow(mat, i), mat[i, 10]), (mat[i, 4], mat[i, 9]));
                    if (topRows.Count > 3)
                    {
                        topRows.Dequeue();
                    }
                }

                var result = new List<int>();
                while (topRows.Count > 0)
                {
                    result.Add(topRows.Dequeue().id);
                }

                result.Reverse();

                // Helper function to get a row from a 2D array
                int[] GetRow(int[,] matrix, int row)
                {
                    int cols = matrix.GetLength(1);
                    int[] resultRow = new int[cols];
                    for (int col = 0; col < cols; col++)
                    {
                        resultRow[col] = matrix[row, col];
                    }
                    return resultRow;
                }

                List<BllItem> bllItems = new List<BllItem>();
                foreach (int i in result)
                {
                    bllItems.Add(cta.First(item => item.Id == i));
                }

                return bllItems;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                throw new Exception("Failed to fetch itemS sggestions.", ex);
            }
        }

    }
}
