
// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО КНОПОК!
#define BUTTNUM 1

// ИЗМЕНИТЬ, ЕСЛИ ИЗМЕНИЛОСЬ КОЛИЧЕСТВО КНОПОК!
const byte buttIn[] = {3};
bool buttLog[] = {true};

String str = "";
int i;

int led = 2;


int sensorPin = A1;    // Порт к которому подключен потенциометр
int sensorValue = 0;  // Переменная для хранения показаний
int sensorValueOld = 0;


void setup() {
  Serial.begin(115200); // Инициализация порта для работы с ПК
  GetName();
  GetStartPositions();

}

void loop() {
 
  ///пт///
  sensorValue = analogRead(sensorPin);
  if ((sensorValue > sensorValueOld + 50) || (sensorValue < sensorValueOld - 50)) {
    Serial.print("p");
    Serial.print("#");
    Serial.print(0);
    Serial.print("#");
    if(sensorValue > 950){
      sensorValue = 1000;
      }
    Serial.println(sensorValue);
    sensorValueOld = sensorValue ;
  }


  ////////////////////////////////////////////////////////////////////////////////////
  ////////                                                                    ////////
  ////                                                                            ////
  //        СВЯЗЬ С ПК                                                              //
  ////                                                                            ////
  ////////                                                                    ////////
  ////////////////////////////////////////////////////////////////////////////////////

  if (Serial.available() > 0) { // Проверка, что есть данные от ПК
    str = Serial.readStringUntil('\n');
    //Serial.print("USER: ");
    //Serial.println(str);



    ///запрос имени кпа
    if (str == "GetName") {
      GetName();
    }

    ///запрос положение кпа
    if (str == "GetStartPosition") {
      GetStartPositions();
    }

    if (str == "on") {

      digitalWrite(led, HIGH);

    }
    if (str == "off") {
      digitalWrite(led, LOW);
    }




   

  }
}

void GetName() {

  Serial.println("kpa10");

}

void GetStartPositions() {

  Serial.println("complite");

  pinMode(led, OUTPUT);
  
 
  

  sensorValue = analogRead(sensorPin);
  Serial.print("p");
  Serial.print("#");
  Serial.print(0);
  Serial.print("#");
   if(sensorValue > 950){
      sensorValue = 1000;
      }
  Serial.println(sensorValue);
  sensorValueOld = sensorValue ;

  Serial.println("stop");

}
