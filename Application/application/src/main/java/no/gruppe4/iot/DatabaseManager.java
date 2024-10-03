package no.gruppe4.iot;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public class DatabaseManager {

    private static final String URL = "jdbc:mysql://localhost/gruppe4"; // Database URL
    private static final String USER = "root"; // Brukernavn for databasen
    private static final String PASSWORD = "DeteBerreLekkert12345"; // Ditt MySQL-passord

    // Metode for å koble til databasen
    public Connection connect() {
        Connection conn = null;
        try {
            // Last inn JDBC-driveren
            Class.forName("com.mysql.cj.jdbc.Driver");
    
            // Opprett tilkoblingen
            conn = DriverManager.getConnection(URL, USER, PASSWORD);
    
            System.out.println("Successfully connected to the database!");
        } catch (SQLException e) {
            System.out.println("SQL Exception: " + e.getMessage());
        } catch (ClassNotFoundException e) {
            System.out.println("Driver not found: " + e.getMessage());
        }
    
        if (conn == null) {
            System.out.println("Failed to connect to the database.");
        }
    
        return conn;
    }

    // Metode for å legge til en ny bruker i databasen
    public void addUser(User user) {
        String query = "INSERT INTO users (username, mac_address) VALUES (?, ?)";
    
        try (Connection conn = connect()) {
            if (conn == null) {
                System.out.println("Connection is null, cannot proceed.");
                return; // Avslutt metoden hvis tilkoblingen mislykkes
            }
    
            PreparedStatement stmt = conn.prepareStatement(query);
            stmt.setString(1, user.getUser());
            stmt.setString(2, user.getMacAddressController());
            stmt.executeUpdate();
            System.out.println("User added to database");
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    // Metode for å hente en bruker fra databasen
    public User getUserById(int userId) {
        String query = "SELECT * FROM users WHERE user_id = ?";
        User user = null;

        try (Connection conn = connect(); PreparedStatement stmt = conn.prepareStatement(query)) {
            stmt.setInt(1, userId);
            ResultSet rs = stmt.executeQuery();

            if (rs.next()) {
                String username = rs.getString("username");
                String macAddress = rs.getString("mac_address");
                user = new User(username, macAddress);
                user.setId(userId);
            }
        } catch (SQLException e) {
            e.printStackTrace();
        }

        return user;
    }
}
