using FirstMvc.Models;

namespace FirstMvc.Services;

public interface IUsersService {
    void Add(User item);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void DeleteById(int id);
}

public class UsersService : IUsersService {
    private readonly List<User> data;

    public UsersService() {
        data = new List<User> {
            new User{ Id=1, Name = "Liron"},
            new User{ Id=2, Name = "Mirit"},
            new User{ Id=3, Name = "Gili"}
        };
    }

    public IEnumerable<User> GetAll() {
        return data;
    }
    public User GetById(int id) {
        return findById(id);
    }
    public void Add(User item) {
        item.Id = 1;
        if(data.Any())
            item.Id += data.Max(x => x.Id);
        data.Add(item);
    }

    public void DeleteById(int id) {
        var item = findById(id);
        if(item != null)
            data.Remove(item);
    }

    private User findById(int id) {
        return data.FirstOrDefault(x => x.Id == id);
    }
}
