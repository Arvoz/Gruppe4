package no.gruppe4.iot;
import java.util.ArrayList;

public class UserHandler {

    private ArrayList<User> users = new ArrayList<>();

    public UserHandler(User user) {
        this.users.add(user);
    }

    public UserHandler() {

    }

    public ArrayList<User> getAllUsers() {
        return this.users;
    }

    public User getUser(int index) {
        return this.users.get(index);
    }

    public void addUser(User user) {
        this.users.add(user);
    }

}