package no.gruppe4.iot;

public class User {
    
    private String user;
    private String macAddressController;
    private int userId;
    private static int idCounter = 1;

    public User(String user, String macAddressController) {
        this.user = user;
        this.macAddressController = macAddressController;
        this.userId = idCounter++;
    }

    public User(String user) {
        this.user = user;
        this.userId = idCounter++;
    }

    public void setId(int id) {
        this.userId = id;
    }

    public int getId() {
        return this.userId;
    }

    public String getUser() {
        return this.user;
    }

    public void setUser(String user) {
        this.user = user;
    }

    public String getMacAddressController() {
        return this.macAddressController;
    }

    public void setMacAddressController(String macAddressController) {
        this.macAddressController = macAddressController;
    }

}