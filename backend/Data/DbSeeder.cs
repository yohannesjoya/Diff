using Backend.Entities;
using MongoDB.Driver;


namespace Backend.Data; 

public class DbSeeder
{

    public static void SeedData(IMongoCollection<User> prdTable)
    {

        bool existUser = prdTable.Find(p => true).Any();

        if (!existUser)
        {

            prdTable.InsertManyAsync(GetPreparedUsers());

        }

    }

    private static IEnumerable<User> GetPreparedUsers()
    {
        return new List<User>() {

        new User
            {
                Id = "507f1f77bcf86cd799439011",
                Name = "Yohannes Desta",
                Email = "yohannedestagebru10@gmail.com",
                AvatarUrl = "https://next-auth.js.org/getting-started/typescript"
            },

    };
    }
}
