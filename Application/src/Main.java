import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.event.ChangeEvent;
import javax.swing.event.ChangeListener;

public class Main {


    public static void main(String[] args) {

        // Opprett et nytt vindu (JFrame)
        JFrame frame = new JFrame("IoT Enhetskontroll");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(400, 300);

        // Opprett en liste med IoT-enheter (f.eks. smarte lyspærer)
        String[] iotDevices = {"Lyspære 1", "Lyspære 2", "Lyspære 3"};
        JList<String> deviceList = new JList<>(iotDevices);
        deviceList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);

        // Legg til en label for lysstyrke
        JLabel brightnessLabel = new JLabel("Lysstyrke: 50%");

        // Opprett en slider for å justere lysstyrke (fra 0 til 100%)
        JSlider brightnessSlider = new JSlider(0, 100, 50);
        brightnessSlider.setMajorTickSpacing(20);
        brightnessSlider.setPaintTicks(true);
        brightnessSlider.setPaintLabels(true);

        // Oppdater label når slideren endres
        brightnessSlider.addChangeListener(new ChangeListener() {
            public void stateChanged(ChangeEvent e) {
                int value = brightnessSlider.getValue();
                brightnessLabel.setText("Lysstyrke: " + value + "%");
            }
        });

        // Opprett en knapp for å sende lysstyrkeverdien til den valgte enheten
        JButton sendButton = new JButton("Endre lysstyrke");
        sendButton.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
                String selectedDevice = deviceList.getSelectedValue();
                int brightnessValue = brightnessSlider.getValue();

                if (selectedDevice != null) {
                    // Dette er der du ville sendt verdien til IoT-enheten
                    JOptionPane.showMessageDialog(frame,
                            "Sender " + brightnessValue + "% lysstyrke til " + selectedDevice);
                } else {
                    JOptionPane.showMessageDialog(frame,
                            "Vennligst velg en IoT-enhet først!");
                }
            }
        });

        // Opprett et panel for å legge til komponentene
        JPanel panel = new JPanel();
        panel.add(new JScrollPane(deviceList));
        panel.add(brightnessLabel);
        panel.add(brightnessSlider);
        panel.add(sendButton);

        // Legg panelet til rammen og vis vinduet
        frame.add(panel);
        frame.setVisible(true);

    }

}