#include <PS4Controller.h>
#include "JointController.h"
#include "MotionController.h"

// Assuming you have initialized the necessary PLEN2 objects
extern MotionController motion_ctrl;
extern JointController joint_ctrl;

void setup() {
  Serial.begin(9600);

  // Initialize Bluetooth
  if (!PS4.begin("00:1A:7D:DA:71:13")) {  // Replace with your Bluetooth address
    Serial.println("Failed to connect to PS4 controller");
    while (1);
  }

  Serial.println("Connected to PS4 controller");
  motion_ctrl.init();
  joint_ctrl.init();
}

void loop() {
  if (PS4.isConnected()) {
    if (PS4.ButtonPressed(PS)) {
      // Power button pressed, handle shutdown or startup
      motion_ctrl.stop();
    }

    if (PS4.ButtonPressed(CROSS)) {
      // Start a specific animation
      motion_ctrl.play("walk");
    }

    if (PS4.ButtonPressed(CIRCLE)) {
      // Start another specific animation
      motion_ctrl.play("dance");
    }

    // Analog stick controls
    int x = PS4.AnalogStickX(L3);
    int y = PS4.AnalogStickY(L3);

    if (x > 128) { // Right
      // Adjust parameters as needed
      motion_ctrl.adjustParameter("right_shift");
    } else if (x < 127) { // Left
      // Adjust parameters as needed
      motion_ctrl.adjustParameter("left_shift");
    }

    if (y > 128) { // Forward
      motion_ctrl.play("forward");
    } else if (y < 127) { // Backward
      motion_ctrl.play("backward");
    }
  }
}
