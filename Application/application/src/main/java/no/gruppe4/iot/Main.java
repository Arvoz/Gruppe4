package no.gruppe4.iot;

public class Main {
    public static void main(String[] args) {

        /*
        User user = new User("Erling");
        User user2 = new User("Stefan");
        User user3 = new User("Jørgen");
        User user4 = new User("Stian");
        
        System.out.println(user.getId());
        System.out.println(user2.getId());
        System.out.println(user3.getId());
        System.out.println(user4.getId());
        */

        DatabaseManager dbManager = new DatabaseManager();

        User newUser = new User("Erling", "00:11:22:33:44:55");
        dbManager.addUser(newUser);

        User fetchedUser = dbManager.getUserById(1);
        if (fetchedUser != null) {
            System.out.println("Fetched user: " + fetchedUser.getUser() + ", MAC: " + fetchedUser.getMacAddressController());
        }

    }
}