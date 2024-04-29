
// HARDWARE:  Arduino Leonardo and Serial Cable into Laptop
// Leonardo has 2 serials ports - Use SerialONE Serial1 for TX and RX pins

// Onboard USB-to-Serial = Serial.adsf
// Using Pins RX and TX:   Serial1.asdf
//   what could go wrong?  l1 is so readable

// Serial.write https://www.arduino.cc/reference/tr/language/functions/communication/serial/write/
// Writes binary data to the serial port. This data is sent as a byte or series of bytes
// Serial.write(str) - str: a string to send as a series of bytes
// Serial.write(buf, len)  - buf: an array to send as a series of bytes,
//                          len: the number of bytes to be sent from the array-


#define MAX_BUFF_LEN 13                                     // Max Message      JPLMARSROVER\n
                                                            // human 12 chars   123456789012+enter=13
                                                            // array 0..12      012345678901-12
#define MAX_INDEX 12                                        // Why confuse ourselves? index 0..12
#define NEWLINE '\n'                                        // Per Protocol end message with \n
#define NULL_CHAR '\0'                                      // Must add to make into string for DEBUG

  
void setup()
{
  pinMode(LED_BUILTIN, OUTPUT);  
  Serial1.begin(115200);         // Instantiate Serial at 115200 baud
  
  while (!Serial1) {
    ; // wait for serial port to connect. Needed for Leonardo only
  }
}

void robotTask()
{

  // numChars    123456789012
  Serial1.write("12MARSROVER!");                            // Serial.print affords formating
  delay(1000);                                              // Serial.write sends string as series
  Serial1.print("Lift_Weight!");
  delay(3000);
  Serial1.print("Home Pos!");
  delay(1000);

}

void ShotwellWeightLifting(void)
{
  // numChars   "123456789012
  Serial1.write("$DKT:2,1!");                              // Home Position
  delay(1000);  
  Serial1.write("$DKT:33,9!");                            // Walk w Arms Fwd
  delay(1800*9);                                          // K0033:kmFwd Walk - 10 seconds                                                
  Serial1.print("$DKT:44,1!");                             // Lift weight above head
  delay(1500*4);                                            // K0044: 1 wl start
  Serial1.print("$DKT:45,4!");                            // Walk w Arms Up
  delay(1800*4);                                            // K0045: walkAUp
  Serial1.write("$DKT:2,1!");                              // Home Position
  delay(1000);  
}

void blink()
{
  digitalWrite(LED_BUILTIN, HIGH);   // turn the LED on (HIGH is the voltage level)
  delay(500);
  digitalWrite(LED_BUILTIN, LOW);   // turn the LED on (HIGH is the voltage level) 
  delay(200);
}
void loop()
{
  blink();
  // robotTask();
  ShotwellWeightLifting();
}                                                           // end main()
