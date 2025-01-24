using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using PetFeedingTracker.Models;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection db;

    public DatabaseService(string dbPath)
    {
        db = new SQLiteAsyncConnection(dbPath);
        db.CreateTableAsync<Pet>().Wait();
        db.CreateTableAsync<FeedingRecord>().Wait();
    }

    public Task<List<Pet>> GetPetsAsync() => db.Table<Pet>().ToListAsync();
    public Task<int> SavePetAsync(Pet pet) => db.InsertOrReplaceAsync(pet);
    public Task<int> DeletePetAsync(Pet pet) => db.DeleteAsync(pet);

    public Task<List<FeedingRecord>> GetFeedingRecordsAsync(int petId) =>
        db.Table<FeedingRecord>().Where(r => r.PetId == petId).ToListAsync();

    public Task<int> SaveFeedingRecordAsync(FeedingRecord record) =>
        db.InsertAsync(record);
}
